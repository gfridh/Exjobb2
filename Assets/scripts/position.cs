using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position : MonoBehaviour {
	public float middleLongitude = -89.08805f;
	public float middleLatitude = 30.6393f;
	public int zoom = 8;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
		float lon_rad = middleLongitude*Mathf.Deg2Rad;
		float lat_rad = middleLatitude*Mathf.Deg2Rad;
		float n = Mathf.Pow(2, zoom);
		float tileX = ((middleLongitude + 180) / 360) * n;
		float firstArg = Mathf.Tan(lat_rad);
		float secondArg = 1.0f/Mathf.Cos((float)lat_rad);
		float tileY =n * (1-(Mathf.Log(Mathf.Tan(lat_rad)+(1/Mathf.Cos(lat_rad)),2.71828f)/Mathf.PI))/2;
/* 		print(tileX);
		print(tileY); */
		
	}
}
