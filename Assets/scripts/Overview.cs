using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class Overview: MonoBehaviour {
    public GameObject text;
    public GameObject numberOfrooms;
    public GameObject livingArea;
    public GameObject constructionYear;
    public GameObject plotArea;
    public GameObject rent;
    public GameObject priceDecrease;
    public GameObject houseType;
    public GameObject m2Price;
    public GameObject soonForSale;
    public GameObject listPrice;
    private int i = 0;
    private FilteringValues filteringValues;
    public GameObject leftControllerObject;
    VRTK_ControllerEvents controllerEventsLeft;
    private bool overviewActive = false;
    public bool reset = false;
    public GameObject houseTypeParent;
    public GameObject head;
    private int distanceFromHead = 1;
    // Use this for initialization
    void Start () {
        //leftControllerObject.GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(LeftTriggerClicked);
        leftControllerObject.GetComponent<VRTK_ControllerEvents>().GripPressed += new ControllerInteractionEventHandler(GripClicked);
        DeleteAll();
    }
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.position = new Vector3(head.transform.position.x - 0.5f,0, distanceFromHead+ head.transform.position.z);


    }
    //private void LeftTriggerClicked(object sender, ControllerInteractionEventArgs e)
    //{
    //    if (overviewActive == true)
    //    {
    //        distanceFromHead = 1;
    //        overviewActive = false;
    //    }
    //    else {
    //        distanceFromHead = 1000000;
    //        overviewActive = true;
    //    }
    //}

        private void GripClicked(object sender, ControllerInteractionEventArgs e)
    {
        print("gripClicked");
        DeleteAll();
        filteringValues.Restart();
        reset = true;
        foreach (Transform child in houseTypeParent.transform)
        {
            child.GetComponent<TextMesh>().color = Color.blue;
            // do what you want with the transform
        }
        i = 0;
        
    }



    private void DeleteAll(){
        i = 0;
        Destroy(listPrice);
        Destroy(numberOfrooms);
        Destroy(livingArea);
        Destroy(constructionYear);
        Destroy(plotArea);
        Destroy(priceDecrease);
        Destroy(houseType);
        Destroy(m2Price);
        Destroy(soonForSale);
        Destroy(rent);

        listPrice = Instantiate(text , transform);
        numberOfrooms = Instantiate(text, transform);
        livingArea = Instantiate(text, transform);
        constructionYear = Instantiate(text, transform);
        plotArea = Instantiate(text, transform);
        priceDecrease = Instantiate(text, transform);
        houseType = Instantiate(text, transform);
        m2Price = Instantiate(text, transform);
        rent = Instantiate(text, transform);
        filteringValues = GameObject.FindWithTag("FilteringValues").GetComponent<FilteringValues>();

                foreach (Transform child in transform)
        {
            if (i >= 10)
            {
                child.transform.localPosition = new Vector3(child.transform.localPosition.x, child.transform.localPosition.y + i * 2 - 20, child.transform.localPosition.z);
            }
            else
            {
                child.transform.localPosition = new Vector3(child.transform.localPosition.x, child.transform.localPosition.y + i * 2, child.transform.localPosition.z);

            }
         i++;
        }

        reset = true;
    }


    }
