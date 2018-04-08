using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using UnityEngine;

/// <summary>
/// Utility extensions for formatting enumerables.
/// </summary>
public static class EnumerableExtensions
{
	public static string ToConcatenatedString ( this IEnumerable enumerable )
	{
		var builder = new StringBuilder();

		foreach ( var value in enumerable )
		{
			builder.Append( value );
		}

		return builder.ToString();
	}


	public static string ToConcatenatedString<T> ( this IEnumerable<T> enumerable, Func<T, string> toString )
	{
		var builder = new StringBuilder();

		foreach ( var value in enumerable )
		{
			builder.Append( toString( value ) );
		}

		return builder.ToString();
	}

	public static string ToSeparatedString ( this IEnumerable enumerable, char separator = ',', bool spaced = true )
	{
		var builder = new StringBuilder();

		if ( spaced )
		{
			foreach ( var value in enumerable )
			{
				builder.Append( value );
				builder.Append( ", " );
			}

			if ( builder.Length > 0 )
			{
				builder.Remove( builder.Length - 2, 2 );
			}
		}
		else
		{
			foreach ( var value in enumerable )
			{
				builder.Append( value );
				builder.Append( "," );
			}

			if ( builder.Length > 0 )
			{
				builder.Remove( builder.Length - 1, 1 );
			}
		}

		return builder.ToString();
	}

	public static string ToSeparatedString<T> ( this IEnumerable<T> enumerable, Func<T, string> toString, char separator = ',', bool spaced = true )
	{
		var builder = new StringBuilder();

		if ( spaced )
		{
			foreach ( var value in enumerable )
			{
				builder.Append( toString( value ) );
				builder.Append( ", " );
			}

			if ( builder.Length > 0 )
			{
				builder.Remove( builder.Length - 2, 2 );
			}
		}
		else
		{
			foreach ( var value in enumerable )
			{
				builder.Append( value );
				builder.Append( "," );
			}

			if ( builder.Length > 0 )
			{
				builder.Remove( builder.Length - 1, 1 );
			}
		}

		return builder.ToString();
	}
}
