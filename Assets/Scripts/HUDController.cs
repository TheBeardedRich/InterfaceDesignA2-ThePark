using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class HUDController : MonoBehaviour {

	public GameObject playersound;


	//Stars
	public Text starcountText;
	private int starcount;
	private int scorestar;

	//Diamonds
	public Text diamondcountText;
	private int diamondcount;
	private int scorediamond;


	//Hearts
	public Text heartcountText;
	private int heartcount;
	private int scoreheart;

	//Areas
	private int areacount;
	private int scorearea;
	public Text picnicareaText;
	public Text housesareaText;
	public Text pierareaText;
	public Text reserveareaText;
	public Text fountainareaText;



	//Score
	public Text scoretotalText;
	private int sum;


	//Pickup Score
	public Text pickupText;
	private int pickupscore;



	//HealthBar
	public Image healthbar;








	// Use this for initialization
	void Start () {

		starcount = 0;
		scorestar = 0;

		diamondcount = 0;
		scorediamond = 0;

		heartcount = 0;
		scoreheart = 0;

		areacount = 0;
		scorearea = 0;

		pickupscore = 0;



	}
	
	// Update is called once per frame
	void Update () {

		healthbar.fillAmount -= 0.02f * Time.deltaTime;
		if (healthbar.fillAmount < 0.035f) {
			//Save the player's score
			PlayerPrefs.SetInt ("Player Score", sum);
			//load next scene in build array
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}




	}

	public void IncrementStarCount() {

		starcount++;
		scorestar += 10 * starcount;
		starcountText.text = starcount.ToString ();

	}

	public void IncrementDiamondCount() {

		diamondcount++;
		scorediamond += 10 * diamondcount;
		diamondcountText.text = diamondcount.ToString ();

	}



	public void IncrementHeartCount() {

		heartcount++;
		scoreheart += 10 * heartcount;
		heartcountText.text = heartcount.ToString ();

	}

	public void IncrementAreaCount() {

		areacount++;
		scorearea += 100 * areacount;

	}

	//When pick up is chosen, either add 50 or remove 50 from points
	public void IncrementPickUp()
	{
		if (Random.value < 0.5f) {
			pickupscore += 50;
			pickupText.text = "Congratulations!";
			Destroy (pickupText, 4);

		} else {
			pickupscore -= 50;
			pickupText.text = "Better luck next time!";
			Destroy (pickupText, 4);

		}

	}


	public void IncrementScoreTotal() {

		//Score total is sum of all collectables - amount of steps taken by the player and cannot be lower than 0
		sum =  + scoreheart + scorediamond + scorestar + scorearea + pickupscore - playersound.GetComponent<PlayerSound> ().footstepcount;
		scoretotalText.text = "" + Mathf.Clamp(sum, 0, 5000);



	}

	public void VisitedPicnicArea() {
		picnicareaText.text = "Visited - Picnic Area";
	}
	public void VisitedHousesArea() {
		housesareaText.text = "Visited - Houses";
	}
	public void VisitedPierArea() {
		pierareaText.text = "Visited - The Pier";
	}
	public void VisitedReserveArea() {
		reserveareaText.text = "Visited - Nature Reserve";
	}
	public void VisitedFountainsArea() {
		fountainareaText.text = "Visited - The Fountains";
	}





}
