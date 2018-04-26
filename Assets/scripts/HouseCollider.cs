using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class HouseCollider : MonoBehaviour
{
    public Material active;
    public Material unactive;
    public Material hovered;
    public bool houseActive = false;
    public List<GameObject> houseHits;
    public GameObject closestHouse;
    public float maxDistance;
    public GameObject printedHouse;
    public GameObject leftController;
    public GameObject dataloggerHolder;
    private DataLogger dataloggerScript;
    // Use this for initialization
    void Start()
    {
        houseHits = new List<GameObject>();
        leftController = GameObject.FindGameObjectWithTag("controllerLeft");
        leftController.GetComponent<VRTK_ControllerEvents>().TriggerTouchStart += new ControllerInteractionEventHandler(TriggerTouched);
        dataloggerScript = GameObject.Find("DataLogger").GetComponent<DataLogger>();
    }

    // Update is called once per frame
    void Update()
    {


        maxDistance = 100000;
        if (houseHits.Count > 0)
        {
            foreach (GameObject house in houseHits)
            {
                if (house != printedHouse)
                {
                    house.GetComponent<MeshRenderer>().material = unactive;
                }

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

        if (other.tag == "house" && other.gameObject != printedHouse)
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
            dataloggerScript.leftTrigger++;
            if (printedHouse && closestHouse != printedHouse)
            {
                printedHouse.GetComponent<MeshRenderer>().material = unactive;
                printedHouse.transform.localScale = new Vector3(printedHouse.transform.localScale.x / 3, printedHouse.transform.localScale.y/0.8f, printedHouse.transform.localScale.z / 3);
                printedHouse = closestHouse;
                printedHouse.GetComponent<MeshRenderer>().material = active;
                printedHouse.transform.localScale = new Vector3(printedHouse.transform.localScale.x*3, printedHouse.transform.localScale.y*0.8f , printedHouse.transform.localScale.z*3);

                HouseCoordinates houseScript = closestHouse.GetComponent<HouseCoordinates>();
                //print(houseScript.rent);
            }
            else if(!printedHouse)
            {
                printedHouse = closestHouse;
                printedHouse.GetComponent<MeshRenderer>().material = active;
                printedHouse.transform.localScale = new Vector3(printedHouse.transform.localScale.x * 3, printedHouse.transform.localScale.y*0.8f , printedHouse.transform.localScale.z * 3);
            }
        }

    }
}
