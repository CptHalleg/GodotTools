using System;
using Godot;

[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class EventBinding : Attribute
{
    public string NodePath { get; private set; }
    public string EventName { get; private set; }

    public EventBinding(string nodePath, string eventName)
    {
        this.NodePath = nodePath;
        this.EventName = eventName;
    }
}