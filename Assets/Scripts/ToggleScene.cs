using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleScene : MonoBehaviour {

	
	// Update is called once per frame
	void Update () 
	{
		//if we press the space bar
		if (Input.GetKeyDown("space"))
		{
			//If current active scene build index is = to 0 then change to second scene
			if (SceneManager.GetActiveScene ().buildIndex == 0)
			{
				SceneManager.LoadScene (1);
				//else go back to first scene
			} 

			else
				SceneManager.LoadScene (0);
	    }
}
}
