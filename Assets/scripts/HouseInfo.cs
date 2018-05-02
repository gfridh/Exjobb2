using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseInfo : MonoBehaviour {
    public GameObject text;
    public GameObject numberOfrooms;
    public GameObject livingArea;
    public GameObject constructionYear;
    public GameObject plotArea;
    public GameObject rent;
    public GameObject priceDecrease;
    public GameObject houseType;
    public GameObject m2Price;
    public GameObject listPrice;
    public GameObject adress;
    public HouseCollider houseColliderScript;
    private int i = 0;
    private bool houseColliderFound = false;
    public GameObject currentPrintedHouse;

    // Use this for initialization
    void Start () {


        constructionYear = Instantiate(text, transform);
        houseType = Instantiate(text, transform);
        numberOfrooms = Instantiate(text, transform);
        plotArea = Instantiate(text, transform);
        livingArea = Instantiate(text, transform);
        priceDecrease = Instantiate(text, transform);
        m2Price = Instantiate(text, transform);
        rent = Instantiate(text, transform);
        listPrice = Instantiate(text, transform);
        adress = Instantiate(text, transform);

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

    }
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindWithTag("houseMarker") && !houseColliderFound)
        {
            GameObject houseMarker = GameObject.FindWithTag("houseMarker");
            houseColliderScript = houseMarker.GetComponent<HouseCollider>();
            houseColliderFound = true;
        }

        if (houseColliderFound && houseColliderScript.printedHouse != currentPrintedHouse )
        {
            print(houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().listPrice);


            listPrice.GetComponent<TextMesh>().text = "Property price: " + (Mathf.Round((houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().listPrice / 1000000) * 10f) / 10f).ToString() + "M";
            numberOfrooms.GetComponent<TextMesh>().text ="Number of rooms: " + houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().numberOfrooms.ToString();
            livingArea.GetComponent<TextMesh>().text ="Living area: " + houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().livingArea.ToString() + " m2";
            constructionYear.GetComponent<TextMesh>().text ="Construction year: " +  houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().constructionYear.ToString();
            plotArea.GetComponent<TextMesh>().text ="Plot area: " + houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().plotArea.ToString() + "m2";
            if (houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().priceDecrease == 1)
            {
                priceDecrease.GetComponent<TextMesh>().text = "Price decreased: no";
            }
            else if (houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().priceDecrease == 0)
            {
                priceDecrease.GetComponent<TextMesh>().text = "Price decreased: yes";
            }

            houseType.GetComponent<TextMesh>().text = "Housetype: " + houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().houseType.ToString();
            m2Price.GetComponent<TextMesh>().text ="m2 price: " + (Mathf.Round((houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().m2Price / 1000) * 10f) / 10f).ToString() + "t";
            rent.GetComponent<TextMesh>().text = "Rent: " + (Mathf.Round((houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().rent / 1000) * 10f) / 10f).ToString() + "t";
            adress.GetComponent<TextMesh>().text = "Address: " +  houseColliderScript.printedHouse.GetComponent<HouseCoordinates>().adress;


            currentPrintedHouse = houseColliderScript.printedHouse; 
        }
		
	}
}
