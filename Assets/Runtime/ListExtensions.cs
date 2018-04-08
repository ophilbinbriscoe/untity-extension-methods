using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Utility extensions for querying and modifying lists.
/// </summary>
public static class ListExtensions
{
	public static T GetRandomItem<T> ( this IList<T> list )
	{
		if ( list.Count == 0 )
		{
			Debug.LogException( new System.InvalidOperationException( "List was empty." ) );

			return default( T );
		}

		return list[Random.Range( 0, list.Count )];
	}

	public static void AscendingShuffle<T> ( this IList<T> list, int iterations = 1, bool guaranteeDiscontinuity = false )
	{
		int n = list.Count * iterations;

		T last = list.Last();

		for ( int i = 0; i < n; i++ )
		{
			for ( int j = 0; j < list.Count; j++ )
			{
				list.Swap( j, Random.Range( 0, list.Count ) );
			}
		}

		if ( guaranteeDiscontinuity && list[0].NullSafeEquals( last ) )
		{
			list.Swap( 0, list.Count - 1 );
		}
	}

	public static void AscendingForwardSuffle<T> ( this IList<T> list, int iterations = 1, bool guaranteeDiscontinuity = false )
	{
		int n = list.Count * iterations;

		T last = list.Last();

		for ( int i = 0; i < n; i++ )
		{
			for ( int j = 0; j < list.Count - 1; j++ )
			{
				list.Swap( j, Random.Range( j + 1, list.Count ) );
			}
		}

		if ( guaranteeDiscontinuity && list[0].NullSafeEquals( last ) )
		{
			list.Swap( 0, list.Count - 1 );
		}
	}

	public static void DescendingShuffle<T> ( this IList<T> list, int iterations = 1, bool guaranteeDiscontinuity = false )
	{
		int n = list.Count * iterations;

		T last = list.Last();

		for ( int i = 0; i < n; i++ )
		{
			for ( int j = list.Count - 1; j >= 0; j-- )
			{
				list.Swap( j, Random.Range( 0, list.Count ) );
			}
		}

		if ( guaranteeDiscontinuity && list[0].NullSafeEquals( last ) )
		{
			list.Swap( 0, list.Count - 1 );
		}
	}

	public static void DescendingReverseShuffle<T> ( this IList<T> list, int iterations = 1, bool guaranteeDiscontinuity = false )
	{
		int n = list.Count * iterations;

		T last = list.Last();

		for ( int i = 0; i < n; i++ )
		{
			for ( int j = list.Count - 1; j >= 1; j-- )
			{
				list.Swap( j, Random.Range( 0, j - 1 ) );
			}
		}

		if ( guaranteeDiscontinuity && list[0].NullSafeEquals( last ) )
		{
			list.Swap( 0, list.Count - 1 );
		}
	}

	public static void Swap<T> ( this IList<T> list, int a, int b )
	{
		T temp = list[a];
		list[a] = list[b];
		list[b] = temp;
	}

	public static int[] ArrayOfIndices ( int length )
	{
		if ( length < 0 )
		{
			Debug.LogException( new System.ArgumentException( "Length cannot be negative." ) );

			return null;
		}

		int[] arr = new int[length];

		for ( int i = 0; i < length; i++ )
		{
			arr[i] = i;
		}

		return arr;
	}

	public static void FillSelfWithIndices ( this IList<int> list )
	{
		for ( int i = 0; i < list.Count; i++ )
		{
			list[i] = i;
		}
	}

	public static void FillOtherWithIndices<T> ( this IList<T> list, IList<int> other )
	{
		if ( other.Count != list.Count )
		{
			Debug.LogException( new System.Exception( "Source and destination lists must have same Count." ) );

			return;
		}

		for ( int i = 0; i < list.Count; i++ )
		{
			other[i] = i;
		}
	}

	public static int[] GetArrayOfIndices<T> ( this T[] array )
	{
		return ArrayOfIndices( array.Length );
	}

	public static int[] GetArrayOfIndices ( this IList list )
	{
		return ArrayOfIndices( list.Count );
	}
}