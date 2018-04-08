using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ArrayExtensions
{
	public static T[] Resized<T> ( this T[] array, int length, bool returnCopyIfSameLength = false )
	{
		if ( array.Length > length )
		{
			var temp = new T[length];

			for ( int i = 0; i < length; i++ )
			{
				temp[i] = array[i];
			}

			array = temp;
		}
		else if ( array.Length < length )
		{
			var temp = new T[length];

			for ( int i = 0; i < array.Length; i++ )
			{
				temp[i] = array[i];
			}

			array = temp;
		}
		else if ( returnCopyIfSameLength )
		{
			var temp = new T[length];

			for ( int i = 0; i < length; i++ )
			{
				temp[i] = array[i];
			}

			array = temp;
		}

		return array;
	}
}
