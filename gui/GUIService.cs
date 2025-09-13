using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

public class GUIService : Service
{
	private Node uiRoot;
	private Controller currentController;

	public GUIService(Node uiRoot)
	{
		this.uiRoot = uiRoot;
	}

	public void ActivateController(Controller controller)
	{
		if (currentController != null)
		{
			currentController.Deactivate();
		}
		controller.Activate(uiRoot);
		currentController = controller;
	}

}
