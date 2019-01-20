using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Places : MonoBehaviour {

	//Player's Audio Source
	private AudioSource source;

	//serializefield allows us to access private info in editor but not outside of class
	//Sound we play on collision
	[SerializeField] private AudioClip clip;




	void OnTriggerEnter(Collider col)
	{
		//Will acces game object this script is attatched too a recieve its name
		Debug.Log ("You Have Visisted " + gameObject.name);

		//retrieves audio source from player and makes source equal it
		source = col.GetComponent<AudioSource> ();
		//Plays once the audio clip and the volume
		source.PlayOneShot(clip, 1.0f);

		//Destroy game object
		Destroy (gameObject);

	}


}