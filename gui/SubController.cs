using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public partial class SubController : Node
{
	private GameMenuController gameMenuController;
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("game_menu"))
		{
			if (gameMenuController == null)
			{
				gameMenuController = new GameMenuController();
				gameMenuController.Activate(this);
			}
			else
			{
				gameMenuController.Deactivate();
				gameMenuController = null;
			}
		}
	}
}