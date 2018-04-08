using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Probability
{
	[HideInInspector]
	public int n;

	public int observations;
	public float probability;

	public void Compute ( string input, List<string> samples, int n, System.Func<string,int> f)
	{
		this.n = n;
		observations = 0;

		for ( int i = 0; i < samples.Count; i++ )
		{
			observations += f( samples[i] );
		}

		probability = observations / (float) n;
	}
}

[System.Serializable]
public class ShuffleResults
{
	[Tooltip( "Condition: a value preceded a value that it preceded in the input." )]
	public Probability orderedPair;

	[Tooltip( "Condition: the last value in the input became the first value in the output." )]
	public Probability lastToFirst;

	[Tooltip( "Condition: a value's output index was the same as its input index." )]
	public Probability indexContinuity;

	public List<string> samples;

	public void Compute ( string input, List<char> buffer, System.Action<IList<char>,int,bool> shuffle, int iterations, bool guaranteeDiscontinuity, int shuffles )
	{
		samples.Clear();
		samples.Capacity = shuffles;

		for ( int i = 0; i < shuffles; i++ )
		{
			buffer.Clear();
			buffer.AddRange( input );
			shuffle( buffer, iterations, guaranteeDiscontinuity );
			samples.Add( buffer.ToConcatenatedString() );
		}

		orderedPair.Compute( input, samples, shuffles * (input.Length - 1), s =>
		{
			var observations = 0;

			for ( int i = 1; i < input.Length; i++ )
			{
				if ( s[i] - s[i - 1] == 1 )
				{
					observations++;
				}
			}

			return observations;
		} );

		lastToFirst.Compute( input, samples, shuffles, s =>
		{
			return s[0] == input[input.Length - 1] ? 1 : 0;
		} );

		indexContinuity.Compute( input, samples, shuffles * input.Length, s =>
		{
			var observations = 0;

			for ( int i = 0; i < input.Length; i++ )
			{
				if ( input.IndexOf( s[i] ) == i )
				{
					observations++;
				}
			}

			return observations;
		} );
	}
}

public class TestShuffles : MonoBehaviour
{
	public string input = "0123456789";
	public int iterations = 1;
	public bool guaranteeDiscontinuity = false;
	public int shuffles = 10;
	
	[Space]

	[ReadOnly]
	public ShuffleResults ascending = new ShuffleResults();

	[ReadOnly]
	public ShuffleResults descending = new ShuffleResults();

	[ReadOnly]
	public ShuffleResults ascendingForward = new ShuffleResults();

	[ReadOnly]
	public ShuffleResults descendingReverse = new ShuffleResults();

	[Button]
	public void Test ()
	{
		var buffer = new List<char>( input.Length );

		ascending.Compute( input, buffer, ListExtensions.AscendingShuffle, iterations, guaranteeDiscontinuity, shuffles );
		descending.Compute( input, buffer, ListExtensions.DescendingShuffle, iterations, guaranteeDiscontinuity, shuffles );
		ascendingForward.Compute( input, buffer, ListExtensions.AscendingForwardSuffle, iterations, guaranteeDiscontinuity, shuffles );
		descendingReverse.Compute( input, buffer, ListExtensions.DescendingReverseShuffle, iterations, guaranteeDiscontinuity, shuffles );
	}
}
