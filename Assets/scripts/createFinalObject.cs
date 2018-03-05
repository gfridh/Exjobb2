using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Newtonsoft.Json;

public class createFinalObject : MonoBehaviour {

	bigBooliObject booliObject;

	// Use this for initialization
	void Start () {
		StreamWriter writer = new StreamWriter(@"c:\Users/Bamse/.json", true);
		List<object> locationList = new List<object>();
		for (int i=0; i <= 8000; i+=500){
			booliObject = JsonConvert.DeserializeObject<bigBooliObject>(File.ReadAllText(@"c:\Users/Bamse/"+i+".json"));
            for (int y=0; i<booliObject.listings.Count;y++){
				string locationObject = JsonConvert.SerializeObject(booliObject.listings[y]);
				var locationObject2 = JsonConvert.DeserializeObject<locationObject>(locationObject);

				string locationObject3 = JsonConvert.SerializeObject(locationObject2.location);
				var positionObject = JsonConvert.DeserializeObject<positionObject>(locationObject3);

				string realPositionObject = JsonConvert.SerializeObject(positionObject.position);
				var realPositionObject2 = JsonConvert.DeserializeObject<realPositionObject>(realPositionObject);
				if(locationList.Contains(realPositionObject2.longitude)==false){

					
				}

			}
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public class bigBooliObject {
    public List<object> listings;
    public int count;
    public int totalCount;
}

public class locationObject {
    public object location;
    public int listprice;
}

public class positionObject {
    public object position;
}

public class realPositionObject {
    public float longitude;
    public float latitude;
}
}
