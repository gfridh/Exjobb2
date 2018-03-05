using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour {
	public GameObject ballRight;
	public GameObject ballLeft;
	public LineRenderer lineRendererInterval;
	public LineRenderer lineRendererRight;
	public LineRenderer lineRendererLeft;

	public GameObject controllerLeft;
	public GameObject controllerRight;
	public GameObject head;

	public GameObject sphere3;

	public GameObject smallInterval;
	public GameObject bigInterval;

	private float distanceBetweenControllers;

	public float bigIntervalWidth = 0.5f;

	// Use this for initialization
	void Start () {
		lineRendererInterval.positionCount = 2;
		lineRendererRight.positionCount = 2;
		lineRendererLeft.positionCount = 2;
		lineRendererRight.useWorldSpace = false;
		lineRendererLeft.useWorldSpace = false;
		
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
		bigInterval.transform.position = middleOfControllers + new Vector3(0,0,0.5f);

		distanceBetweenControllers =  (new Vector3(controllerRight.transform.position.x,0,controllerRight.transform.position.z) - new Vector3(controllerLeft.transform.position.x,0,controllerLeft.transform.position.z)).magnitude;
/* 		distanceBetweenControllers = (controllerRight.transform.position.x - controllerLeft.transform.position.x); */
		print(distanceBetweenControllers);
		if(distanceBetweenControllers > 0.5f){
			print(distanceBetweenControllers);
			ballRight.transform.localPosition = new Vector3((bigIntervalWidth),0,0);
			ballLeft.transform.localPosition = new Vector3(-(bigIntervalWidth),0,0);
		}
		else{
			if(ballRight.transform.localPosition.x + (controllerLeft.transform.position.y-controllerRight.transform.position.y) > (bigIntervalWidth)){
				ballRight.transform.localPosition = new Vector3((distanceBetweenControllers),0,0);
				ballLeft.transform.localPosition = new Vector3(-(distanceBetweenControllers),0,0);
				print("bollen är för långt till höger");
				smallInterval.transform.localPosition = new Vector3((bigIntervalWidth)-(distanceBetweenControllers),0,0);
			}

			else if(ballLeft.transform.localPosition.x-(controllerRight.transform.position.y-controllerLeft.transform.position.y) < -(bigIntervalWidth)){
				print("bollen är för långt till vänster");
				ballRight.transform.localPosition = new Vector3((distanceBetweenControllers),0,0);
				ballLeft.transform.localPosition = new Vector3(-(distanceBetweenControllers),0,0);
				smallInterval.transform.localPosition = new Vector3(-(bigIntervalWidth)+(distanceBetweenControllers),0,0);

			}
				
			else{
				ballRight.transform.localPosition = new Vector3((distanceBetweenControllers),0,0);
				ballLeft.transform.localPosition = new Vector3(-(distanceBetweenControllers),0,0);
				smallInterval.transform.localPosition = new Vector3((controllerLeft.transform.position.y-controllerRight.transform.position.y),0,0);
			}

		}
		//print((bigInterval.transform.InverseTransformPoint(ballLeft.transform.position).x+(bigIntervalWidth/2))*100000 + " - "+ ((bigInterval.transform.InverseTransformPoint(ballRight.transform.position).x+(bigIntervalWidth/2))*100000 ));
		/* print(ballLeft.transform.localPosition.x + " - "+ (ballRight.transform.localPosition.x )); */
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
