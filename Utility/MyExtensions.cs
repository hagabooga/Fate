using Godot;
using System;
using SI = SimpleInjector;
using static Godot.GD;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

public static class MyExtensions
{
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        foreach (var item in enumerable) action.Invoke(item);
    }

    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
    {
        int i = 0;
        foreach (var item in enumerable)
        {
            action.Invoke(item, i++);
        }
    }
}