using Godot;
using System;
using Utility;
using static Godot.GD;

public class GatewayController : EzNode
{
    readonly LoginView loginView;
    readonly Gateway gateway;

    public GatewayController(LoginView loginView,
                             Gateway gateway)
    {
        this.loginView = loginView;
        this.gateway = gateway;
        loginView.Login.Connect("pressed", this, nameof(OnLoginButtonPressed));
        gateway.Connect(nameof(Gateway.ReceivedLoginRequest), this, nameof(ReceivedLoginRequest));
    }



    public override void _Ready()
    {
        base._Ready();
    }

    private void ReceivedLoginRequest(Error result)
    {
        Print($"GatewayController.ReceivedLoginRequest: result: {result}.");
    }

    private void OnLoginButtonPressed()
    {
        gateway.ConnectToServer("hagabooga", "asdasd");
    }
}
