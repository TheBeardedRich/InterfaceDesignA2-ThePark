using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour {

	//Player's Audio Source
	private AudioSource source;



	//serializefield allows us to access private info in editor but not outside of class
	//Sound we play on collision
	[SerializeField] private AudioClip clip;

	//Creating object of script Collectables Controller inside
	CollectablesController cc;

	void Start()
	{


		//find a gameobject collectables controller copy in our hierarchy
		GameObject ccgo = GameObject.Find ("CollectablesController");
		cc = ccgo.GetComponent<CollectablesController> ();

	}

		
	void OnTriggerEnter(Collider col)
	{
		//Will acces game object this script is attatched too a recieve its name
		Debug.Log ("You Collected A " + gameObject.name);



		//retrieves audio source from player and makes source equal it
		source = col.GetComponent<AudioSource> ();
		//Plays once the audio clip and the volume
		source.PlayOneShot(clip, 1.0f);

		cc.IncrementCount (gameObject);




		//Destroy game object
		Destroy (gameObject);

	}


		
}
	