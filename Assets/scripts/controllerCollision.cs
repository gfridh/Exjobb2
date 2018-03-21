using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollision : MonoBehaviour {
	public GameObject menuController;
    private Menu menuScript;
	public GameObject interval;
	private GameObject smallInterval;
	private Line interValScript;
	public bool intervalUp = false;
	public GameObject instantiatedInterval;
	public GameObject leftController;
	public GameObject rightController;
    public GameObject headObject;
    public GameObject booliHolder;
    public BooliApi booliScript;
    public GameObject BinaryParent;
    public GameObject binaryParent;
    private FilteringValues filteringValues;



    // Use this for initialization
    void Start () {
        booliScript = booliHolder.GetComponent<BooliApi>();
        menuScript = menuController.GetComponent<Menu>();
        filteringValues = GameObject.FindWithTag("FilteringValues").GetComponent<FilteringValues>();
    }
	
	// Update is called once per frame
	void Update () {

		
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TextMesh>())
        {

            other.GetComponent<TextMesh>().color = Color.blue;
            other.GetComponent<TextMesh>().fontSize = 100;
            Destroy(instantiatedInterval);
            intervalUp = false;

        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.GetComponent<TextMesh>())
        {

            other.GetComponent<TextMesh>().color = Color.yellow;
            other.GetComponent<TextMesh>().fontSize = 150;


        }
        if (other.tag == "price"){
			removeChilds();
			List<string> priceButtons = new List<string>();
			priceButtons.Add("propertyPrice");
			priceButtons.Add("maxRent");
			priceButtons.Add("m2price");
			priceButtons.Add("priceReduced");
			menuScript.placeButton(3,4,90,0,false,priceButtons);
		}

		else if(other.tag == "date"){
			removeChilds();
			List<string> dateButtons = new List<string>();
			dateButtons.Add("constructionYear");
			dateButtons.Add("soonForSale");
			menuScript.placeButton(3,2,90,90,false,dateButtons);
		}
		else if(other.tag == "houseType"){
			removeChilds();
			List<string> houseTypeButtons = new List<string>();
			houseTypeButtons.Add("houseType2");
			menuScript.placeButton(3,1,90,180,false,houseTypeButtons);
		}
		else if(other.tag == "area"){
			removeChilds();
			List<string> areaButtons = new List<string>();
			areaButtons.Add("numberOfRooms");
			areaButtons.Add("livingArea");
			areaButtons.Add("plotArea");
			menuScript.placeButton(3,3,90,270,false,areaButtons);
		}




		else if(other.tag == "propertyPrice"){
			if(!intervalUp){
				instantiatedInterval = Instantiate(interval);
				interValScript = GameObject.FindGameObjectWithTag("smallInterval").GetComponent<Line>();
                interValScript.head = headObject;
				interValScript.controllerLeft = leftController;
				interValScript.controllerRight = rightController;
                interValScript.maxValue = 10000000;
                interValScript.minValue = 0;
                interValScript.currentFilter = "propertyPrice";
				intervalUp = true;
                booliScript.filterActive = true;
			}
            else
            {
                Destroy(instantiatedInterval);
                intervalUp = false;
                booliScript.filterActive = false;
            }
        }
        else if (other.tag == "maxRent")
        {
            if (!intervalUp)
            {
                instantiatedInterval = Instantiate(interval);
                interValScript = GameObject.FindGameObjectWithTag("smallInterval").GetComponent<Line>();
                interValScript.controllerLeft = leftController;
                interValScript.controllerRight = rightController;
                interValScript.head = headObject;
                interValScript.maxValue = 20000;
                interValScript.minValue = 0;
                interValScript.currentFilter = "rent";
                interValScript.oneWayInterval = true;
                intervalUp = true;
                booliScript.filterActive = true;
            }
            else
            {
                Destroy(instantiatedInterval);
                intervalUp = false;
                booliScript.filterActive = false;
            }
        }
        else if (other.tag == "plotArea")
        {
            if (!intervalUp)
            {
                instantiatedInterval = Instantiate(interval);
                interValScript = GameObject.FindGameObjectWithTag("smallInterval").GetComponent<Line>();
                interValScript.controllerLeft = leftController;
                interValScript.controllerRight = rightController;
                interValScript.head = headObject;
                interValScript.maxValue = 50000;
                interValScript.minValue = 0;
                interValScript.currentFilter = "plotArea";
                intervalUp = true;
                booliScript.filterActive = true;
            }
            else
            {
                Destroy(instantiatedInterval);
                intervalUp = false;
                booliScript.filterActive = false;
            }
        }

        else if (other.tag == "numberOfRooms")
        {
            if (!intervalUp)
            {
                instantiatedInterval = Instantiate(interval);
                interValScript = GameObject.FindGameObjectWithTag("smallInterval").GetComponent<Line>();
                interValScript.controllerLeft = leftController;
                interValScript.controllerRight = rightController;
                interValScript.head = headObject;
                interValScript.maxValue = 10;
                interValScript.minValue = 0;
                interValScript.currentFilter = "numberOfRooms";
                intervalUp = true;
                booliScript.filterActive = true;
            }
            else
            {
                Destroy(instantiatedInterval);
                intervalUp = false;
                booliScript.filterActive = false;
            }
        }

        else if (other.tag == "priceReduced")
        {
            BinaryFilter(other.tag);
        }

            if(other.tag == "yes")
            {
                filteringValues.PriceDecrease = 1;
            }
            else if (other.tag == "no")
            {
                filteringValues.PriceDecrease = 0;
        }


        else if (other.tag == "livingArea")

        {
            if (!intervalUp)
            {
                instantiatedInterval = Instantiate(interval);
                interValScript = GameObject.FindGameObjectWithTag("smallInterval").GetComponent<Line>();
                interValScript.controllerLeft = leftController;
                interValScript.controllerRight = rightController;
                interValScript.head = headObject;
                interValScript.maxValue = 500;
                interValScript.minValue = 0;
                interValScript.currentFilter = "livingArea";
                intervalUp = true;
                booliScript.filterActive = true;
            }
            else
            {
                Destroy(instantiatedInterval);
                intervalUp = false;
                booliScript.filterActive = false;
            }

        }

        else if (other.tag == "constructionYear")

        {
            if (!intervalUp)
            {
                instantiatedInterval = Instantiate(interval);
                interValScript = GameObject.FindGameObjectWithTag("smallInterval").GetComponent<Line>();
                interValScript.controllerLeft = leftController;
                interValScript.controllerRight = rightController;
                interValScript.head = headObject;
                interValScript.maxValue = 518;
                interValScript.minValue = 0;
                interValScript.currentFilter = "constructionYear";
                intervalUp = true;
                booliScript.filterActive = true;
            }
            else
            {
                Destroy(instantiatedInterval);
                intervalUp = false;
                booliScript.filterActive = false;
            }

        }

    }

	private void removeChilds(){
		int i = 1;
		foreach (Transform child in menuScript.parent.transform) {
			if(i>4){
				GameObject.Destroy(child.gameObject);
			}
			i++;
 		}
	}

    private void BinaryFilter(string type)
    {
        if (!intervalUp)
        {
            instantiatedInterval = Instantiate(BinaryParent);
            instantiatedInterval.transform.position = rightController.transform.position;
            intervalUp = true;
            booliScript.filterActive = true;
        }
        else
        {
            Destroy(instantiatedInterval);
            intervalUp = false;
            booliScript.filterActive = false;
        }
    }
}