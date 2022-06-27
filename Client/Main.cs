using Godot;
using SimpleInjector;
using Utility;
using static Godot.GD;
using System.Reflection;
using System.Linq;

public class Main : EzPrefab
{
    public readonly MainMenu.View MainMenuView;

    public override void _Ready()
    {
        base._Ready();

        var main = new SimpleInjector.Container();
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
            typeof(MainMenu.Presenter),
        };

        main.RegisterSingleton<Gateway>();
        main.RegisterSingleton<Login.Presenter>();
        main.RegisterSingleton<CreateAccount.Presenter>();
        main.RegisterSingleton<MainMenu.Presenter>();

        main.Verify();

        typesToAddAsChild.ForEach(x =>
        {
            AddChild((Node)main.GetInstance(x));
        });
    }
}
