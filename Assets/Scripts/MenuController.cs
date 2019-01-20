using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public AudioSource musicSource;

	public InputField playernameInput;
	public Text playernameText;
	public int selectedPlayer;








	public void PlayGame(){

		//load next scene in build array
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);

	}



	public void RestartGame() {

		//Go back to the last scene
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 2);

	}


	public void CharacterSelect1 ()
	{
		selectedPlayer = 1;
		PlayerPrefs.SetInt ("Character Select", selectedPlayer);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);

	}
	public void CharacterSelect2 ()
	{
		selectedPlayer = 2;
		PlayerPrefs.SetInt ("Character Select", selectedPlayer);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);

	}
	public void CharacterSelect3 ()
	{
		selectedPlayer = 3;
		PlayerPrefs.SetInt ("Character Select", selectedPlayer);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);

	}




	public void QuitGame(){

		//Quit the Game
		Application.Quit();


	}

	//Play menu music in menu
	public void PlayMusic(){

		if (musicSource.isPlaying)
			musicSource.Pause ();
		else
			musicSource.Play ();

	}

	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {

		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;
		if (sceneName == "Main Menu") {

			PlayerPrefs.SetString ("Player Name", playernameInput.text);

		}


	}
}
