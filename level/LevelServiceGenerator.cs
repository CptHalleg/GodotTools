using Godot;
using System;

public partial class LevelServiceGenerator : Node, ServiceGenerator<LevelService>
{

	public override void _EnterTree()
	{
		ServiceManager.Instance.RegisterServiceGenerator<LevelService>(this);
	}

	public Service GenerateService()
	{
		return new LevelService(this);
	}
}
