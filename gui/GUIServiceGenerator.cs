using Godot;
using System;

public partial class GUIServiceGenerator : Node, ServiceGenerator<GUIService>
{
	public override void _EnterTree()
	{
		ServiceManager.Instance.RegisterServiceGenerator<GUIService>(this);
	}


	public Service GenerateService()
	{
		return new GUIService(this);
	}
}
