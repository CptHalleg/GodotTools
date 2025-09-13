using Godot;
using System;

public interface BaseServiceGenerator
{
	public abstract Service GenerateService();
}

public interface ServiceGenerator<T> : BaseServiceGenerator where T : Service
{
}

