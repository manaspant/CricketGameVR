using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip threeRow, fourRow, fiveRow, crickGod, duck, four, gameover, getReadyHigh, getReadyLow, getWrecked, goldenDuck, over, perfOver, six, unstoppable, youreout;
	Dictionary<string, AudioClip> audios = new Dictionary<string, AudioClip> ();

	// Use this for initialization
	void Start () {
		


		audios.Add ("3inARow", threeRow);
		audios.Add ("4inARow", fourRow);
		audios.Add ("5inARow", fiveRow);
		audios.Add ("CricketGod", crickGod);
		audios.Add ("Duck", duck);
		audios.Add ("FourRuns", four);
		audios.Add ("GameOver", gameover);
		audios.Add ("GetReadyHigh", getReadyHigh);
		audios.Add ("GetReadyLow", getReadyLow);
		audios.Add ("GetWrecked", getWrecked);
		audios.Add ("GoldenDuck", goldenDuck);
		audios.Add ("Over", over);
		audios.Add ("PerfectOver", perfOver);
		audios.Add ("SixRuns", six);
		audios.Add ("Unstoppable", unstoppable);
		audios.Add ("Youreout", youreout);

		playSound ("Youreout");
	}

	public void playSound(string fileName){
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = audios[fileName];
		audio.Play ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
