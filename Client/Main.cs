using Godot;
using SimpleInjector;
using Utility;

public class Main : EzPrefab
{
    public readonly LoginView LoginView;

    public override void _Ready()
    {
        base._Ready();

        var main = new SimpleInjector.Container();
        main.RegisterInstance(LoginView);

        X509Certificate certificate = new X509Certificate();
        certificate.Load("res://Certificate/X509Certificate.crt");
        main.RegisterInstance(certificate);

        main.RegisterInstance<ClientOptions<Gateway>>(new ClientOptions<Gateway>("localhost", 1969));



        main.RegisterSingleton<Gateway>();
        main.RegisterSingleton<GatewayController>();


        main.Verify();

        AddChild(main.GetInstance<Gateway>());
        AddChild(main.GetInstance<GatewayController>());

        // var gatewayController = main.GetInstance<GatewayController>();
    }
}
