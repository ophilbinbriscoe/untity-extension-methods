using System;
using System.Linq;
using System.Text;

using UnityEngine;

/// <summary>
/// Utility extensions for manipulating Rect values.
/// </summary>
public static class RectExtensions
{
	#region Queries
	public static float ShortestSide ( this Rect rect )
	{
		return Mathf.Min( rect.width, rect.height );
	}

	public static float LongestSide ( this Rect rect )
	{
		return Mathf.Max( rect.width, rect.height );
	}
	#endregion

	public static Rect Transform ( this Rect rect, Matrix4x4 matrix )
	{
		return new Rect( matrix.MultiplyPoint3x4( rect.position ), matrix.MultiplyVector( rect.size ) );
	}

	#region Resizing
	public static Rect SetWidth ( this Rect rect, float width )
	{
		return new Rect( rect.x, rect.y, width, rect.height );
	}

	public static Rect SetHeight ( this Rect rect, float height )
	{
		return new Rect( rect.x, rect.y, rect.width, height );
	}

	public static Rect SetWidthCentered ( this Rect rect, float width )
	{
		return new Rect( rect.center.x - width * 0.5f, rect.y, width, rect.height );
	}

	public static Rect SetHeightCentered ( this Rect rect, float height )
	{
		return new Rect( rect.x, rect.center.y - height * 0.5f, rect.width, height );
	}

	public static Rect SetSize ( this Rect rect, float size )
	{
		return rect.SetSize( Vector2.one * size );
	}

	public static Rect SetSize ( this Rect rect, float width, float height )
	{
		return rect.SetSize( new Vector2( width, height ) );
	}

	public static Rect SetSize ( this Rect rect, Vector2 size )
	{
		return new Rect( rect.position, size );
	}

	public static Rect SetSizeCentered ( this Rect rect, float size )
	{
		return rect.SetSizeCentered( Vector2.one * size );
	}

	public static Rect SetSizeCentered ( this Rect rect, float width, float height )
	{
		return rect.SetSizeCentered( new Vector2( width, height ) );
	}

	public static Rect SetSizeCentered ( this Rect rect, Vector2 size)
	{
		return new Rect( rect.center - size * 0.5f, size );
	}
	#endregion

	#region Repositioning
	public static Rect SetPosition ( this Rect rect, Vector2 position )
	{
		return rect.SetPosition( position.x, position.y );
	}

	public static Rect SetPosition ( this Rect rect, float x, float y )
	{
		return new Rect( x, y, rect.width, rect.height );
	}

	public static Rect SetX ( this Rect rect, float x )
	{
		return new Rect( x, rect.y, rect.width, rect.height );
	}

	public static Rect SetY ( this Rect rect, float y )
	{
		return new Rect( rect.x, y, rect.width, rect.height );
	}

	public static Rect Recenter ( this Rect rect, Vector2 center )
	{
		return new Rect( center, rect.size );
	}

	public static Rect Recenter ( this Rect rect, float x, float y )
	{
		return Recenter( rect, new Vector2( x, y ) );
	}

	public static Rect RecenterX ( this Rect rect, float x )
	{
		return new Rect( new Vector2( x, rect.center.y ), rect.size );
	}

	public static Rect RecenterY ( this Rect rect, float y )
	{
		return new Rect( new Vector2( rect.center.x, y ), rect.size );
	}

	public static Rect DisplaceX ( this Rect rect, float x )
	{
		return new Rect( rect.x + x, rect.y, rect.width, rect.height );
	}

	public static Rect DisplaceY ( this Rect rect, float y )
	{
		return new Rect( rect.x, rect.y + y, rect.width, rect.height );
	}

	public static Rect Displace ( this Rect rect, float x, float y )
	{
		return new Rect( rect.x + x, rect.y + y, rect.width, rect.height );
	}

	public static Rect Displace ( this Rect rect, Vector2 displacement )
	{
		return new Rect( rect.position + displacement, rect.size );
	}
	#endregion

	#region Insetting
	/// <summary>
	/// Split a Rect by insetting from the right edge.
	/// </summary>
	/// <param name="rect">Rect to split.</param>
	/// <param name="inset">Inset width.</param>
	/// <param name="result">Inset Rect.</param>
	/// <returns></returns>
	public static Rect SplitRight ( this Rect rect, float inset, out Rect result )
	{
		result = new Rect( rect.x + rect.width - inset, rect.y, inset, rect.height );

		return rect.PadRight( inset );
	}

	/// <summary>
	/// Split a Rect by insetting from the left edge.
	/// </summary>
	/// <param name="rect">Rect to split.</param>
	/// <param name="inset">Inset width.</param>
	/// <param name="result">Inset Rect.</param>
	/// <returns></returns>
	public static Rect SplitLeft ( this Rect rect, float inset, out Rect result )
	{
		result = new Rect( rect.x, rect.y, inset, rect.height );

		return rect.PadLeft( inset );
	}

	/// <summary>
	/// Split a Rect by insetting from the bottom edge.
	/// </summary>
	/// <param name="rect">Rect to split.</param>
	/// <param name="inset">Inset height.</param>
	/// <param name="result">Inset Rect.</param>
	/// <returns></returns>
	public static Rect SplitBottom ( this Rect rect, float inset, out Rect result )
	{
		result = new Rect( rect.x, rect.y + rect.height - inset, rect.width, inset );

		return rect.PadBottom( inset );
	}

	/// <summary>
	/// Split a Rect by insetting from the top edge.
	/// </summary>
	/// <param name="rect">Rect to split.</param>
	/// <param name="inset">Inset height.</param>
	/// <param name="result">Inset Rect.</param>
	/// <returns></returns>
	public static Rect SplitTop ( this Rect rect, float inset, out Rect result )
	{
		result = new Rect( rect.x, rect.y, rect.width, inset );

		return rect.PadTop( inset );
	}
	#endregion

	#region Padding
	/// <summary>
	/// Pad a Rect from all sides.
	/// </summary>
	/// <param name="rect">Rect to pad.</param>
	/// <param name="padding">Amount to pad.</param>
	/// <returns>Padded Rect.</returns>
	public static Rect Pad ( this Rect rect, float padding )
	{
		return Pad( rect, padding, padding, padding, padding );
	}

	/// <summary>
	/// Pad a Rect from its left edge.
	/// </summary>
	/// <param name="rect">Rect to pad.</param>
	/// <param name="padding">Amount to pad.</param>
	/// <returns>Padded Rect.</returns>
	public static Rect PadLeft ( this Rect rect, float padding )
	{
		return Pad( rect, padding, 0.0f, 0.0f, 0.0f );
	}

	/// <summary>
	/// Pad a Rect from its right edge.
	/// </summary>
	/// <param name="rect">Rect to pad.</param>
	/// <param name="padding">Amount to pad.</param>
	/// <returns>Padded Rect.</returns>
	public static Rect PadRight ( this Rect rect, float padding )
	{
		return Pad( rect, 0.0f, padding, 0.0f, 0.0f );
	}

	/// <summary>
	/// Pad a Rect from its top edge.
	/// </summary>
	/// <param name="rect">Rect to pad.</param>
	/// <param name="padding">Amount to pad.</param>
	/// <returns>Padded Rect.</returns>
	public static Rect PadTop ( this Rect rect, float padding )
	{
		return Pad( rect, 0.0f, 0.0f, padding, 0.0f );
	}

	/// <summary>
	/// Pad a Rect from its bottom edge.
	/// </summary>
	/// <param name="rect">Rect to pad.</param>
	/// <param name="padding">Amount to pad.</param>
	/// <returns>Padded Rect.</returns>
	public static Rect PadBottom ( this Rect rect, float padding )
	{
		return Pad( rect, 0.0f, 0.0f, 0.0f, padding );
	}

	/// <summary>
	/// Pad a Rect from its left and right edges.
	/// </summary>
	/// <param name="rect">Rect to pad.</param>
	/// <param name="padding">Amount to pad.</param>
	/// <returns>Padded Rect.</returns>
	public static Rect PadHorizontal ( this Rect rect, float padding )
	{
		return Pad( rect, padding, padding, 0.0f, 0.0f );
	}

	/// <summary>
	/// Pad a Rect from its top and bottom edges.
	/// </summary>
	/// <param name="rect">Rect to pad.</param>
	/// <param name="padding">Amount to pad.</param>
	/// <returns>Padded Rect.</returns>
	public static Rect PadVertical ( this Rect rect, float padding )
	{
		return Pad( rect, 0.0f, 0.0f, padding, padding );
	}

	/// <summary>
	/// Pad a Rect from its left, right, top, and bottom edges.
	/// </summary>
	/// <param name="rect">Rect to pad.</param>
	/// <param name="left">Amount to pad left edge.</param>
	/// <param name="right">Amount to pad left edge.</param>
	/// <param name="top">Amount to pad left edge.</param>
	/// <param name="bottom">Amount to pad left edge.</param>
	/// <returns>Padded Rect.</returns>
	public static Rect Pad ( this Rect rect, float left, float right, float top, float bottom )
	{
		return new Rect( rect.x + left, rect.y + top, rect.width - left - right, rect.height - top - bottom );
	}
	#endregion

	#region Sequencing
	public static Rect StepDown( this Rect rect, float padding = 0.0f )
	{
		return new Rect( rect.x, rect.y + rect.height + padding, rect.width, rect.height );
	}

	public static Rect StepUp ( this Rect rect, float padding = 0.0f )
	{
		return new Rect( rect.x, rect.y - rect.height - padding, rect.width, rect.height );
	}

	public static Rect StepLeft ( this Rect rect, float padding = 0.0f )
	{
		return new Rect( rect.x - rect.width - padding, rect.y, rect.width, rect.height );
	}

	public static Rect StepRight ( this Rect rect, float padding = 0.0f )
	{
		return new Rect( rect.x + rect.width + padding, rect.y, rect.width, rect.height );
	}
	#endregion

	#region Extrusions
	public static Rect ExtrudeLeft ( this Rect rect, float width )
	{
		return new Rect( rect.x - width, rect.y, width, rect.height );
	}

	public static Rect ExtrudeRight ( this Rect rect, float width )
	{
		return new Rect( rect.x + rect.width, rect.y, width, rect.height );
	}

	public static Rect ExtrudeTop ( this Rect rect, float height )
	{
		return new Rect( rect.x, rect.y - height, rect.width, height );
	}

	public static Rect ExtrudeBottom ( this Rect rect, float height )
	{
		return new Rect( rect.x, rect.y + rect.height, rect.width, height );
	}
	#endregion


	#region Backfills
	public static Rect BackfillLeft ( this Rect rect, float width )
	{
		return rect.PadRight( rect.width - width );
	}

	public static Rect BackfillRight ( this Rect rect, float width )
	{
		return rect.PadLeft( rect.width - width );
	}

	public static Rect BackfillTop ( this Rect rect, float height )
	{
		return rect.PadBottom( rect.height - height );
	}

	public static Rect BackfillBottom ( this Rect rect, float height )
	{
		return rect.PadTop( rect.height - height );
	}
	#endregion

	#region Events
	public static bool WasContextClicked ( this Rect rect, int contextButton = 1, bool useEvent = true )
	{
		if ( Event.current.IsContextClick( contextButton ) && rect.Contains( Event.current.mousePosition ) )
		{
			if ( useEvent )
			{
				Event.current.Use();
			}

			return true;
		}

		return false;
	}

	public static bool WasLeftClicked ( this Rect rect, bool useEvent = true )
	{
		if ( Event.current.IsLeftClick() && rect.Contains( Event.current.mousePosition ) )
		{
			if ( useEvent )
			{
				Event.current.Use();
			}

			return true;
		}

		return false;
	}
	public static bool WasDragged( this Rect rect, int dragButton = 0, bool useEvent = true )
	{
		if ( Event.current.IsDrag( dragButton ) && rect.Contains( Event.current.mousePosition ) )
		{
			if ( useEvent )
			{
				Event.current.Use();
			}

			return true;
		}

		return false;
	}
	#endregion
}

