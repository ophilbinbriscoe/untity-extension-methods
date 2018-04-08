using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

/// <summary>
/// Utility extensions for querying and modifying Component instances.
/// </summary>
public static class ComponentExtensions
{
	public static bool HasComponent<T> ( this Component component )
	{
		return component.GetComponent<T>() != null;
	}

	public static bool HasComponent ( this Component component, Type type )
	{
		return component.GetComponent( type ) != null;
	}

	public static T GetComponentInHierarchy<T> ( this Component component )
	{
		var candidate = component.GetComponentInChildren<T>();

		return candidate == null ? component.GetComponentInParent<T>() : candidate;
	}
}