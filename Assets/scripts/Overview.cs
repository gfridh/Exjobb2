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

    // Use this for initialization
    void Start () {
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

    }
	
	// Update is called once per frame
	void Update () {
        listPrice.GetComponent<TextMesh>().text = "Listing price: " + (Mathf.Round((filteringValues.listpriceMin / 1000000) * 10f) / 10f).ToString() + "M - " + (Mathf.Round((filteringValues.listPriceMax / 1000000) * 10f) / 10f).ToString() + "M";
        numberOfrooms.GetComponent<TextMesh>().text = "Rooms: " + filteringValues.numberOfRoomsMin + " - " + filteringValues.numberOfRoomsMax + "";
        livingArea.GetComponent<TextMesh>().text = "Living area: " + filteringValues.livingAreaMin + " m2 - " + filteringValues.livingAreaMax + " m2";
        constructionYear.GetComponent<TextMesh>().text = "Construction year: " + filteringValues.constructionYearMin + " - " + filteringValues.constructionYearMax + "";
        plotArea.GetComponent<TextMesh>().text = "Plot area: " + filteringValues.plotAreaMin + " m2 - " + filteringValues.plotAreaMax + " m2";
        priceDecrease.GetComponent<TextMesh>().text = "Price decreased: " + filteringValues.PriceDecrease;
        houseType.GetComponent<TextMesh>().text = "House types: " + filteringValues.houseType;
        m2Price.GetComponent<TextMesh>().text = "m2-price: " + filteringValues.m2PriceMin + " - " + filteringValues.m2PriceMax + "";
        soonForSale.GetComponent<TextMesh>().text = "Soon for sale: " + filteringValues.soonForSale + "";
        rent.GetComponent<TextMesh>().text = "Rent max: " + filteringValues.rentMax + "";
    }
    private void LeftTriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        if (overviewActive)
        {
            this.gameObject.SetActive(false);
            overviewActive = false;
        }
        else {
            this.gameObject.SetActive(true);
            overviewActive = true;
        }
    }


    }
