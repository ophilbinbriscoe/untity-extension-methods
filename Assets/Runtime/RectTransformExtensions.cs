using System;
using System.Linq;
using System.Text;

using UnityEngine;

/// <summary>
/// Utility extensions for querying and modifying RectTransform instances.
/// </summary>
public static class RectTransformExtensions
{
	private static readonly Vector3[] corners = new Vector3[4];

	public static Vector2 GetAnchors ( this RectTransform rectTransform, Vector3 worldPosition, bool clamp = false )
	{
		rectTransform.GetWorldCorners( corners );

		float x = (worldPosition.x - corners[0].x) / (corners[2].x - corners[0].x);
		float y = (worldPosition.y - corners[0].y) / (corners[2].y - corners[0].y);

		if ( clamp )
		{
			x = Mathf.Clamp01( x );
			y = Mathf.Clamp01( y );
		}

		return new Vector2( x, y );
	}

	/// <summary>
	/// source: http://answers.unity3d.com/questions/976201/set-a-recttranforms-pivot-without-changing-its-pos.html
	/// </summary>
	/// <param name="rectTransform"></param>
	/// <param name="pivot"></param>
	/// <param name="anchoredPositionStays"></param>
	public static void SetPivot ( this RectTransform rectTransform, Vector2 pivot, bool anchoredPositionStays = true )
	{
		if ( !anchoredPositionStays )
		{
			rectTransform.pivot = pivot;

			return;
		}

		Vector2 size = rectTransform.rect.size;
		Vector2 deltaPivot = rectTransform.pivot - pivot;
		Vector3 deltaPosition = new Vector3( deltaPivot.x * size.x, deltaPivot.y * size.y );

		rectTransform.pivot = pivot;
		rectTransform.localPosition -= deltaPosition;
	}

	public static Vector3 GetWorldCenter ( this RectTransform rectTransform )
	{
		rectTransform.GetWorldCorners( corners );

		Vector3 position = Vector3.zero;

		for ( int i = 0; i < 4; i++ )
		{
			position += corners[i];
		}

		return position / 4f;
	}

	/// <summary>
	/// Set anchorMin and anchorMax simultaneously.
	/// </summary>
	/// <param name="rectTransform"></param>
	/// <param name="x">Anchor x.</param>
	/// <param name="y">Anchor y.</param>
	public static void SetAnchor ( this RectTransform rectTransform, float x, float y )
	{
		var anchor = new Vector2( x, y );

		rectTransform.anchorMin = anchor;
		rectTransform.anchorMax = anchor;
	}

	/// <summary>
	/// Set anchorMin and anchorMax simultaneously.
	/// </summary>
	/// <param name="rectTransform"></param>
	/// <param name="anchor">Anchor.</param>
	public static void SetAnchor ( this RectTransform rectTransform, Vector2 anchor )
	{
		rectTransform.anchorMin = anchor;
		rectTransform.anchorMax = anchor;
	}

	/// <summary>
	/// Set anchorMin and anchorMax simultaneously.
	/// </summary>
	/// <param name="rectTransform"></param>
	/// <param name="anchor">Anchor.</param>
	public static void SetAnchorX ( this RectTransform rectTransform, Vector2 anchor )
	{
		rectTransform.anchorMin = anchor;
		rectTransform.anchorMax = anchor;
	}

	/// <summary>
	/// Set the y component of anchorMin and anchorMax simultaneously.
	/// </summary>
	/// <param name="rectTransform"></param>
	/// <param name="y">Anchor y.</param>
	public static void SetAnchorY ( this RectTransform rectTransform, float y)
	{
		rectTransform.anchorMin = new Vector2( rectTransform.anchorMin.x, y );
		rectTransform.anchorMax = new Vector2( rectTransform.anchorMax.x, y );
	}

	/// <summary>
	/// Set the x component of anchorMin and anchorMax simultaneously.
	/// </summary>
	/// <param name="rectTransform"></param>
	/// <param name="x">Anchor x.</param>
	public static void SetAnchorX ( this RectTransform rectTransform, float x )
	{
		rectTransform.anchorMin = new Vector2( x, rectTransform.anchorMin.y );
		rectTransform.anchorMax = new Vector2( x, rectTransform.anchorMax.y );
	}

	/// <summary>
	/// Set the y component of the pivot.
	/// </summary>
	/// <param name="rectTransform"></param>
	/// <param name="y">Pivot y.</param>
	public static void SetPivotY ( this RectTransform rectTransform, float y )
	{
		rectTransform.pivot = new Vector2( rectTransform.pivot.x, y );
	}

	/// <summary>
	/// Set the x component of the pivot.
	/// </summary>
	/// <param name="rectTransform"></param>
	/// <param name="x">Pivot x.</param>
	public static void SetPivotX ( this RectTransform rectTransform, float x )
	{
		rectTransform.pivot = new Vector2( x, rectTransform.pivot.y );
	}

	/// <summary>
	/// Set the y component of the anchored position.
	/// </summary>
	/// <param name="rectTransform"></param>
	/// <param name="y">Anchored position y.</param>
	public static void SetAnchoredPositionY ( this RectTransform rectTransform, float y )
	{
		rectTransform.anchoredPosition = new Vector2( rectTransform.anchoredPosition.x, y );
	}

	/// <summary>
	/// Set the x component of the anchored position.
	/// </summary>
	/// <param name="rectTransform"></param>
	/// <param name="x">Anchored position x.</param>
	public static void SetAnchoredPositionX ( this RectTransform rectTransform, float x )
	{
		rectTransform.anchoredPosition = new Vector2( x, rectTransform.anchoredPosition.y );
	}
}

