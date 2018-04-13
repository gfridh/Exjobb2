using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class HouseCollider : MonoBehaviour
{
    public Material active;
    public Material unactive;
    public bool houseActive = false;
    public List<GameObject> houseHits;
    public GameObject closestHouse;
    public float maxDistance;
    public GameObject printedHouse;
    public GameObject leftController;
    // Use this for initialization
    void Start()
    {
        houseHits = new List<GameObject>();
        leftController = GameObject.FindGameObjectWithTag("controllerLeft");
        leftController.GetComponent<VRTK_ControllerEvents>().TriggerTouchStart += new ControllerInteractionEventHandler(TriggerTouched);
    }

    // Update is called once per frame
    void Update()
    {


        maxDistance = 100000;
        if (houseHits.Count > 0)
        {
            foreach (GameObject house in houseHits)
            {
                house.GetComponent<MeshRenderer>().material = unactive;
                if (Vector3.Distance(transform.position, house.transform.position) < maxDistance)
                {
                    maxDistance = Vector3.Distance(transform.position, house.transform.position);

                    closestHouse = house;

                }


            }

            closestHouse.GetComponent<MeshRenderer>().material = active;




        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "house")
        {
            houseHits.Add(other.gameObject);
            HouseCoordinates houseScript = other.GetComponent<HouseCoordinates>();
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "house")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = unactive;

            houseHits.Remove(other.gameObject);

            HouseCoordinates houseScript = other.GetComponent<HouseCoordinates>();

        }
    }

    private void TriggerTouched(object sender, ControllerInteractionEventArgs e)
    {
        if (closestHouse)
        {
            if (printedHouse && closestHouse != printedHouse)
            {
                printedHouse = closestHouse;
                HouseCoordinates houseScript = closestHouse.GetComponent<HouseCoordinates>();
                print(houseScript.rent);
            }
            else
            {
                printedHouse = closestHouse;
            }
        }

    }
}
