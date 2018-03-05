﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class BooliApi : MonoBehaviour {
    public string url;
    private string text;
    public string minLong = "16.65711";
    public string maxLong = "19.46937";
    public string maxLat ="59.9986";
    public string minLat = "58.67059";
    public int offset = 0;
    public GameObject googleHolder;
    private GoogleApi googleScript;
    private float houseInternalLat;
    private float houseInternalLon;
    public object[] allListings;
    

    private int oldZoom;
    bigBooliObject booliObject;

    public GameObject housePrefab;


        IEnumerator go( List<object>allListings)
    {
        yield return new WaitForSeconds(0.000001f);

         /* string unique = GenerateId();
        string hashedText = hash("fridhg"+"1516652346"+"04q8PzkbcduSoqWDeg7sCH4xe61XuN4F0eO3E1Ax"+unique);
        hashedText = String.Join("", hashedText.Split('-'));
        url = "https://api.booli.se/listings?isNewConstruction=0&offset="+offset+"&limit=499&bbox="+minLat +","+minLong + "," + maxLat + "," + maxLong+"&callerId=fridhg&time=1516652346&unique="+unique+"&hash=" + hashedText;
        using (WWW www = new WWW(url))
        {
            yield return www;

                var booliObject = JsonConvert.DeserializeObject<bigBooliObject>(www.text); 
        
                for (int i=0; i<booliObject.listings.Count;i++){

                    allListings.Add(booliObject.listings[i]);

                }
                if(offset < booliObject.totalCount){
                    using (StreamWriter file = File.CreateText(@"c:\Users/Bamse/"+offset+".json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Serialize(file, booliObject);
                        } 
                    StartCoroutine(go(allListings));
                    offset += 500;
                }
                else{
                    using (StreamWriter file = File.CreateText(@"c:\Users/Bamse/"+offset+".json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Serialize(file, booliObject);
                        }  */
                        int y = 0;
                    for (int z=0; z <= 8000; z+=500){
                        string objectText = File.ReadAllText(@"c:\Users/Claremont/Github/Exjobb2/Assets/jsonFiles/"+z+".json"); 
                        JObject o = JObject.Parse(objectText);
                        //booliObject = JsonConvert.DeserializeObject<bigBooliObject>(File.ReadAllText(@"c:\Users/Claremont/Github/Exjobb2/Assets/jsonFiles/"+z+".json"));  
                        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("house");
                        for (int i=0;  i< (int)o["count"];i++){
                            float longitude = (float)o["listings"][i]["location"]["position"]["longitude"];
                            float latitude = (float)o["listings"][i]["location"]["position"]["latitude"];
                                             
                                if(y > gameObjects.Length-1){
                                    GameObject house = Instantiate(housePrefab,new Vector3(0, 0 , 0 ), Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject; 
                                    placeHouseOnMap(longitude, latitude,house);
                                }
                                else{
                                    GameObject target = gameObjects[y];
                                    placeHouseOnMap(longitude,latitude,target);

                                }
                                y++;

                        }

/*                     } 

                } */

        } 
    }
        void Start()
    {
        /* booliObject = JsonConvert.DeserializeObject<bigBooliObject>(File.ReadAllText(@"c:\Users/Bamse/0.json")) */;
        googleScript = googleHolder.GetComponent<GoogleApi>();
        oldZoom = googleScript.zoom;
        List<object> allListings = new List<object>();
        StartCoroutine(go( allListings ));
    }
        void Update(){
            if(googleScript.zoom != oldZoom){
                offset = 0;
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("house");
                foreach (GameObject target in gameObjects) {

                    GameObject.Destroy(target);
                }
                List<object> allListings = new List<object>();
/*                 print(googleScript.zoom);
                print(oldZoom); */
                StartCoroutine(go( allListings ));
                oldZoom = googleScript.zoom;
            }

        }

    string hash(string text){
        SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
        UTF8Encoding utf8 = new UTF8Encoding();
        string newText = BitConverter.ToString(sha1.ComputeHash(utf8.GetBytes(text)));
        return(newText);

    }
    
private string GenerateId()
{
 long i = 1;
 foreach (byte b in Guid.NewGuid().ToByteArray())
 {
  i *= ((int)b + 1);
 }
 return string.Format("{0:x}", i - DateTime.Now.Ticks);
}

private void placeHouseOnMap(float longitude , float lat, GameObject target){
    googleScript = googleHolder.GetComponent<GoogleApi>();
    List<float> arrHouse = new List<float>();
    List<float> arrMiddle = new List<float>();
    arrHouse = GenerateCoordinates(longitude,lat);
    arrMiddle = GenerateCoordinates(googleScript.lon,googleScript.lat);
    houseInternalLon = (arrHouse[0]- arrMiddle[0])*64; 
    houseInternalLat = (arrMiddle[1]-arrHouse[1])*64; 
/*     houseInternalLat = (((lat - googleScript.lat)/((170/Mathf.Pow(2, googleScript.zoom)/2)*2))*64);
    houseInternalLon = ((longitude - googleScript.lon)/((360/Mathf.Pow(2, googleScript.zoom)/2)*2))*64; */
/*     print(houseInternalLat);
    print(houseInternalLon); */


        target.transform.parent = transform;
        if(houseInternalLat>64 || houseInternalLat< -64 || houseInternalLon< -64 || houseInternalLon>64){
            target.SetActive(false);
        }
        else{
            target.transform.localPosition = new Vector3(houseInternalLon,houseInternalLat,0);
        }
    


}
    private List<float> GenerateCoordinates(float longitude , float latitude)
    {
        List<float> arr = new List<float>();
        float lon_rad = longitude*Mathf.Deg2Rad;
		float lat_rad = latitude*Mathf.Deg2Rad;
		float n = Mathf.Pow(2, googleScript.zoom);
		float tileX = ((longitude + 180) / 360) * n;
		float firstArg = Mathf.Tan(lat_rad);
		float secondArg = 1.0f/Mathf.Cos((float)lat_rad);
		float tileY =n * (1-(Mathf.Log(Mathf.Tan(lat_rad)+(1/Mathf.Cos(lat_rad)),2.71828f)/Mathf.PI))/2;
        arr.Add(tileX);
        arr.Add(tileY);
        return arr;
    }

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

public class house{
    public int price;
}