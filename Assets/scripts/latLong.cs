using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class latLong : MonoBehaviour {
	public GameObject sphere;
	public double lat;
	public double longi;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		double longitude = ((longi-18.06324)/0.703)*64;
		double latitude = ((lat-59.33459)/0.703)*128;
		sphere.transform.position = new Vector3((float)longitude,5,(float)latitude);
	}
}


