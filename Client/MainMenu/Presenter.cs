using Godot;
using System;
using Utility;
using static Godot.GD;

namespace MainMenu
{
    public class Presenter : EzNode
    {
        readonly Login.Presenter loginPresenter;
        readonly CreateAccount.Presenter createAccountPresenter;
        readonly Gateway gateway;

        public Presenter(Login.Presenter loginPresenter,
                         CreateAccount.Presenter createAccountPresenter,
                         Gateway gateway)
        {
            this.loginPresenter = loginPresenter;
            this.createAccountPresenter = createAccountPresenter;
            this.gateway = gateway;

            loginPresenter.success += () =>
            {
                gateway.ConnectToServer(loginPresenter.Username, loginPresenter.Password);
            };

            loginPresenter.signUpPressed += () =>
            {
                loginPresenter.SetVisible(false);
                createAccountPresenter.SetVisible(true);
            };

            createAccountPresenter.goBackToLoginPressed += () =>
            {
                loginPresenter.SetVisible(true);
                createAccountPresenter.SetVisible(false);
            };
        }

        // public MainMenuController(Login.View loginView,
        //                           CreateAccountView createAccountView,
        //                           Gateway gateway)
        // {
        //     this.loginView = loginView;
        //     this.createAccountView = createAccountView;
        //     this.gateway = gateway;
        //     loginView.Login.Connect("pressed", this, nameof(LoginButtonPressed));
        //     createAccountView.CreateAccount.Connect("pressed", this, nameof(RequestCreateAccount));
        //     gateway.Connect(nameof(Gateway.ReceivedLoginRequest), this, nameof(ReceivedLoginRequest));
        // }

        // public override void _Ready()
        // {
        //     base._Ready();
        // }

        // private void ReceivedLoginRequest(Error result)
        // {
        //     Print($"GatewayController.ReceivedLoginRequest() => result: {result}.");
        // }

        // private void RequestCreateAccount()
        // {
        //     Print("Requesting new account.");
        //     RpcId(1, "ReceiveCreateAccountRequest", loginView.Username.Text, loginView.Password.Text.SHA256Text());
        // }

        // private void LoginButtonPressed()
        // {
        //     gateway.ConnectToServer(loginView.Username.Text, loginView.Password.Text);
        // }
    }
}