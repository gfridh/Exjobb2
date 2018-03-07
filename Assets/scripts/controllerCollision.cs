using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerCollision : MonoBehaviour {
	public GameObject menuController;
    private Menu menuScript;

	// Use this for initialization
	void Start () {
		menuScript = menuController.GetComponent<Menu>();
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    void OnTriggerEnter(Collider other) {
		print(other.tag);
        if(other.tag == "price"){
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
			dateButtons.Add("newProduction");
			dateButtons.Add("soonForSale");
			menuScript.placeButton(3,3,90,90,false,dateButtons);
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
}