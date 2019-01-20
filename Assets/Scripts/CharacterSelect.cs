using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {

	public int selectedPlayer;
	public GameObject Player1;
	public GameObject Player2;
	public GameObject Player3;


	// Use this for initialization
	void Start () {

		//Get character select value
		selectedPlayer = PlayerPrefs.GetInt("Character Select", selectedPlayer);

		if (selectedPlayer == 1){

			Player1.SetActive (true);
			Player2.SetActive (false);
			Player3.SetActive (false);

		}

		if (selectedPlayer == 2){

			Player2.SetActive (true);
			Player1.SetActive (false);
			Player3.SetActive (false);


		}

		if (selectedPlayer == 3){

			Player3.SetActive (true);
			Player2.SetActive (false);
			Player1.SetActive (false);

		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
