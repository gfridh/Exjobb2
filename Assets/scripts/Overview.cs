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
    public int i = 0;
    private FilteringValues filteringValues;
    public GameObject leftControllerObject;
    VRTK_ControllerEvents controllerEventsLeft;
    private bool overviewActive = false;
    public bool reset = false;

    // Use this for initialization
    void Start () {
        DeleteAll();
    }
	
	// Update is called once per frame
	void Update () {



      
    }
    private void LeftTriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        if (overviewActive)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 100, this.gameObject.transform.position.z);
            overviewActive = false;
        }
        else {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 100, this.gameObject.transform.position.z);
            overviewActive = true;
        }
    }

        private void GripClicked(object sender, ControllerInteractionEventArgs e)
    {
        print("gripClicked");
        DeleteAll();
        filteringValues.Restart();
        reset = true;
    }



    private void DeleteAll(){
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
        soonForSale = Instantiate(text, transform);
        rent = Instantiate(text, transform);
        filteringValues = GameObject.FindWithTag("FilteringValues").GetComponent<FilteringValues>();

                foreach (Transform child in transform)
        {
            child.transform.localPosition = new Vector3(child.transform.localPosition.x, child.transform.localPosition.y + i*2, child.transform.localPosition.z);
            i++;
        }
        leftControllerObject.GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(LeftTriggerClicked);
        leftControllerObject.GetComponent<VRTK_ControllerEvents>().GripPressed += new ControllerInteractionEventHandler(GripClicked);

        reset = true;
    }


    }
