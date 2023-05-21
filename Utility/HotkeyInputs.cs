using static Godot.GD;
using Godot;

public partial class HotkeyInputs : Node
{
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Fullscreen"))
        {
            DisplayServer.WindowSetMode(
                DisplayServer.WindowGetMode() == DisplayServer.WindowMode.Fullscreen ?
                    DisplayServer.WindowMode.Windowed :
                    DisplayServer.WindowMode.Fullscreen);
        }
    }
}