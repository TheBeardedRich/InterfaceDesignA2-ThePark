using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSound : MonoBehaviour {

	public AudioClip footStep;

	public AudioSource audioS;

	public Text footstepcountText;
	public int footstepcount;


	// Use this for initialization
	public void Start () {

		footstepcount = 0;

	}
	
	// Update is called once per frame
	public void Update () {
		
	}

	public void Footstep()
	{
		audioS.PlayOneShot (footStep);
		footstepcount++;
		footstepcountText.text = footstepcount.ToString ();
	}
		

}
