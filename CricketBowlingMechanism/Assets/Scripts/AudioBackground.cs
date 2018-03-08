using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : MonoBehaviour {

	public AudioClip bgMusic;

	// Use this for initialization
	void Awake () {

		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = bgMusic;
		audio.Play ();

	}
		
}
