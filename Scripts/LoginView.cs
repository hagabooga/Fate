using Godot;
using System;
using static Godot.GD;

public interface ILoginView
{
    string Title { get; set; }
    string Username { get; set; }
    string Password { get; set; }
    string IpAddress { get; set; }
    string Message { get; set; }
    Color TitleColor { set; }

    event Action LoginPressed;

    void FlashMessage();
}

public sealed partial class LoginView : ExplicitNode, ILoginView
{
    public event Action LoginPressed;

    Tween messageTween;

    public string Title
    {
        get => TitleLabel.Text;
        set => TitleLabel.Text = value;
    }
    public string Username
    {
        get => UsernameLineEdit.Text;
        set => UsernameLineEdit.Text = value;
    }
    public string Password
    {
        get => PasswordLineEdit.Text;
        set => PasswordLineEdit.Text = value;
    }
    public string IpAddress
    {
        get => IpAddressLineEdit.Text;
        set => IpAddressLineEdit.Text = value;
    }
    public Color TitleColor
    {
        set => TitleLabel.Modulate = value;
    }
    public string Message
    {
        get => MessageLabel.Text;
        set => MessageLabel.Text = value;
    }


    Label TitleLabel { get; }
    Label MessageLabel { get; }
    LineEdit UsernameLineEdit { get; }
    LineEdit PasswordLineEdit { get; }
    LineEdit IpAddressLineEdit { get; }
    Button LoginButton { get; }

    public override void _Ready()
    {
        base._Ready();
        MessageLabel.Modulate = Colors.Transparent;
        LoginButton.Pressed += () => LoginPressed?.Invoke();
    }


    public void FlashMessage()
    {
        messageTween?.Kill();
        messageTween = GetTree()
            .CreateTween()
            .SetEase(Tween.EaseType.InOut)
            .SetTrans(Tween.TransitionType.Quad);
        MessageLabel.Modulate = Colors.White;
        messageTween.TweenInterval(0.5);
        messageTween.TweenProperty(MessageLabel,
                                   "modulate",
                                   Colors.Transparent,
                                   1);
        messageTween.Play();
    }
}
