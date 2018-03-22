using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
    private BooliApi booliScript;
    private Overview overViewScript;
    public GameObject ballRight;
	public GameObject ballLeft;
    public GameObject rightText;
    public GameObject leftText;

    public LineRenderer lineRendererInterval;
	public LineRenderer lineRendererRight;
	public LineRenderer lineRendererLeft;

	public GameObject controllerLeft;
	public GameObject controllerRight;
	public GameObject head;

	public GameObject sphere3;

	public GameObject smallInterval;
	public GameObject bigInterval;
    private float handPositionModulation = 0.08f;
    private float distanceBetweenBalls;

    public FilteringValues filteringValues;

    //determined by controllerCollision
    public float maxValue;
    public float minValue;
    public string currentFilter;
    private float intervalPosition;

    public float smallValue;
    public float bigValue;

    private float distanceBetweenControllers;

	public float bigIntervalWidth = 0.5f;
    public bool oneWayInterval = false;

    public GameObject overviewHolder;
    private Overview overview;

	// Use this for initialization
	void Start () {
        rightText = GameObject.Find("highValue");
        leftText = GameObject.Find("lowValue");
        booliScript = GameObject.FindWithTag("fullMap").GetComponent<BooliApi>();
        lineRendererInterval.positionCount = 2;
        lineRendererInterval.material = new Material(Shader.Find("Particles/Multiply"));
        lineRendererInterval.SetColors(Color.blue, Color.blue);
        lineRendererRight.positionCount = 2;
		lineRendererLeft.positionCount = 2;
		lineRendererRight.useWorldSpace = false;
		lineRendererLeft.useWorldSpace = false;
        filteringValues = GameObject.FindWithTag("FilteringValues").GetComponent<FilteringValues>();
        overViewScript = GameObject.Find("OverView").GetComponent<Overview>();
        rightText.GetComponent<TextMesh>().fontSize = 60;
        rightText.transform.localPosition = new Vector3 (rightText.transform.localPosition.x, rightText.transform.localPosition.y-1, rightText.transform.localPosition.z);
        leftText.GetComponent<TextMesh>().fontSize = 60;


    }
	
	// Update is called once per frame
	void Update () {
		Vector3 normalizedIntervalVector = (controllerLeft.transform.position - controllerRight.transform.position).normalized;
		Vector3 middleOfControllers =controllerRight.transform.position + (controllerLeft.transform.position - controllerRight.transform.position)/2;
		lineRendererInterval.SetPosition(0,ballRight.transform.localPosition);
        lineRendererInterval.SetPosition(1,ballLeft.transform.localPosition);
		lineRendererRight.SetPosition(0,ballRight.transform.localPosition+smallInterval.transform.localPosition);
		lineRendererRight.SetPosition(1,new Vector3((bigIntervalWidth),ballRight.transform.localPosition.y,ballRight.transform.localPosition.z));
		lineRendererLeft.SetPosition(0,ballLeft.transform.localPosition+smallInterval.transform.localPosition);
		lineRendererLeft.SetPosition(1,new Vector3(-(bigIntervalWidth),ballLeft.transform.localPosition.y,ballLeft.transform.localPosition.z));
		bigInterval.transform.position = new Vector3(head.transform.position.x,middleOfControllers.y,middleOfControllers.z) + new Vector3(0,0,0.5f);
        

		distanceBetweenControllers =  (controllerRight.transform.position.x - handPositionModulation) - (controllerLeft.transform.position.x + handPositionModulation);
        print(distanceBetweenControllers);
        /* 		distanceBetweenControllers = ((controllerRight.transform.position.x - handPositionModulation) - (controllerLeft.transform.position.x + handPositionModulation)); */

        intervalPosition =  middleOfControllers.x - head.transform.position.x;
        smallInterval.transform.localPosition = new Vector3(0, 0, 0);

        if (oneWayInterval == false)
        {
            if ((controllerRight.transform.position.x - handPositionModulation) - head.transform.position.x >= 0.5 && (controllerLeft.transform.position.x + handPositionModulation) - head.transform.position.x >= -0.5)
            {
                ballRight.transform.localPosition = new Vector3(0.50f, 0, 0);
                ballLeft.transform.localPosition = new Vector3((controllerLeft.transform.position.x + handPositionModulation) - head.transform.position.x, 0, 0);
                if (distanceBetweenControllers <= 0)
                {
                    ballLeft.transform.position = ballRight.transform.position;

                }
                smallValue = (bigInterval.transform.InverseTransformPoint(ballLeft.transform.position).x + (bigIntervalWidth)) * maxValue;
                bigValue = 100000000;
            }

            else if ((controllerRight.transform.position.x - handPositionModulation) - head.transform.position.x >= 0.5 && (controllerLeft.transform.position.x + handPositionModulation) - head.transform.position.x >= 0.5)
            {
                ballRight.transform.localPosition = new Vector3(0.50f, 0, 0);
                ballLeft.transform.localPosition = new Vector3(0.50f, 0, 0);
                smallValue = maxValue;
                bigValue = 1000000;
            }
            else if ((controllerLeft.transform.position.x + handPositionModulation) - head.transform.position.x <= -0.5 && (controllerRight.transform.position.x - handPositionModulation) - head.transform.position.x <= 0.5f)
            {
                ballRight.transform.localPosition = new Vector3((controllerRight.transform.position.x - handPositionModulation) - head.transform.position.x, 0, 0);
                ballLeft.transform.localPosition = new Vector3(-0.50f, 0, 0);
                if (distanceBetweenControllers <= 0)
                {
                    ballLeft.transform.position = ballRight.transform.position;

                    ballRight.transform.position = ballLeft.transform.position;

                }
                smallValue = 0;
                bigValue = (bigInterval.transform.InverseTransformPoint(ballRight.transform.position).x + (bigIntervalWidth)) * maxValue;
            }

            else if ((controllerLeft.transform.position.x + handPositionModulation) - head.transform.position.x >= -0.5 && (controllerRight.transform.position.x - handPositionModulation) - head.transform.position.x <= 0.5f)
            {
                ballRight.transform.localPosition = new Vector3((controllerRight.transform.position.x - handPositionModulation) - head.transform.position.x, 0, 0);
                ballLeft.transform.localPosition = new Vector3((controllerLeft.transform.position.x + handPositionModulation) - head.transform.position.x, 0, 0);
                if (distanceBetweenControllers <= 0)
                {
                    ballLeft.transform.position = ballRight.transform.position;

                    ballRight.transform.position = ballLeft.transform.position;

                }
                smallValue = (bigInterval.transform.InverseTransformPoint(ballLeft.transform.position).x + (bigIntervalWidth)) * maxValue;
                bigValue = (bigInterval.transform.InverseTransformPoint(ballRight.transform.position).x + (bigIntervalWidth)) * maxValue;
            }
            else if ((controllerLeft.transform.position.x + handPositionModulation) - head.transform.position.x <= -0.5 && (controllerRight.transform.position.x - handPositionModulation) - head.transform.position.x >= 0.5f)
            {
                ballRight.transform.localPosition = new Vector3(0.50f, 0, 0);
                ballLeft.transform.localPosition = new Vector3(-0.50f, 0, 0);
                if (distanceBetweenControllers <= 0)
                {
                    ballLeft.transform.position = ballRight.transform.position;

                    ballRight.transform.position = ballLeft.transform.position;

                }
                smallValue = minValue;
                bigValue = 100000000;
            }
        }
        else
        {
            smallValue = 0;
            ballLeft.transform.localPosition = new Vector3(-0.50f, 0, 0);
            if ((controllerRight.transform.position.x - handPositionModulation) - head.transform.position.x <= 0.5f)
            {
                ballRight.transform.localPosition = new Vector3((controllerRight.transform.position.x - handPositionModulation) - head.transform.position.x, 0, 0);
                bigValue = (bigInterval.transform.InverseTransformPoint(ballRight.transform.position).x + (bigIntervalWidth)) * maxValue;

            }
            else
            {
                ballRight.transform.localPosition = new Vector3(0.50f, 0, 0);
                bigValue = 100000000;
            }


        }
       
		//else{
		//	if(ballRight.transform.localPosition.x + intervalPosition > (bigIntervalWidth)){
		//		ballRight.transform.localPosition = new Vector3((distanceBetweenControllers),0,0);
		//		ballLeft.transform.localPosition = new Vector3(-(distanceBetweenControllers)+intervalPosition-smallInterval.transform.localPosition.x,0,0);
		//		print("bollen är för långt till höger");
		//		smallInterval.transform.localPosition = new Vector3((bigIntervalWidth)-(distanceBetweenControllers),0,0);
		//	}

		//	else if(ballLeft.transform.localPosition.x-intervalPosition < -(bigIntervalWidth)){
		//		print("bollen är för långt till vänster");
		//		ballRight.transform.localPosition = new Vector3((distanceBetweenControllers)+intervalPosition-smallInterval.transform.localPosition.x,0,0);
		//		ballLeft.transform.localPosition = new Vector3(-(distanceBetweenControllers),0,0);


		//	}
				
		//	else{
		//		ballRight.transform.localPosition = new Vector3((distanceBetweenControllers),0,0);
		//		ballLeft.transform.localPosition = new Vector3(-(distanceBetweenControllers),0,0);
		//	}
		//}

        if (currentFilter == "rent")
        {
            filteringValues.rentMax = bigValue;
            leftText.GetComponent<TextMesh>().text = " ";
            if (bigValue>maxValue)
            {
                rightText.GetComponent<TextMesh>().text = (Mathf.Round((maxValue / 1000) * 10f) / 10f).ToString()+"t"+"+";
            }
            else
            {
                rightText.GetComponent<TextMesh>().text = (Mathf.Round((bigValue / 1000) * 10f) / 10f).ToString()+"t";
            }
            print(overViewScript.rent.GetComponent<TextMesh>().text);
            overViewScript.rent.GetComponent<TextMesh>().text = "Max rent: " + rightText.GetComponent<TextMesh>().text;
        }

        else if (currentFilter == "propertyPrice")
        {
            filteringValues.listPriceMax = bigValue;
            filteringValues.listpriceMin = smallValue;
            leftText.GetComponent<TextMesh>().text = (Mathf.Round((smallValue / 1000000) * 10f) / 10f).ToString() + "M";
            if (bigValue > maxValue)
            {
                rightText.GetComponent<TextMesh>().text = (Mathf.Round((maxValue / 1000000) * 10f) / 10f).ToString()+"M" + "+";
            }
            else
            {
                rightText.GetComponent<TextMesh>().text = (Mathf.Round((bigValue / 1000000) * 10f) / 10f).ToString()+ "M";
            }
            overViewScript.listPrice.GetComponent<TextMesh>().text = "Property price: " + leftText.GetComponent<TextMesh>().text+" - " + rightText.GetComponent<TextMesh>().text;

        }

        else if (currentFilter == "plotArea")

        {
            filteringValues.plotAreaMax = bigValue;
            filteringValues.plotAreaMin = smallValue;
            rightText.GetComponent<TextMesh>().text = Mathf.Round(bigValue).ToString();
            leftText.GetComponent<TextMesh>().text = Mathf.Round(smallValue).ToString();
            if (bigValue > maxValue)
            {
                rightText.GetComponent<TextMesh>().text = Mathf.Round(bigValue).ToString() + "m2"+ "+";
            }
            else
            {
                rightText.GetComponent<TextMesh>().text = Mathf.Round(bigValue).ToString() + "m2";
            }
            overViewScript.plotArea.GetComponent<TextMesh>().text = "Plot area: " + leftText.GetComponent<TextMesh>().text + " - " + rightText.GetComponent<TextMesh>().text;


        }


        else if (currentFilter == "numberOfRooms")

        {
            filteringValues.numberOfRoomsMax = Mathf.RoundToInt(bigValue);
            filteringValues.numberOfRoomsMin = Mathf.RoundToInt(smallValue);
            leftText.GetComponent<TextMesh>().text = Mathf.RoundToInt(smallValue).ToString() + " rooms";
            if (Mathf.RoundToInt(bigValue) > maxValue)
            {
                rightText.GetComponent<TextMesh>().text = maxValue.ToString() + "rooms" + "+";
            }
            else
            {
                rightText.GetComponent<TextMesh>().text = Mathf.RoundToInt(bigValue).ToString() + "rooms";
            }
            overViewScript.numberOfrooms.GetComponent<TextMesh>().text = "Rooms: " + leftText.GetComponent<TextMesh>().text + " - " + rightText.GetComponent<TextMesh>().text;

        }

        else if (currentFilter == "livingArea")

        {
            filteringValues.livingAreaMin = Mathf.RoundToInt(smallValue);
            filteringValues.livingAreaMax = Mathf.RoundToInt(bigValue);
            leftText.GetComponent<TextMesh>().text = smallValue.ToString();
            if (bigValue > maxValue)
            {
                rightText.GetComponent<TextMesh>().text =maxValue.ToString() +  "+";
            }
            else
            {
                rightText.GetComponent<TextMesh>().text =bigValue.ToString();
            }
            overViewScript.livingArea.GetComponent<TextMesh>().text = "Living area: " + leftText.GetComponent<TextMesh>().text + " - " + rightText.GetComponent<TextMesh>().text;

        }

        else if (currentFilter == "constructionYear")

        {
            smallValue += 1500;
            bigValue += 1500;
            smallValue = Mathf.RoundToInt(smallValue);
            bigValue = Mathf.RoundToInt(bigValue);
            filteringValues.constructionYearMin = Mathf.RoundToInt(smallValue);
            filteringValues.constructionYearMax = Mathf.RoundToInt(bigValue);
            leftText.GetComponent<TextMesh>().text = smallValue.ToString();
            if (bigValue > maxValue+1500)
            {
                rightText.GetComponent<TextMesh>().text = 2018.ToString();
            }
            else
            {
                rightText.GetComponent<TextMesh>().text = bigValue.ToString();
            }
            overViewScript.constructionYear.GetComponent<TextMesh>().text = "Construction year: " + leftText.GetComponent<TextMesh>().text + " - " + rightText.GetComponent<TextMesh>().text;
        }
        else if (currentFilter == "m2price")

        {
            smallValue = Mathf.RoundToInt(smallValue);
            bigValue = Mathf.RoundToInt(bigValue);
            filteringValues.m2PriceMin = Mathf.RoundToInt(smallValue);
            filteringValues.m2PriceMax = Mathf.RoundToInt(bigValue);
            leftText.GetComponent<TextMesh>().text = (Mathf.Round((smallValue / 1000) * 10f) / 10f).ToString() + "k";
            if (bigValue > maxValue)
            {
                bigValue = 100000000;
                rightText.GetComponent<TextMesh>().text = (Mathf.Round((maxValue / 1000) * 10f) / 10f).ToString() + "k" + "+";
            }
            else
            {
                rightText.GetComponent<TextMesh>().text = (Mathf.Round((bigValue / 1000) * 10f) / 10f).ToString() + "k";
            }
            overViewScript.m2Price.GetComponent<TextMesh>().text = "m2 Price: " + leftText.GetComponent<TextMesh>().text + " - " + rightText.GetComponent<TextMesh>().text;

        }




        //print((bigInterval.transform.InverseTransformPoint(ballLeft.transform.position).x+(bigIntervalWidth))*maxValue + " - " + ((bigInterval.transform.InverseTransformPoint(ballRight.transform.position).x+(bigIntervalWidth))*maxValue ));
        //print(bigInterval.transform.InverseTransformPoint(ballLeft.transform.position).x + bigIntervalWidth*maxValue + " - " + bigInterval.transform.InverseTransformPoint(ballRight.transform.position).x + bigIntervalWidth * maxValue);
        //print(ballLeft.transform.localPosition.x + " - "+ (ballRight.transform.localPosition.x )); 
        /* 		print(ballRight.transform.InverseTransformPoint(bigInterval.transform.position).x);
                print(ballRight.transform.localPosition.x);
                 */





        /* 		
        sphere3.transform.position = middleOfControllers;
                lineRendererControllers.SetPosition(0,ballRight.transform.position);
                lineRendererControllers.SetPosition(1,ballLeft.transform.position);
                ballRight.transform.position = middleOfControllers - normalizedIntervalVector*5 ;
                ballLeft.transform.position = middleOfControllers + normalizedIntervalVector*5 ;
                lineRendererLeft.SetPosition(0,ballLeft.transform.position);
                lineRendererLeft.SetPosition(1,  middleOfControllers + normalizedIntervalVector*10);
                lineRendererRight.SetPosition(0,ballRight.transform.position);
                lineRendererRight.SetPosition(1,  middleOfControllers - normalizedIntervalVector*10); */

    }
}
