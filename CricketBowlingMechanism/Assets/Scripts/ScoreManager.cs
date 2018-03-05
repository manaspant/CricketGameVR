﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	/*
	 * So what's a Score Manager do?
	 * Well, keeps track of the score, of course!
	 * It has to be able to respond to the following messages:
	 * -AddRuns() by a boundary or housefront collider
	 * -MultiplierWallCount() by a housefront collider
	 * -And it should have functions fulfilling the following duties:
	 * -getRuns()
	 * -setRuns()
	 * -addToRuns()
	 * 
	 * -getMultiplier()
	 * -setMultiplier()
	 * -addToMultiplier()
	 * 
	 * -getPainted()
	 * -setPainted()
	 * -addToPainted()
	 * 
	 * -GetMultedScore()
	 */


	int runs;
	float multiplier;
	int painted;
	public int fullyPaintedLimit;

	void Start () {
		setRuns (0);
		setMultiplier (1);
		setPainted (0);
	}

	void Update(){
//		Debug.Log ("Score is " + runs);
//		Debug.Log ("Multiplier is " + multiplier);
	}

	public int getRuns(){
		return runs;
	}

	void setRuns(int newruns){
		runs = newruns;
	}

	public void addToRuns(int adding_runs){
		runs += adding_runs;
	}

	public float getMultiplier(){
		return multiplier;
	}

	void setMultiplier(float new_mult){
		multiplier = new_mult;
	}

	public void addToMultiplier(float adding_mult){
		multiplier += adding_mult;
	}

	int getPainted(){
		return painted;
	}

	void setPainted(int new_painted){
		painted = new_painted;
	}

	public void addToPainted(int adding_painted){
		painted += adding_painted;
	}

	public float getMultedScore(){
		return (getMultiplier () * getRuns ());
	}
}
