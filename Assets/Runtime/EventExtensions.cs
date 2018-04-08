using System;
using System.Linq;
using System.Text;

using UnityEngine;

/// <summary>
/// Utility extensions for semantic Event queries.
/// </summary>
public static class EventExtensions
{
	/// <summary>
	/// Check if an Event is a context click.
	/// </summary>
	/// <param name="current">Event to query.</param>
	/// <param name="contextButton">Context button (default is RMB).</param>
	/// <returns>True, if the Event was a context click.</returns>
	public static bool IsContextClick ( this Event current, int contextButton = 1 )
	{
		return current.type == EventType.MouseDown && current.button == contextButton;
	}

	/// <summary>
	/// Check if an Event is a left click.
	/// </summary>
	/// <param name="current">Event to query.</param>
	/// <returns>True, if the Event was a left click.</returns>
	public static bool IsLeftClick ( this Event current )
	{
		return current.type == EventType.MouseDown && current.button == 0;
	}

	/// <summary>
	/// Check if an Event is a drag.
	/// </summary>
	/// <param name="current">Event to query.</param>
	/// <param name="dragButton">Drag button (default is LMB).</param>
	/// <returns>True, if the Event was a drag.</returns>
	public static bool IsDrag ( this Event current, int dragButton = 0 )
	{
		return current.type == EventType.MouseDrag && current.button == dragButton;
	}

	public static bool IsArrowKey ( this Event current )
	{
		return current.keyCode == KeyCode.LeftArrow || current.keyCode == KeyCode.RightArrow || current.keyCode == KeyCode.UpArrow || current.keyCode == KeyCode.DownArrow;
	}
}

