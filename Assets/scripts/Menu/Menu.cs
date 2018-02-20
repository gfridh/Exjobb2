using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
	public float radiusX = 0.0f;
	public float radiusY = 0.0f;
	public GameObject innerCircleButton;

	// Use this for initialization
	void Start () {
		var numPoints = 4;
		var centrePos = new Vector3(0,0,0);
		


		for (var pointNum = 0; pointNum < numPoints; pointNum++)
		{


		// "i" now represents the progress around the circle from 0-1
		// we multiply by 1.0 to ensure we get a fraction as a result.
/* 		var i = (pointNum * 1.0) / numPoints;
		// get the angle for this step (in radians, not degrees)
		var angle = i * Mathf.PI * 2;
		// the X &amp; Y position for this angle are calculated using Sin &amp; Cos
		var x = Mathf.Sin((float)angle) * radiusX;
		var y = Mathf.Cos((float)angle) * radiusY;
		var pos = new Vector3(x, y, 0) + centrePos; */
		// no need to assign the instance to a variable unless you're using it afterwards:
		Instantiate (innerCircleButton, new Vector3(0,0,0),  Quaternion.Euler(new Vector3(pointNum*90,90 , 90)));
				
			}
	
	// Update is called once per frame
	}
			void Update () {
		
	}
}
