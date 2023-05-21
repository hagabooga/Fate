using System.Linq;
using System.Reflection;
using Godot;
using static Godot.GD;
using System;

public abstract partial class ExplicitNode : Node
{
    private const BindingFlags InstanceNonPublic = BindingFlags.Instance | BindingFlags.NonPublic;
    private const BindingFlags InstancePublic = BindingFlags.Instance | BindingFlags.Public;

    static MethodInfo FindChildMethod { get; } = typeof(Node)
        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
        .Where(x => x.Name == "FindChild")
        .First();

    static Func<ExplicitNode, string, bool, bool, Node> FindChildDelegate { get; } =
        (Func<ExplicitNode, string, bool, bool, Node>)
            Delegate.CreateDelegate(typeof(Func<ExplicitNode, string, bool, bool, Node>), FindChildMethod);

    static Func<PropertyInfo, bool> IsPropertyExplicit { get; } =
        property => property.GetMethod is not null
                    && property.SetMethod is null
                    && property.Name != "Multiplayer"
                    && property.Name != "NativeInstance";

    public override void _Ready()
    {
        var type = GetType();
        var publicProperties = type
            .GetProperties(InstancePublic)
            .Where(IsPropertyExplicit);

        foreach (var property in publicProperties)
        {
            var path = $"{GetPath()}/{property.Name}";
            var value = FindChildDelegate(this, property.Name, true, true);
            if (value is null)
            {
                Print($"{type.Name}.{Name}: {property.Name} is null!");
            }
            else
            {
                type.GetField($"<{property.Name}>k__BackingField", InstanceNonPublic)
                    .SetValue(this, value);
            }
        }
    }
}