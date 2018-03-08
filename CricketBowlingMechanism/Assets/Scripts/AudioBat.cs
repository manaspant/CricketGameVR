using UnityEngine;
using System.Collections;

public class AudioBat : MonoBehaviour
{

	public AudioClip batSound;
	AudioSource audio; 
	// Use this for initialization
	void Start ()
	{
		audio = GetComponent<AudioSource> ();
		audio.clip = batSound;
	}
	
	void OnCollisionEnter(){
		audio.Play ();
	}
}

