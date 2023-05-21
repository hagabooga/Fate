using Godot;
using System;
using static Godot.GD;


public sealed partial class LoginView : ExplicitNode
{
    public Label Title { get; }
    public LineEdit Username { get; }
    public LineEdit Password { get; }
    public LineEdit IpAddress { get; }
    public Button Login { get; }
}
