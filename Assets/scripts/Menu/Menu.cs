using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Menu : MonoBehaviour
{
    private GameObject bigInterval;
    private bool leftmenuActive = false;
    private bool rightmenuActive = false;

    private bool rightMenuStuck = false;
    private bool leftMenuStuck = false;
    public float radiusX = 0.0f;
    public float radiusY = 0.0f;
    public GameObject innerCircleButton;
    public GameObject outerCircleButton;
    public GameObject pricePrefab;
    public GameObject datePrefab;
    public GameObject areaPrefab;
    public GameObject houseTypePrefab;

    private GameObject temp;
    public GameObject parent;
    public GameObject head;

    public GameObject leftControllerObject;
    VRTK_ControllerEvents controllerEventsLeft;
    public GameObject rightControllerObject;
    VRTK_ControllerEvents controllerEventsRight;
    public GameObject interval;
    private GameObject smallInterval;
    private Line interValScript;
    private bool intervalUp = false;
    private GameObject instantiatedInterval;
    private ControllerCollision rightControllerCollision;
    private bool filterStuck = false;
    public bool triggerClicked = false;
    public GameObject dataloggerHolder;
    private DataLogger dataloggerScript;




    // Use this for initialization
    void Start()
    {
        rightControllerCollision = rightControllerObject.GetComponent<ControllerCollision>();
        //leftControllerObject.GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(LeftTriggerClicked);
        rightControllerObject.GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(RightTriggerClicked);
        /* 		placeButton(2,4,90,0,false);
                placeButton(2,3,90,90,false);
                placeButton(2,3,90,180,false);
                placeButton(2,1,90,270,false); */
        parent.transform.position = rightControllerObject.transform.position;
        parent.transform.parent = rightControllerObject.transform;
        List<string> bigButtons = new List<string>();
        bigButtons.Add("price");
        bigButtons.Add("date");
        bigButtons.Add("houseType");
        bigButtons.Add("area");
        placeButton(1.5f, 4, 360, 0, true, bigButtons);
        rightmenuActive = true;
        dataloggerScript = dataloggerHolder.GetComponent<DataLogger>();

    }
    // Update is called once per frame
    void Update()
    {
        parent.transform.LookAt(head.transform.position);
    }
    public void placeButton(float radius, float numberOfObjects, float arc, float startOfArc, bool inner, List<string> list)
    {

        for (var i = 0; i < numberOfObjects; i += 1)
        {
            var angle = (i * Mathf.Deg2Rad * arc / numberOfObjects) + (startOfArc + (arc / numberOfObjects / 2)) * Mathf.Deg2Rad;
            var pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            if (inner)
            {
                if (list[i] == "price")
                {
                    temp = Instantiate(pricePrefab, pos, Quaternion.identity);

                }
                else if (list[i] == "date")
                {
                    temp = Instantiate(datePrefab, pos, Quaternion.identity);
                }

                else if (list[i] == "houseType")
                {
                    temp = Instantiate(houseTypePrefab, pos, Quaternion.identity);
                }
                else
                {
                    temp = Instantiate(areaPrefab, pos, Quaternion.identity);
                }

                temp.transform.parent = parent.transform;

                temp.tag = list[i];
                //					temp.transform.parent = parent.transform;
                temp.transform.localPosition = pos;
                temp.transform.rotation = temp.transform.parent.rotation;
                temp.transform.Rotate(0, 180, 0);
                //					temp.transform.LookAt(parent.transform.parent.transform.position);

            }
            else
            {
                temp = Instantiate(outerCircleButton, pos, Quaternion.identity);
                if (list[i] == "propertyPrice")
                {
                    temp.GetComponent<TextMesh>().text = "Property price";
                }
                else if (list[i] == "maxRent")
                {
                    temp.GetComponent<TextMesh>().text = "Max rent";
                }
                else if (list[i] == "plotArea")
                {
                    temp.GetComponent<TextMesh>().text = "Plot area";
                }
                else if (list[i] == "numberOfRooms")
                {
                    temp.GetComponent<TextMesh>().text = "Number of rooms";
                }
                else if (list[i] == "priceReduced")
                {
                    temp.GetComponent<TextMesh>().text = "Price reduced";
                }
                else if (list[i] == "livingArea")
                {
                    temp.GetComponent<TextMesh>().text = "Living area";
                }
                else if (list[i] == "constructionYear")
                {
                    temp.GetComponent<TextMesh>().text = "Construction year";
                }
                else if (list[i] == "m2price")
                {
                    temp.GetComponent<TextMesh>().text = "m2-Price";
                }
                else if (list[i] == "houseType2")
                {
                    temp.GetComponent<TextMesh>().text = "House types";
                }



                temp.tag = list[i];
                temp.transform.parent = parent.transform;
                temp.transform.localPosition = pos;
                temp.transform.rotation = temp.transform.parent.rotation;
                temp.transform.Rotate(0, 180, 0);
            }

        }
    }

    private void RightTriggerClicked(object sender, ControllerInteractionEventArgs e)

    {
        dataloggerScript.actions++;
        print(dataloggerScript.actions);
        triggerClicked = true;
        if (rightControllerCollision.houseTypeFilterActive == true
            && filterStuck == false
            && rightmenuActive == false)
        {
            rightControllerCollision.houseTypeParent.transform.parent = null;
            filterStuck = true;
        }
        else if (rightControllerCollision.houseTypeFilterActive == true && filterStuck == true)
        {
            rightControllerCollision.houseTypeParent.transform.parent = rightControllerCollision.transform;
            rightControllerCollision.houseTypeParent.SetActive(false);
            filterStuck = false;
            rightControllerCollision.houseTypeFilterActive = false;

        }


        if (!rightmenuActive && rightControllerCollision.houseTypeFilterActive == false)
        {
            Destroy(rightControllerCollision.instantiatedInterval);
            rightControllerCollision.intervalUp = false;
            rightControllerCollision.booliScript.filterActive = false;
            print("triggerClicked");
            parent.transform.position = rightControllerObject.transform.position;
            parent.transform.parent = rightControllerObject.transform;
            List<string> bigButtons = new List<string>();
            bigButtons.Add("price");
            bigButtons.Add("date");
            bigButtons.Add("houseType");
            bigButtons.Add("area");
            placeButton(1.5f, 4, 360, 0, true, bigButtons);
            rightmenuActive = true;
        }

        else
        {
            if (!rightMenuStuck)
            {
                parent.transform.parent = null;
                rightMenuStuck = true;
            }
            else
            {
                foreach (Transform child in parent.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                rightmenuActive = false;
                rightMenuStuck = false;

            }
        }

    }


    //private void LeftTriggerClicked(object sender, ControllerInteractionEventArgs e)
    //      {

    //	if(rightmenuActive){
    //		foreach (Transform child in parent.transform) {
    //   				GameObject.Destroy(child.gameObject);
    //			}
    //		rightmenuActive = false;
    //		rightMenuStuck = false;
    //	}

    //	if(!leftmenuActive){
    //		print("triggerClicked");
    //		parent.transform.position = leftControllerObject.transform.position;
    //		parent.transform.parent = leftControllerObject.transform;
    //		List<string> bigButtons = new List<string>();
    //		bigButtons.Add("price");
    //		bigButtons.Add("date");
    //		bigButtons.Add("houseType");
    //		bigButtons.Add("area");
    //		placeButton(1.5f,4,360,0,true,bigButtons);
    //		leftmenuActive = true;
    //	}
    //	else{
    //		if(!leftMenuStuck){
    //			parent.transform.parent = null;
    //			leftMenuStuck = true;
    //		}
    //		else{
    //			 foreach (Transform child in parent.transform) {
    //   					GameObject.Destroy(child.gameObject);
    //				}
    //			leftmenuActive = false;
    //			leftMenuStuck = false;
    //                  if (leftControllerCollision.intervalUp == true)
    //                  {
    //                      Destroy(leftControllerCollision.instantiatedInterval);
    //                      leftControllerCollision.intervalUp = false;
    //                      leftControllerCollision.booliScript.filterActive = false;
    //                  }
    //          }
    //	}

    //      }
}



