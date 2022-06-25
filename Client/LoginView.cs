using Godot;
using System;
using static Godot.GD;
using Utility;

public class LoginView : EzPrefab
{
    public readonly LineEdit Username, Password;
    public readonly Button Login;

    public override void _Ready()
    {
        base._Ready();
    }
}
