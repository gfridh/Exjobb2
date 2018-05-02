using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollision : MonoBehaviour
{
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
    public GameObject overViewHolder;
    private Overview overViewScript;
    public GameObject houseTypeParent;
    public bool houseTypeFilterActive = false;
    public string collisionName = "";
    public string houseTypeTemp;
    public GameObject currentFilter;



    // Use this for initialization
    void Start()
    {
        booliScript = booliHolder.GetComponent<BooliApi>();
        menuScript = menuController.GetComponent<Menu>();
        filteringValues = GameObject.FindWithTag("FilteringValues").GetComponent<FilteringValues>();
        overViewScript = overViewHolder.GetComponent<Overview>();
        houseTypeParent.transform.localPosition = new Vector3(0, 0, 0);
        houseTypeParent.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("binarySlider(Clone)") != null)
        {
            print("binarySlider");
            GameObject ballRight = GameObject.Find("ballRight");
            LineRenderer line = GameObject.Find("intervalLine").GetComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Particles/Multiply"));
            line.SetColors(Color.white, Color.white);
            if (transform.position.x > 0.2f)
            {
                print("moveRight");
                ballRight.transform.localPosition = new Vector3(0,0, 0.1f);
                filteringValues.PriceDecrease = 0;
                overViewScript.priceDecrease.GetComponent<TextMesh>().text = "Price reduced: Yes";

                line.SetColors(Color.blue, Color.blue);
            }

            else
            {
                line.SetColors(Color.grey, Color.grey);
                ballRight.transform.localPosition = new Vector3(0, 0, 0);
                filteringValues.PriceDecrease = 1;
                overViewScript.priceDecrease.GetComponent<TextMesh>().text = "";
            }
        }
        //overViewScript = GameObject.Find("OverView").GetComponent<Overview>();
        houseTypeParent.transform.LookAt(headObject.transform.position);
        if (collisionName != "" && menuScript.triggerClicked == true)
        {

            if (collisionName == "propertyPrice")
            {
                if (!intervalUp)
                {
                    instantiatedInterval = Instantiate(interval);
                    interValScript = GameObject.FindGameObjectWithTag("smallInterval").GetComponent<Line>();
                    interValScript.head = headObject;
                    interValScript.controllerLeft = leftController;
                    interValScript.controllerRight = rightController;
                    interValScript.maxValue = 20000000;
                    interValScript.minValue = 0;
                    interValScript.currentFilter = "propertyPrice";
                    interValScript.currentFilterText = Instantiate(currentFilter);
                    interValScript.currentFilterText.GetComponent<TextMesh>().text = "Property price";
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
            else if (collisionName == "maxRent")
            {
                if (!intervalUp)
                {
                    instantiatedInterval = Instantiate(interval);
                    interValScript = GameObject.FindGameObjectWithTag("smallInterval").GetComponent<Line>();
                    interValScript.controllerLeft = leftController;
                    interValScript.controllerRight = rightController;
                    interValScript.head = headObject;
                    interValScript.maxValue = 10000;
                    interValScript.minValue = 0;
                    interValScript.currentFilter = "rent";
                    interValScript.currentFilterText = Instantiate(currentFilter);
                    interValScript.currentFilterText.GetComponent<TextMesh>().text = "Max rent";
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
            else if (collisionName == "plotArea")
            {
                if (!intervalUp)
                {
                    instantiatedInterval = Instantiate(interval);
                    interValScript = GameObject.FindGameObjectWithTag("smallInterval").GetComponent<Line>();
                    interValScript.controllerLeft = leftController;
                    interValScript.controllerRight = rightController;
                    interValScript.head = headObject;
                    interValScript.maxValue = 2000;
                    interValScript.minValue = 0;
                    interValScript.currentFilter = "plotArea";
                    interValScript.currentFilterText = Instantiate(currentFilter);
                    interValScript.currentFilterText.GetComponent<TextMesh>().text = "Plot area";
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

            else if (collisionName == "numberOfRooms")
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
                    interValScript.currentFilterText = Instantiate(currentFilter);
                    interValScript.currentFilterText.GetComponent<TextMesh>().text = "Rooms";
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

            else if (collisionName == "priceReduced")
            {
                BinaryFilter(collisionName);
            }


            else if (collisionName == "livingArea")

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
                    interValScript.currentFilterText = Instantiate(currentFilter);
                    interValScript.currentFilterText.GetComponent<TextMesh>().text = "Living area";
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

            else if (collisionName == "constructionYear")

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
                    interValScript.currentFilterText = Instantiate(currentFilter);
                    interValScript.currentFilterText.GetComponent<TextMesh>().text = "Construction year";
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
            else if (collisionName == "m2price")

            {
                if (!intervalUp)
                {
                    instantiatedInterval = Instantiate(interval);
                    interValScript = GameObject.FindGameObjectWithTag("smallInterval").GetComponent<Line>();
                    interValScript.controllerLeft = leftController;
                    interValScript.controllerRight = rightController;
                    interValScript.head = headObject;
                    interValScript.maxValue = 200000;
                    interValScript.minValue = 0;
                    interValScript.currentFilter = "m2price";
                    interValScript.currentFilterText = Instantiate(currentFilter);
                    interValScript.currentFilterText.GetComponent<TextMesh>().text = "m2-price";
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
            if (collisionName == "houseType2")
            {
                houseTypeParent.transform.parent = transform;
                houseTypeParent.transform.localPosition = new Vector3();
                houseTypeParent.transform.rotation = houseTypeParent.transform.parent.rotation;
                houseTypeParent.transform.Rotate(0, 180, 0);
                HouseTypeFilter(collisionName);
            }

            if (intervalUp)
            {
                foreach (Transform child in menuScript.parent.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                menuScript.rightmenuActive = false;
                menuScript.rightMenuStuck = false;
            }
            collisionName = "";
            menuScript.triggerClicked = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TextMesh>())
        {
            if (other.tag != "Villa" && other.tag != "Lägenhet" && other.tag != "Fritidshus" && other.tag != "Gård" && other.tag != "Radhus" && other.tag != "Tomt")
            {
                if (other.tag != "yes" && other.tag != "no")
                {

                    other.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    other.GetComponent<TextMesh>().fontSize = 100;
                    //Destroy(instantiatedInterval);
                    //intervalUp = false;

                }

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TextMesh>())
        {
            if (other.tag != "Villa" && other.tag != "Lägenhet" && other.tag != "Fritidshus" && other.tag != "Gård" && other.tag != "Radhus" && other.tag != "Tomt" && other.tag != "yes" && other.tag != "no")
            {

                other.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                other.GetComponent<TextMesh>().fontSize = 150;
            }


        }
        collisionName = other.tag;
        if (other.tag == "price")
        {
            removeChilds();
            List<string> priceButtons = new List<string>();
            priceButtons.Add("propertyPrice");
            priceButtons.Add("maxRent");
            priceButtons.Add("m2price");
            priceButtons.Add("priceReduced");
            menuScript.placeButton(3, 4, 90, 0, false, priceButtons);
        }

        else if (other.tag == "date")
        {
            removeChilds();
            List<string> dateButtons = new List<string>();
            dateButtons.Add("constructionYear");
            menuScript.placeButton(3, 1, 90, 90, false, dateButtons);
        }
        else if (other.tag == "houseType")
        {
            removeChilds();
            List<string> houseTypeButtons = new List<string>();
            houseTypeButtons.Add("houseType2");
            menuScript.placeButton(3, 1, 90, 180, false, houseTypeButtons);
        }
        else if (other.tag == "area")
        {
            removeChilds();
            List<string> areaButtons = new List<string>();
            areaButtons.Add("numberOfRooms");
            areaButtons.Add("livingArea");
            areaButtons.Add("plotArea");
            menuScript.placeButton(3, 3, 90, 270, false, areaButtons);
        }


        if (other.tag == "yes")
        {
            filteringValues.PriceDecrease = 1;
            overViewScript.priceDecrease.GetComponent<TextMesh>().text = "Only price reduced: No";
            other.tag = "no";
            other.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

        }

        else if (other.tag == "no")
        {
            filteringValues.PriceDecrease = 0;
            overViewScript.priceDecrease.GetComponent<TextMesh>().text = "Only price reduced: Yes";
            other.tag = "yes";
            other.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }

        if (other.tag == "Villa" || other.tag == "Lägenhet" || other.tag == "Fritidshus" || other.tag == "Gård" || other.tag == "Radhus" || other.tag == "Tomt")


        {
            if (filteringValues.houseTypes == "LägenhetTomtVillaRadhusGårdFritidshus")
            {
                overViewScript.houseType.GetComponent<TextMesh>().text = " ";
                filteringValues.houseTypes = "";
            }

            if (filteringValues.houseTypes.Contains(other.tag))
            {
                other.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                filteringValues.houseTypes = filteringValues.houseTypes.Replace(other.tag, "");
                houseTypeTemp = overViewScript.houseType.GetComponent<TextMesh>().text;
                string temp = other.tag + ", ";
                houseTypeTemp = houseTypeTemp.Replace(temp, "");
                overViewScript.houseType.GetComponent<TextMesh>().text = houseTypeTemp;

            }

            else
            {
                houseTypeTemp = overViewScript.houseType.GetComponent<TextMesh>().text;
                houseTypeTemp += other.tag + ", ";
                overViewScript.houseType.GetComponent<TextMesh>().text = houseTypeTemp;
                other.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                filteringValues.houseTypes += other.tag;

            }

            if (filteringValues.houseTypes == "")
            {
                filteringValues.houseTypes = "LägenhetTomtVillaRadhusGårdFritidshus";
            }
        }

    }

    private void removeChilds()
    {
        int i = 1;
        foreach (Transform child in menuScript.parent.transform)
        {
            if (i > 4)
            {
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
            instantiatedInterval.transform.position = new Vector3(headObject.transform.position.x, headObject.transform.position.y - 0.4f, headObject.transform.position.z + 1);
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


    private void HouseTypeFilter(string type)
    {
        if (!intervalUp)
        {
            houseTypeParent.SetActive(true);
            intervalUp = true;
            houseTypeFilterActive = true;
            booliScript.filterActive = true;
        }
        else
        {
            houseTypeParent.SetActive(false);
            intervalUp = false;
            booliScript.filterActive = false;
            houseTypeFilterActive = false;
        }
    }
}