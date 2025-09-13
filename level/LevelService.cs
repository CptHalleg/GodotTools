using Godot;
using System;

public partial class LevelService : Service
{
	private Node rootNode;

	private Node currentLevelNode;
	private Level currentLevel;

	public LevelService(Node rootNode)
	{
		this.rootNode = rootNode;
	}

	public void SetLevel(Level level)
	{
		if (currentLevelNode != null)
		{
			currentLevelNode.Free();
		}

		this.currentLevel = level;
		this.currentLevelNode = currentLevel.Load();

		rootNode.AddChild(currentLevelNode);

	}
}
