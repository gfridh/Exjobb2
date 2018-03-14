using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
    private BooliApi booliScript;

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

	// Use this for initialization
	void Start () {
        rightText = Instantiate(rightText,ballRight.transform);
        leftText = Instantiate(leftText,ballLeft.transform);
        booliScript = GameObject.FindWithTag("fullMap").GetComponent<BooliApi>();
        lineRendererInterval.positionCount = 2;
		lineRendererRight.positionCount = 2;
		lineRendererLeft.positionCount = 2;
		lineRendererRight.useWorldSpace = false;
		lineRendererLeft.useWorldSpace = false;
        filteringValues = GameObject.FindWithTag("FilteringValues").GetComponent<FilteringValues>();

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

		distanceBetweenControllers =  (new Vector3(controllerRight.transform.position.x,0,controllerRight.transform.position.z) - new Vector3(controllerLeft.transform.position.x,0,controllerLeft.transform.position.z)).magnitude-0.12f;
        /* 		distanceBetweenControllers = (controllerRight.transform.position.x - controllerLeft.transform.position.x); */

        intervalPosition =  middleOfControllers.x - head.transform.position.x;
        smallInterval.transform.localPosition = new Vector3(0, 0, 0);

		ballRight.transform.localPosition = new Vector3(controllerRight.transform.position.x - head.transform.position.x ,0,0);
		ballLeft.transform.localPosition = new Vector3(controllerLeft.transform.position.x- head.transform.position.x, 0,0);

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


            smallValue = (bigInterval.transform.InverseTransformPoint(ballLeft.transform.position).x + (bigIntervalWidth)) * maxValue;
            bigValue = (bigInterval.transform.InverseTransformPoint(ballRight.transform.position).x + (bigIntervalWidth)) * maxValue;
     


        if (currentFilter == "rent")
        {
            filteringValues.rentMax = bigValue;
            rightText.GetComponent<TextMesh>().text = (Mathf.Round((bigValue / 1000) * 10f) / 10f).ToString();
            leftText.GetComponent<TextMesh>().text = (Mathf.Round((smallValue / 1000) * 10f) / 10f).ToString();
        }

        else if (currentFilter == "propertyPrice")
        {
            filteringValues.listPriceMax = bigValue;
            filteringValues.listpriceMin = smallValue;
            rightText.GetComponent<TextMesh>().text = (Mathf.Round((bigValue / 1000000) * 10f) / 10f).ToString();
            leftText.GetComponent<TextMesh>().text = (Mathf.Round((smallValue / 1000000) * 10f) / 10f).ToString();
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
