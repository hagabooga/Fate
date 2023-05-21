using Godot;
using System;
using SI = SimpleInjector;
using static Godot.GD;
using System.Reflection;

public static class NodeExtensions
{
    public static SignalAwaiter GetEndOfFrame(this Node node) =>
        node.ToSignal(node.GetTree(), "process_frame");

}