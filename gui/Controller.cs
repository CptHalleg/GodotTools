using Godot;
using System;
using System.Collections.Generic;
using System.Reflection;

public abstract class Controller
{
	protected Node currentView;
	public abstract PackedScene LoadView();

	public void Activate(Node parent)
	{
		PackedScene view = LoadView();


		currentView = view.Instantiate();
		parent.AddChild(currentView);

		BindEvents();
	}

	public void Deactivate()
	{
		currentView.GetParent().RemoveChild(currentView);
		if (currentView != null)
		{
			currentView.QueueFree();
		}
	}


	private void BindEvents()
	{
		foreach (var method in GetSignalBindingMethods(this))
		{
			EventBinding eventBinding = method.GetCustomAttribute<EventBinding>();


			if (!currentView.HasNode(eventBinding.NodePath))
			{
				throw new Exception("Node " + eventBinding.NodePath + " does not Exist. Controller: " + GetType());
			}
			Node node = currentView.GetNode(eventBinding.NodePath);


			EventInfo signal = node.GetType().GetEvent(eventBinding.EventName);
			if (signal == null)
			{
				throw new Exception("Event " + eventBinding.EventName + " does not Exist. Controller: " + GetType());
			}


			BindMethodToEvent(this, method, node, signal);
		}
	}

	private List<MethodInfo> GetSignalBindingMethods(Controller controller)
	{
		List<MethodInfo> list = new List<MethodInfo>();
		foreach (var methodInfo in controller.GetType().GetMethods())
		{
			if (methodInfo.GetCustomAttribute<EventBinding>() != null)
			{
				list.Add(methodInfo);
			}
		}
		return list;
	}

	private void BindMethodToEvent(Controller controller, MethodInfo method, Node node, EventInfo eventInfo)
	{
		Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, controller, method);
		eventInfo.AddEventHandler(node, handler);
	}
}
