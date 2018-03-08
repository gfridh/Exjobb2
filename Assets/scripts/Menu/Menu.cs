using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Menu : MonoBehaviour {
	private bool leftmenuActive = false;
	private bool rightmenuActive = false;
	private bool menuUp = false;
	private bool rightMenuStuck = false;
	private bool leftMenuStuck = false;
	public float radiusX = 0.0f;
	public float radiusY = 0.0f;
	public GameObject innerCircleButton;
	public GameObject outerCircleButton;

	private GameObject temp;
	public GameObject parent;
	public GameObject head;

	public GameObject leftControllerObject;
	VRTK_ControllerEvents controllerEventsLeft;
	public GameObject rightControllerObject;
	VRTK_ControllerEvents controllerEventsRight;
	public GameObject interval;
	private GameObject smallInterval;
	private line interValScript;
	private bool intervalUp = false;
	private GameObject instantiatedInterval;


	// Use this for initialization
	void Start () {
		leftControllerObject.GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(LeftTriggerClicked);
		rightControllerObject.GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(RightTriggerClicked);
/* 		placeButton(2,4,90,0,false);
		placeButton(2,3,90,90,false);
		placeButton(2,3,90,180,false);
		placeButton(2,1,90,270,false); */
			}
	// Update is called once per frame
	void Update () {
		parent.transform.LookAt(head.transform.position);
	}
	public void placeButton(float radius, float numberOfObjects, float arc, float startOfArc, bool inner, List<string> list ){
		
		for (var i =0; i<numberOfObjects; i+=1)     
			{
				var angle = (i * Mathf.Deg2Rad*arc / numberOfObjects) + (startOfArc+(arc/numberOfObjects/2))*Mathf.Deg2Rad;
				var pos = new Vector3 (Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
				if(inner){
					temp = Instantiate(innerCircleButton, pos, Quaternion.identity);
					temp.transform.parent = parent.transform;

					temp.tag = list[i] ;    
//					temp.transform.parent = parent.transform;
					temp.transform.localPosition = pos;
//					temp.transform.LookAt(parent.transform.parent.transform.position);

				}
				else{
					temp = Instantiate(outerCircleButton, pos, Quaternion.identity);
					temp.tag = list[i] ;    
					temp.transform.parent = parent.transform;
					temp.transform.localPosition = pos;
					temp.transform.LookAt(parent.transform.position);
				}    
	
		}
	}

        private void RightTriggerClicked(object sender, ControllerInteractionEventArgs e)
        {
			if(leftmenuActive){
				foreach (Transform child in parent.transform) {
     				GameObject.Destroy(child.gameObject);
 				}
				leftmenuActive = false;
				leftMenuStuck = false;
			}
			if(!rightmenuActive){
				print("triggerClicked");
				parent.transform.position = rightControllerObject.transform.position;
				parent.transform.parent = rightControllerObject.transform;
				List<string> bigButtons = new List<string>();
				bigButtons.Add("price");
				bigButtons.Add("date");
				bigButtons.Add("houseType");
				bigButtons.Add("area");
				placeButton(1,4,360,0,true,bigButtons);
				rightmenuActive = true;
			}
			else{
				if(!rightMenuStuck){
					parent.transform.parent = null;
					rightMenuStuck = true;
				}
				else{
					 foreach (Transform child in parent.transform) {
     					GameObject.Destroy(child.gameObject);
 					}
					rightmenuActive = false;
					rightMenuStuck = false;
				}
			}

        }


		private void LeftTriggerClicked(object sender, ControllerInteractionEventArgs e)
        {

			if(rightmenuActive){
				foreach (Transform child in parent.transform) {
     				GameObject.Destroy(child.gameObject);
 				}
				rightmenuActive = false;
				rightMenuStuck = false;
			}

			if(!leftmenuActive){
				print("triggerClicked");
				parent.transform.position = leftControllerObject.transform.position;
				parent.transform.parent = leftControllerObject.transform;
				List<string> bigButtons = new List<string>();
				bigButtons.Add("price");
				bigButtons.Add("date");
				bigButtons.Add("houseType");
				bigButtons.Add("area");
				placeButton(1,4,360,0,true,bigButtons);
				leftmenuActive = true;
			}
			else{
				if(!leftMenuStuck){
					parent.transform.parent = null;
					leftMenuStuck = true;
				}
				else{
					 foreach (Transform child in parent.transform) {
     					GameObject.Destroy(child.gameObject);
 					}
					leftmenuActive = false;
					leftMenuStuck = false;
				}
			}

        }
}



