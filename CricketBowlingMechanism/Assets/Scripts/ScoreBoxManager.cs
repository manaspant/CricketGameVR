﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoxManager : MonoBehaviour{

	public int runs_value;
	public float mult_value;
	bool painted;

	void Start () {
		painted = false;
	}

	public void paintWall(){
		painted = true;
	}

	public bool isPainted(){
		return painted;
	}

	public void resetWall(){
		painted = false;
	}
}
