using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

/// <summary>
/// Utility extensions for querying and modifying GameObject instances.
/// </summary>
public static class GameObjectExtensions
{
	public static bool HasComponent<T> ( this GameObject gameObject )
	{
		return gameObject.GetComponent<T>() != null;
	}

	public static bool HasComponent ( this GameObject gameObject, Type type )
	{
		return gameObject.GetComponent( type ) != null;
	}

	public static T GetComponentInHierarchy<T> ( this GameObject gameObject )
	{
		var candidate = gameObject.GetComponentInParent<T>();

		return candidate == null ? gameObject.GetComponentInChildren<T>() : candidate;
	}
}