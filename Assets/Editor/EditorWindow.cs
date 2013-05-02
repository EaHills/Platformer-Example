using UnityEditor;
using UnityEngine;

public class MyEditor : EditorWindow
{
	string myString = "Hello World";
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;

	// Add menu item named "My Editor" to the Window menu
	[MenuItem("Tools/ Set Mass")]
	static void SetMass()
	{
		Debug.Log ("Setting Mass");
	}
	
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
}