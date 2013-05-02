using UnityEditor;
using UnityEngine;

public class MyEditor : EditorWindow
{
	/*
	string myString = "Hello World";
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;
	*/

	// Add menu item named "Tools" Containing a option called "Set Mass" to the program menu
	[MenuItem("Tools / Set Mass")]
	static void SetMass()
	{	
		float magnitude = 10f;
		
		Debug.Log ("Setting Mass");
		
		GameObject[] obj = Selection.gameObjects;
		foreach(GameObject o in obj)
		{
			// 
			if(o.renderer == null)
			{
				continue;
			}
			else
			{
				// need to check to see if the selected object has a 
				// rigidbody.
				if(o.rigidbody == null)
				{
					// creates a rigidbody
					o.AddComponent<Rigidbody>();
				}
					// then sets the magnitude = to mass
					o.rigidbody.mass = magnitude;
			}
		}
	}
	
	/*
	static void Init()
	{
		// Get existing open window or if none, make a new one:
		MyEditor editor = (MyEditor)EditorWindow.GetWindow(typeof (MyEditor));
	}
	
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(MyEditor));
	}

	void OnGUI()
	{
		GUILayout.Label ("Selection", EditorStyles.boldLabel);
		myString = EditorGUILayout.TextField ("Text Field", myString);

		groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
			myBool = EditorGUILayout.Toggle ("Toggle", myBool);
			myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup ();
	}
	*/
}