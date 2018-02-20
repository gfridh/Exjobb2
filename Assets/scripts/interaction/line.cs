using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour {
	public GameObject ball1;
	public GameObject ball2;
	public LineRenderer lineRenderer;
	public LineRenderer lineRendererLeft;
	public LineRenderer lineRendererRight;

	public GameObject controllerLeft;
	public GameObject controllerRight;
	public GameObject head;

	public GameObject sphere3;
	public int intervalWidth = 20;


	// Use this for initialization
	void Start () {
		Debug.Log(ball1.transform.position);
		lineRenderer.positionCount = 2;
		lineRendererLeft.positionCount = 2;
		lineRendererRight.positionCount = 2;
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 normalizedIntervalVector = (controllerLeft.transform.position - controllerRight.transform.position).normalized;
		Vector3 middleOfControllers =controllerRight.transform.position + (controllerLeft.transform.position - controllerRight.transform.position)/2;
		sphere3.transform.position = middleOfControllers;
		lineRenderer.SetPosition(0,ball1.transform.position);
        lineRenderer.SetPosition(1,ball2.transform.position);
		ball1.transform.position = middleOfControllers - normalizedIntervalVector*5 ;
		ball2.transform.position = middleOfControllers + normalizedIntervalVector*5 ;
		lineRendererLeft.SetPosition(0,ball2.transform.position);
        lineRendererLeft.SetPosition(1,  middleOfControllers + normalizedIntervalVector*10);
		lineRendererRight.SetPosition(0,ball1.transform.position);
        lineRendererRight.SetPosition(1,  middleOfControllers - normalizedIntervalVector*10);
	
	}
}
