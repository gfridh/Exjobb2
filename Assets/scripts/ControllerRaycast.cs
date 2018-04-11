using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRaycast : MonoBehaviour {
    public LineRenderer raycastLine;
    public GameObject houseMarker;
	// Use this for initialization
	void Start () {
        raycastLine.positionCount = 2;
        raycastLine.material = new Material(Shader.Find("Particles/Multiply"));
        raycastLine.SetColors(Color.blue, Color.blue);
        raycastLine = Instantiate(raycastLine);
        houseMarker = Instantiate(houseMarker);
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
            if (hit.transform.tag == "Map" || hit.transform.tag == "houseMarker" || hit.transform.tag == "house")
            {
                {
                    houseMarker.transform.position = new Vector3(hit.point.x, hit.point.y, 150);
                    print("hit");
                    raycastLine.SetPosition(0, this.transform.position);
                    raycastLine.SetPosition(1, hit.point);
                }
            }



    }
}
