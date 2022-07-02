using Godot;
using SimpleInjector;
using Utility;
using static Godot.GD;
using System.Reflection;
using System.Linq;

public class Main : EzPrefab
{
    public static readonly MethodInfo RegisterSingletonMethod = typeof(SimpleInjector.Container)
          .GetMethods()
          .Where(x => x.Name == "RegisterSingleton")
          .ToArray()[4];

    public readonly MainMenu.View MainMenuView;

    public SimpleInjector.Container main { get; private set; }

    public override void _Ready()
    {
        base._Ready();

        main = new SimpleInjector.Container();
        main.RegisterInstance(MainMenuView);
        main.RegisterInstance(MainMenuView.LoginView);
        main.RegisterInstance(MainMenuView.CreateAccountView);

        X509Certificate certificate = new X509Certificate();
        certificate.Load("res://Certificate/X509Certificate.crt");
        main.RegisterInstance(certificate);

        main.RegisterInstance<ClientOptions<Gateway>>(new ClientOptions<Gateway>("localhost", 1969));

        main.RegisterSingleton<Login.Model>();
        main.RegisterSingleton<CreateAccount.Model>();


        var typesToAddAsChild = new[] {
            typeof(Gateway),
            typeof(Login.Presenter),
            typeof(CreateAccount.Presenter),
            typeof(MainMenu.Controller),
        };




        typesToAddAsChild.ForEach(x =>
        {
            RegisterSingletonMethod.MakeGenericMethod(x).Invoke(main, new object[] { });
        });

        main.Verify();

        typesToAddAsChild.ForEach(x =>
        {
            AddChild((Node)main.GetInstance(x));
        });
    }
}
