using Godot;
using System;
using SimpleInjector;
using static Godot.GD;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fractural.Tasks;


public partial class Main : ExplicitNode
{
    [Export] PackedScene loginViewPs;

    static MethodInfo RegisterSingleton1Type0Args { get; } = typeof(SimpleInjector.Container)
        .GetMethods()
        .Single(x => x.IsGenericMethod
                    && x.Name == "RegisterSingleton"
                    && x.GetParameters().Length == 0
                    && x.GetGenericArguments().Length == 1);

    static MethodInfo RegisterInstance1Type1Args { get; } = typeof(SimpleInjector.Container)
        .GetMethods()
        .Single(x => x.IsGenericMethod
                     && x.Name == "RegisterInstance"
                     && x.GetParameters().Length == 1
                     && x.GetGenericArguments().Length == 1);


    static MethodInfo GetInstance1Type0Args { get; } = typeof(SimpleInjector.Container)
        .GetMethods()
        .Single(x => x.IsGenericMethod
                    && x.Name == "GetInstance"
                    && x.GetParameters().Length == 0
                    && x.GetGenericArguments().Length == 1);



    readonly SimpleInjector.Container container = new();

    public override void _Ready()
    {
        base._Ready();

        Engine.MaxFps = 200;

        var typesToRegisterAsNode = new[]
        {
            typeof(HotkeyInputs),
            typeof(LoginPresenter),
        };
        var instancesToRegisterAsInterface = new (Node, Type)[]
        {
            (loginViewPs.Instantiate<LoginView>(), typeof(ILoginView)),
        };

        foreach (var (node, type) in instancesToRegisterAsInterface)
        {
            var genericMethod = RegisterInstance1Type1Args.MakeGenericMethod(type);
            genericMethod.Invoke(container, new object[] { node });
            AddChild(node);
            node.Name = type.Name;
        }

        container.RegisterSingleton<LoginModel>();

        foreach (var type in typesToRegisterAsNode)
        {
            var genericMethod = RegisterSingleton1Type0Args.MakeGenericMethod(type);
            genericMethod.Invoke(container, new object[] { });
        }

        container.Verify();

        foreach (var type in typesToRegisterAsNode)
        {
            var genericMethod = GetInstance1Type0Args.MakeGenericMethod(type);
            var node = (Node)genericMethod.Invoke(container, new object[] { });
            AddChild(node);
            node.Name = type.Name;
        }
    }
}
