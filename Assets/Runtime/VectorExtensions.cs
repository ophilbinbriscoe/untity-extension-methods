using System;
using System.Linq;
using System.Text;

using UnityEngine;

/// <summary>
/// Utility extensions for manipulating Vector2/3/4.
/// </summary>
public static class VectorExtensions
{
	public static Vector3 InPlaneXY ( this Vector2 v )
	{
		return new Vector3( v.x, v.y );
	}

	public static Vector3 InPlaneXZ ( this Vector2 v )
	{
		return new Vector3( v.x, 0f, v.y );
	}

	public static Vector3 InPlaneYZ ( this Vector2 v )
	{
		return new Vector3( 0f, v.x, v.y );
	}

	public static Vector3 FlattenX ( this Vector3 v )
	{
		return new Vector3( 0f, v.y, v.z );
	}

	public static Vector3 FlattenY ( this Vector3 v )
	{
		return new Vector3( v.x, 0f, v.z );
	}

	public static Vector3 FlattenZ ( this Vector3 v )
	{
		return new Vector3( v.x, v.y, 0f );
	}

	public static Vector3 SetX ( this Vector3 v, float x )
	{
		return new Vector3( x, v.y, v.z );
	}

	public static Vector3 SetY ( this Vector3 v, float y )
	{
		return new Vector3( v.x, y, v.z );
	}

	public static Vector3 SetZ ( this Vector3 v, float z )
	{
		return new Vector3( v.x, v.y, z );
	}

	public static Vector3 Abs ( this Vector3 v )
	{
		return new Vector3( Mathf.Abs( v.x ), Mathf.Abs( v.y ), Mathf.Abs( v.z ) );
	}

	public static float Max ( this Vector3 v )
	{
		var a = (v.x > v.y ? v.x : v.y);

		return a > v.z ? a : v.z;
	}

	public static float Min ( this Vector3 v )
	{
		var a = (v.x < v.y ? v.x : v.y);

		return a < v.z ? a : v.z;
	}
}

