using Godot;
using System;
using static Godot.GD;

public sealed partial class LoginPresenter : Node
{
    readonly LoginModel model;
    readonly LoginView view;

    private Tween messageTween;

    public LoginPresenter(LoginModel model,
                          LoginView view)
    {
        this.model = model;
        this.view = view;


        Setup();
    }

    private void Setup()
    {

        model.OnResultOutput += result =>
        {
            view.Title.Text = result;
            view.Title.Modulate = Colors.White;
            messageTween?.Kill();
            messageTween = GetTree()
                .CreateTween()
                .SetEase(Tween.EaseType.InOut)
                .SetTrans(Tween.TransitionType.Quad);
            messageTween.TweenInterval(0.5);
            messageTween.TweenProperty(view.Title,
                                       "modulate",
                                       Colors.Transparent,
                                       1);
            messageTween.Play();
        };

        view.Login.Pressed += () =>
        {
            model.Username = view.Username.Text;
            model.Password = view.Password.Text;
            model.IpAddress = view.IpAddress.Text;
            if (!model.IsValidUsername || !model.IsValidPassword || !model.IsValidIpAddress)
            {
                return;
            }
        };
    }
}
