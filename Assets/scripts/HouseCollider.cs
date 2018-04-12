using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCollider : MonoBehaviour {
    public Material active;
    public Material unactive;
    public bool houseActive = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "house" && houseActive == false)
        {
            HouseCoordinates houseScript = other.GetComponent<HouseCoordinates>();
            if (houseScript.currentActiveHouse != "yes")
            {
                print("rent: " + houseScript.rent);
                other.GetComponent<MeshRenderer>().material = active;

                houseScript.currentActiveHouse = "yes";
                houseActive = true;
            }

        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "house" && houseActive == true)
        {
            HouseCoordinates houseScript = other.GetComponent<HouseCoordinates>();
            if (houseScript.currentActiveHouse == "yes")
            {
                houseScript.currentActiveHouse = "no";
                other.GetComponent<MeshRenderer>().material = unactive;
                houseActive = false;

            }

        }
    }
}
