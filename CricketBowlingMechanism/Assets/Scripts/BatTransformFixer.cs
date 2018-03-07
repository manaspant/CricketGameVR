using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTransformFixer : MonoBehaviour {

	GameObject bat;

	// Use this for initialization
	void Start () {
		bat = GameObject.FindGameObjectWithTag ("cricketBat");
		bat.transform.localPosition = transform.position;
		bat.transform.localRotation = transform.localRotation;
	}


}
