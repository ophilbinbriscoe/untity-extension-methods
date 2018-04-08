using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using UnityEngine;

/// <summary>
/// Utility extensions for manipulating enumerators.
/// </summary>
public static class EnumeratorExtensions
{
	/// <summary>
	/// Call MoveNext() until the enumerator has been exhausted.
	/// </summary>
	public static void Auto ( this IEnumerator enumerator )
	{
		while ( enumerator.MoveNext() )
			;
	}
}
