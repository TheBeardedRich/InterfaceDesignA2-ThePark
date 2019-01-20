using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CollectablesController : MonoBehaviour 

{
	public CollectablesData[] cd;


	void Awake()
	{
		//When we load up a scene and move to another scene, it doesnt dstroy
		DontDestroyOnLoad (gameObject);


		if (FindObjectsOfType (GetType ()).Length > 1) 
		{
			//When we load up a scene and move to another scene, it doesnt dstroy
			Destroy(gameObject);

		}
	}


	void Update()
	{
		//Press L to Load
		if (Input.GetKeyDown ("l")) {
			Debug.Log ("Loading");
			LoadData ();
		//Press S to Save
		} else if (Input.GetKeyDown ("s")) {
			Debug.Log ("Saving");
			SaveData ();
		}
	}

	//When we collect a collectable
	public void IncrementCount(GameObject go)
	{
		//if the name contrains at least these characters, its true
		if (go.name.Contains ("Heart")) {
			//cd is accessing the array - hearts are 0 and we add 1 to that number
			cd [0].CollectableNum++;
		} else if (go.name.Contains ("Star")) {
			cd [1].CollectableNum++;
		} else if (go.name.Contains ("Diamond")) {
			cd [2].CollectableNum++;
		} else if (go.name.Contains ("Sphere")) {
			cd [3].CollectableNum++;
		}
	}



	void OutputCounts()
	{
		//Display how many of each collectable is collected
		Debug.Log ("You've Collected: ");
		Debug.Log ("Hearts = " + cd [0].CollectableNum);
		Debug.Log ("Stars = " + cd [1].CollectableNum);
		Debug.Log ("Diamonds = " + cd [2].CollectableNum);
		Debug.Log ("Sphere = " + cd [3].CollectableNum);
	}


	//Saving the game	
	public void SaveData()
	{
		//Creating a new binary formatter object
		BinaryFormatter bf = new BinaryFormatter ();
		//Open up file stream - create our own file (don't need a new one, just overwrites when saved)
		FileStream fs = File.Create(Application.persistentDataPath + "/gameData.dat");
		//Take a file and information - converts info into encrypted binary format and then saves the information
		//fs is our file stream, cd(array) is our information)
		bf.Serialize(fs, cd);
		//Close the file
		fs.Close ();
		//Save
		Debug.Log ("Save Data");
	}


	public void LoadData()
	{
		//check the file exists
		if (File.Exists (Application.persistentDataPath + "/gameData.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			//Open the file
			FileStream fs = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);
			//cast information - Unencrypt the saved data
			cd = (CollectablesData[])bf.Deserialize(fs);
			//Close file when finished using it
			fs.Close ();
			//Load
			Debug.Log ("Loading Data");
		}

		else 
		{

			Debug.LogError (" File you are trying to load does not exist ");
	    }

}
}
