using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public GameObject HUDctrl;
	public GameObject popupmenuUI;

	public Camera cam;
	public NavMeshAgent agent;
	RaycastHit hit;

	Animator myAnim;
	float dist = 0;

	Quaternion newRotation;
	public float rotSpeed = 5.0f;

	Quaternion savedRot;
	bool isMoving = false;

	//Popup Menu
	public static bool PopupMenuOn = false;      



	// Use this for initialization
	void Start () {

		//Access animator attached to player object
		myAnim = GetComponent<Animator> ();
		savedRot = transform.rotation;


		
	}
	
	// Update is called once per frame
	void Update () {




		//Player Movement Controlled by Left-Mouse Button

		//If Player Presses Left-Mouse Button
		if (Input.GetMouseButtonDown (0)) {

			//Generate Ray to Cast Out - Tell it to Fire from the Point of the Mouse when Left-Clicked
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		

			if (Physics.Raycast (ray, out hit)) {


				agent.SetDestination (hit.point);
				myAnim.SetBool ("isRunning", true);
				isMoving = true;
			}

		}


		//If player is moving, call these functions
		if (isMoving) {
			RotationFunction ();
			DistanceCalculation ();
		}

		//If atfer moving player tries to rotate, stick to saved rotation
		if (transform.rotation != savedRot && isMoving == false) 
		{
			transform.rotation = savedRot;
		}

	}




	void DistanceCalculation()
	{
		dist = Vector3.Distance (hit.point, transform.position);
		//Debug.Log ("Distance = " + dist);
		if (dist < 1.0f) {
			myAnim.SetBool ("isRunning", false);
			isMoving = false;
			savedRot = transform.rotation;

		}
	}

		void RotationFunction()
	{
		//Rotating Character
		Vector3 relativePos = hit.point - transform.position;
		newRotation = Quaternion.LookRotation (relativePos, Vector3.up);
		newRotation.x = 0.0f;
		newRotation.z = 0.0f;

		//deltatime normalise show fast everyone moves ragardless of system
		transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, rotSpeed * Time.deltaTime);


	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Star") {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().IncrementStarCount ();
		} else if (other.gameObject.tag == "DontPickUp") {
			other.gameObject.SetActive (false);
		}
		if (other.gameObject.tag == "Star") {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().IncrementScoreTotal ();
		} else if (other.gameObject.tag == "DontPickUp") {
			other.gameObject.SetActive (false);
		}





		if (other.gameObject.tag == "Diamond") {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().IncrementDiamondCount ();
		} else if (other.gameObject.tag == "DontPickUp") {
			other.gameObject.SetActive (false);
		}
		if (other.gameObject.tag == "Diamond") {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().IncrementScoreTotal ();
		} else if (other.gameObject.tag == "DontPickUp") {
			other.gameObject.SetActive (false);
		}



		if (other.gameObject.tag == "Heart") {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().IncrementHeartCount ();
		} else if (other.gameObject.tag == "DontPickUp") {
			other.gameObject.SetActive (false);
		}
		if (other.gameObject.tag == "Heart") {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().IncrementScoreTotal ();
		} else if (other.gameObject.tag == "DontPickUp") {
			other.gameObject.SetActive (false);
		}

	


		if (other.gameObject.tag == "Area") {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().IncrementAreaCount ();
		} else if (other.gameObject.tag == "DontPickUp") {
			other.gameObject.SetActive (false);
		}
		if (other.gameObject.tag == "Area") {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().IncrementScoreTotal ();
		} else if (other.gameObject.tag == "DontPickUp") {
			other.gameObject.SetActive (false);
		}



		if (other.gameObject.tag == "Sphere") {
			
			other.gameObject.SetActive (false);
			if (PopupMenuOn)
			{
				Close ();

			} 
			else 
			{
				Open ();

			}

		}



			








		if (other.gameObject.name.Contains ("Picnic")) {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().VisitedPicnicArea ();
		}

		if (other.gameObject.name.Contains ("House")) {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().VisitedHousesArea ();
		}
		if (other.gameObject.name.Contains ("Pier")) {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().VisitedPierArea ();
		}
		if (other.gameObject.name.Contains ("Reserve")) {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().VisitedReserveArea ();
		}
		if (other.gameObject.name.Contains ("Fountain")) {
			other.gameObject.SetActive (false);
			HUDctrl.GetComponent<HUDController> ().VisitedFountainsArea ();
		}

	}


	void Open()
	{
		popupmenuUI.SetActive(true);
		Time.timeScale = 0f;
		PopupMenuOn = true;


	}

	public void Close()
	{
		popupmenuUI.SetActive (false);
		Time.timeScale = 1f;
		PopupMenuOn = false;

	}







}




