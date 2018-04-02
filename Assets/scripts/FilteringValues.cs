using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilteringValues : MonoBehaviour {
    public float listpriceMin = 0;
    public float listPriceMax = 100000000;
    public float rentMax = 1000000;
    public float plotAreaMin = 0;
    public float plotAreaMax = 100000000;
    public int PriceDecrease = 1;
    public string houseTypes = "LägenhetTomtVillaRadhusGårdFritidshus";
    public float m2PriceMin = 0;
    public float m2PriceMax = 100000000;
    public int constructionYearMin = 1500;
    public int constructionYearMax = 2018;
    public int numberOfRoomsMin = 0;
    public int numberOfRoomsMax = 10000;
    public int livingAreaMin = 0;
    public int livingAreaMax = 1000000000;
    public int soonForSale = 0;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Restart(){
    listpriceMin = 0;
    listPriceMax = 100000000;
    rentMax = 1000000;
    plotAreaMin = 0;
    plotAreaMax = 100000000;
    PriceDecrease = 1;
    houseTypes = "LägenhetTomtVillaRadhusGårdFritidshus";
    m2PriceMin = 0;
    m2PriceMax = 100000000;
    constructionYearMin = 1500;
    constructionYearMax = 2018;
    numberOfRoomsMin = 0;
    numberOfRoomsMax = 10000;
    livingAreaMin = 0;
    livingAreaMax = 1000000000;
    soonForSale = 0;



    }
}
