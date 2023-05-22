using Godot;
using System;
using static Godot.GD;

public sealed partial class LoginPresenter : Node
{
    readonly LoginModel model;
    readonly ILoginView view;


    public LoginPresenter(LoginModel model,
                          ILoginView view)
    {
        this.model = model;
        this.view = view;
    }

    public override void _Ready()
    {
        model.OnResultOutput += result =>
        {
            view.Message = result;
            view.TitleColor = Colors.White;
            view.FlashMessage();
        };

        view.LoginPressed += () =>
        {
            model.Username = view.Username;
            model.Password = view.Password;
            model.IpAddress = view.IpAddress;
            if (!model.IsValidUsername || !model.IsValidPassword || !model.IsValidIpAddress)
            {
                return;
            }
        };
    }
}
