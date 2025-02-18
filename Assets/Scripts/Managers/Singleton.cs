﻿using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;
    
    public bool _PersistentOnSceneChange = false;
	
    protected Singleton() { }

	public static T Instance
	{
		get
		{
			if (instance == null)
				instance = FindObjectOfType<T>();

			return instance;
		}
	}

	protected virtual void Awake()
	{
		if (_PersistentOnSceneChange)
			DontDestroyOnLoad(gameObject);
	}

	protected virtual void Start()
	{
		T[] instance = FindObjectsOfType<T>();
		if (instance.Length > 1)
		{
			Debug.Log(gameObject.name + " has been destroyed because item exist in scene.");
			Destroy(gameObject);
		}
	}

	protected virtual void OnDestroy()
	{
		if (this == instance)
			instance = null;
	}
}
