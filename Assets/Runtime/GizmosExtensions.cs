using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class MoreGizmos
{
#if UNITY_EDITOR
	[InitializeOnLoadMethod]
	private static void Initialize ()
	{
		SceneView.onSceneGUIDelegate += OnSceneGUI;
	}

	private static void OnSceneGUI ( SceneView sceneView )
	{
		Matrix4x4 matrix = Handles.matrix;
		Color color = Handles.color;

		foreach ( var command in commands )
		{
			try
			{
				command.Execute();
			}
			catch ( Exception e )
			{
				Debug.LogException( e, command.context );
			}
		}

		Handles.color = color;
		Handles.matrix = matrix;

		commands.Clear();
	}
#endif

	private abstract class Command
	{
		public Color color;
		public Matrix4x4 matrix;
		public UnityEngine.Object context;

		protected Command ( UnityEngine.Object context )
		{
			this.context = context;

			color = Gizmos.color;
			matrix = Gizmos.matrix;
		}

		public void Execute ()
		{
#if UNITY_EDITOR
			Handles.matrix = matrix;
			Handles.color = color;

			Draw();
#endif
		}

		protected abstract void Draw ();
	}

	private class Label : Command
	{
		public Vector3 position;
		public GUIContent content;
		public GUIStyle style;

		public Label ( Vector3 position, GUIContent content, GUIStyle style, UnityEngine.Object context ) : base( context )
		{
			this.position = position;
			this.content = content;
			this.style = style;
		}

		protected override void Draw ()
		{
#if UNITY_EDITOR
			Handles.BeginGUI();

			if ( style == null )
			{
				Handles.Label( position, content );
			}
			else
			{
				Handles.Label( position, content, style );
			}

			Handles.EndGUI();
#endif
		}
	}

	private class Disc : Command
	{
		public Vector3 center, normal;
		public float radius;

		public Disc ( Vector3 center, Vector3 normal, float radius, UnityEngine.Object context ) : base( context )
		{
			this.center = center;
			this.normal = normal;
			this.radius = radius;
		}

		protected override void Draw ()
		{
#if UNITY_EDITOR
			Handles.DrawWireDisc( center, normal, radius );
#endif
		}
	}

	private static Queue<Command> commands = new Queue<Command>( 128 );

	public static bool IsEmpty
	{
		get
		{
			return commands.Count == 0;
		}
	}
	

	public static void DrawLabel ( Vector3 position, string text, GUIStyle style = null, UnityEngine.Object context = null )
	{
		DrawLabel( position, new GUIContent( text ), style );
	}

	public static void DrawLabel ( Vector3 position, GUIContent content, GUIStyle style = null, UnityEngine.Object context = null )
	{
		commands.Enqueue( new Label( position, content, style, context ) );
	}

	public static void DrawWireDisc ( Vector3 center, Vector3 normal, float radius, UnityEngine.Object context = null )
	{
		commands.Enqueue( new Disc( center, normal, radius, context ) );
	}
}
