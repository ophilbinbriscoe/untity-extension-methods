using System;
using System.Linq;
using System.Text;

using UnityEngine;

/// <summary>
/// Utility extensions for Colors.
/// </summary>
public static class ColorExtensions
{
	public static Color SetR ( this Color c, float r )
	{
		return new Color( r, c.g, c.b, c.a );
	}

	public static Color SetG ( this Color c, float g )
	{
		return new Color( c.r, g, c.b, c.a );
	}

	public static Color SetB ( this Color c, float b )
	{
		return new Color( c.r, c.g, b, c.a );
	}

	public static Color SetA ( this Color c, float a )
	{
		return new Color( c.r, c.g, c.b, a );
	}
}

