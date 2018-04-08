using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using UnityEngine;

/// <summary>
/// Utility extensions for formatting and manipulating strings.
/// </summary>
public static class StringExtensions
{
	#region Formatting
	public static string WithLowerFirst ( this string str )
	{
		return string.IsNullOrEmpty( str ) ? str : str.Insert( 0, str.Substring( 0, 1 ).ToUpper() ).Remove( 1, 1 );
	}

	public static string WithUpperFirst ( this string str )
	{
		return string.IsNullOrEmpty( str ) ? str : str.Insert( 0, str.Substring( 0, 1 ).ToUpper() ).Remove( 1, 1 );
	}

	public static string WithoutSpaces ( this string str )
	{
		return string.IsNullOrEmpty( str ) ? str : str.Replace( " ", "" );
	}

	private static Regex lowerBeforeUpper = new Regex( @"([a-z])([A-Z])" );
	private static Regex lowerAfterUpperUpper = new Regex( @"([A-Z])([A-Z][a-z])" );
	private static Regex numberAfterLetter = new Regex( @"([a-zA-Z])([0-9])" );

	/// <summary>
	/// Adds spaces before words, where a word is taken to be any sequence of characters starting with an uppercase or any sequence of digits.
	/// </summary>
	/// <param name="str">String to format.</param>
	/// <returns>Formatted string.</returns>
	public static string WithSpacesBetweenWords ( this string str )
	{
		return numberAfterLetter.Replace( lowerAfterUpperUpper.Replace( lowerBeforeUpper.Replace( str, @"$1 $2" ), @"$1 $2" ), @"$1 $2" );
	}

	/// <summary>
	/// Format a member name to look as it would in the Unity Editor Inspector window.
	/// </summary>
	/// <param name="name">Member name.</param>
	/// <returns>Formatted name.</returns>
	public static string InspectorName ( this string name )
	{
		return name.WithSpacesBetweenWords().WithUpperFirst();
	}
	#endregion

	#region Rich Text Tags
	public static string Bold ( this string text )
	{
		return string.Format( "<b>{0}</b>", text );
	}

	public static string BoldIf ( this string text, bool condition )
	{
		return condition ? text.Bold() : text;
	}

	public static string Color ( this string text, Color color )
	{
		return string.Format( "<color=#{1}>{0}</color>", text, ColorUtility.ToHtmlStringRGBA( color ).ToLower() );
	}

	public static string ColorIf ( this string text, Color color, bool condition )
	{
		return condition ? text.Color( color ) : text;
	}

	public static string ColorIf ( this string text, Color colorIfTrue, Color colorIfFalse, bool condition )
	{
		return condition ? text.Color( colorIfTrue ) : text.Color( colorIfFalse );
	}

	public static string Size ( this string text, int size )
	{
		return string.Format( "<size={1}>{0}</size>", text, size );
	}
	#endregion
}
