using UnityEngine;
using System.Collections;

public class AudioWallSplat : MonoBehaviour
{

	public AudioClip wallSplat;
	AudioSource audio;
	// Use this for initialization
	void Start ()
	{
		audio = GetComponent<AudioSource> ();
		audio.clip = wallSplat;
	}

	void OnCollisionEnter(){
		audio.Play ();
	}
}

