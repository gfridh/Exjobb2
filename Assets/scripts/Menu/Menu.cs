using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
	public float radiusX = 0.0f;
	public float radiusY = 0.0f;
	public GameObject innerCircleButton;
	public GameObject outerCircleButton;

	private GameObject temp;
	public GameObject parent;


	// Use this for initialization
	void Start () {
		 List<string> bigButtons = new List<string>();
		 bigButtons.Add("price");
		 bigButtons.Add("date");
		 bigButtons.Add("houseType");
		 bigButtons.Add("area");

		placeButton(1,4,360,0,true,bigButtons);
/* 		placeButton(2,4,90,0,false);
		placeButton(2,3,90,90,false);
		placeButton(2,3,90,180,false);
		placeButton(2,1,90,270,false); */
			}
	// Update is called once per frame
			void Update () {
			if (Input.GetKeyDown("p")){
				List<string> priceButtons = new List<string>();
				priceButtons.Add("propertyPrice");
				priceButtons.Add("maxRent");
				priceButtons.Add("m2price");
				priceButtons.Add("priceReduced");
				placeButton(2,4,90,0,false,priceButtons);
            }
			else if (Input.GetKeyDown("d")){
				List<string> dateButtons = new List<string>();
				dateButtons.Add("constructionYear");
				dateButtons.Add("newProduction");
				dateButtons.Add("soonForSale");
				placeButton(2,3,90,90,false,dateButtons);
            }
		
	}
	private void placeButton(float radius, float numberOfObjects, float arc, float startOfArc, bool inner, List<string> list ){
		
		for (var i =0; i<numberOfObjects; i+=1)     
			{
				var angle = (i * Mathf.Deg2Rad*arc / numberOfObjects) + (startOfArc+(arc/numberOfObjects/2))*Mathf.Deg2Rad;
				var pos = new Vector3 (Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
				if(inner){
					temp = Instantiate(innerCircleButton, pos, Quaternion.identity);
					temp.tag = list[i] ;    
					temp.transform.parent = parent.transform;
					temp.transform.localPosition = pos;
					temp.transform.LookAt(parent.transform.position, transform.forward);
				}
				else{
					temp = Instantiate(outerCircleButton, pos, Quaternion.identity);
					temp.tag = list[i] ;    
					temp.transform.parent = parent.transform;
					temp.transform.localPosition = pos;
					temp.transform.LookAt(parent.transform.position, transform.forward);
				}    
	
		}
	}
}



