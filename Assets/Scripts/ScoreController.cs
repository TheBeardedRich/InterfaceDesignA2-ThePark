using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour {

	public int score = 0;
	public Text scoreText;
	public string currentname;
	public Text currentnameText;
	public int highscore = 0;
	public Text highscoreText;
	public string highscorename;
	public Text highscorenameText;





	// Use this for initialization
	void Start () {

		//Get the player''s name and score to display on the end menu
		score = PlayerPrefs.GetInt ("Player Score", 0);
		currentname = PlayerPrefs.GetString ("Player Name", currentname);
		//Get the highscore to display on the end menu
		highscore = PlayerPrefs.GetInt ("High Score", highscore);
		//Get the highscore name to display on the end menu
		highscorename = PlayerPrefs.GetString("High Score Name", highscorename);




	}
	
	// Update is called once per frame
	void Update () {

		//Display scores and names in text boxes
		scoreText.text = score.ToString();
		currentnameText.text = currentname.ToString ();
		highscoreText.text = highscore.ToString ();
		highscorenameText.text = highscorename.ToString ();

		//If the player's current score is higher than the saved high score
		if (score > highscore) {

			//Highscore becomes the current score
			highscore = score;
			highscorename = currentname;

			//Set new Highscore as the saved highscore
			PlayerPrefs.SetInt ("High Score", highscore);
			PlayerPrefs.SetString ("High Score Name", currentname);

		}



	}
}
