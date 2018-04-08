using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ObjectExtensions
{
	public static bool NullSafeEquals ( this object a, object other )
	{
		return (a == null && other == null) || a.Equals( other );
	}
}