using UnityEngine;
using System.Collections;

// Used to allow streamReader
using System.IO;

public class Username : MonoBehaviour 
{
    float fps;
	
    //bool updateColor = true;
	
	string username = "Unlinitialized";
	string UserNameFilePath
	{
		get
		{
			// Located in Users/Username/Library/Caches/DefaultCompany/Project Name/file location
			return Application.persistentDataPath + "/username.txt";	
		}
	}

	void Start()
	{
		// Used to grab the location of the username.txt file.
		// Debug.Log (Application.persistentDataPath);
		
		// Used to load a previous username or will ask for one to be created.
		try
		{
			username = File.ReadAllText(UserNameFilePath);
			
			// Version 2
			// username = File.ReadAllText(Application.persistentDataPath + "/username.txt");
			
			// Version 1
			// using (var streamReader = new StreamReader(Application.persistentDataPath + "/username.txt"))
			// {
			//	 username = streamReader.ReadToEnd().Trim();
			// }
		}
		catch(FileNotFoundException)
		{
			username = "Enter a username here";
		}
	}


	void OnGUI()
	{
		// Alligns the usename prompt in the upper-left corner
		// Username: ______ 
		GUILayout.BeginHorizontal(); 
		{
			GUILayout.Label("Username: ");
			GUI.changed = false;
			username = GUILayout.TextField(username);
			
			// FPS Counter in the upper-right corner
		    // FPS: ___
			
			// x-axis, 
			GUI.Label(new Rect(500, 10, 100, 20), "FPS: ");
			//GUI.changed = false;
			fps =  1f / Time.deltaTime;	
			//fps = GUILayout.Label(fps);
			
			if(GUI.changed)
			{
				File.WriteAllText(UserNameFilePath, username);
				
				// Version 1
				//File.WriteAllText(Application.persistentDataPath + "/username.txt", username);
			}
		} 
		GUILayout.EndHorizontal();
		
		
		
		
		
		// "Sweet" logo in the bottom-right corner
		// File from: http://octodex.github.com/stormtroopocat/
		//
	}
}