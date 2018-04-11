using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCollider : MonoBehaviour {
    public Material active;
    public Material unactive;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    void OnTriggerEnter(Collider other)
    {
        print("other.tag");
        if (other.tag == "houseMarker")
        {
            GetComponent<MeshRenderer>().material = active;

        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "houseMarker")
        {
            GetComponent<MeshRenderer>().material = unactive;

        }
    }
}
