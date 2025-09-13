using Godot;
using System;
using System.Collections.Generic;

public class ServiceManager
{
	public static ServiceManager Instance { get; private set; }

	public static void Initialize()
	{
		if (Instance != null)
		{
			throw new Exception();
		}

		Instance = new ServiceManager();
	}

	private Dictionary<Type, Service> cachedServices;
	private Dictionary<Type, BaseServiceGenerator> serviceGenerators;

	public ServiceManager()
	{
		cachedServices = new Dictionary<Type, Service>();
		serviceGenerators = new Dictionary<Type, BaseServiceGenerator>();
	}

	public T GetService<T>() where T : Service
	{
		Type type = typeof(T);
		if (cachedServices.ContainsKey(type))
		{
			return (T)cachedServices[type];
		}

		if (serviceGenerators.ContainsKey(type))
		{
			Service service = serviceGenerators[type].GenerateService();
			cachedServices[type] = service;
			return (T)service;
		}

		return default;
	}

	public bool RegisterServiceGenerator<T>(ServiceGenerator<T> serviceGenerator) where T : Service
	{
		Type type = typeof(T);
		if (serviceGenerators.ContainsKey(type))
		{
			return false;
		}

		serviceGenerators[type] = serviceGenerator;

		return true;
	}

	public bool UnRegisterServiceGenerator(Type type)
	{
		return serviceGenerators.Remove(type);
	}

	public bool ClearCashe(Type type)
	{
		return cachedServices.Remove(type);
	}
}
