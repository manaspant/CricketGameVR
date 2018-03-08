using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

	public Text text;
	private Text score;
	private Text overs;
	private Text ballsRemaining;
	private int runs;
	GameObject scoreman;
	// Use this for initialization
	void Start () {
		scoreman = GameObject.Find("ScoreManager");
		runs = scoreman.GetComponent<ScoreManager> ().getRuns ();
		text = this.gameObject.GetComponent<Text> ();
		SetText ();

	}
	
	// Update is called once per frame
	void Update () {
		SetText ();
	}

	void SetText(){
		score.text = "Score: " + runs.ToString();
		text.text = score.text;

	}
}
