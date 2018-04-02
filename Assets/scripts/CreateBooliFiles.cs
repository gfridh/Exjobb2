using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class CreateBooliFiles : MonoBehaviour {
	public string url;
    private string text;
	private string tempString;
    public string minLong = "16.65711";
    public string maxLong = "19.46937";
    public string maxLat ="59.9986";
    public string minLat = "58.67059";
    public int offset = 0;

	// Use this for initialization
	void Start () {
		List<object> allListings = new List<object>();
        StartCoroutine(go( allListings ));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	
	
	
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
    IEnumerator go( List<object>allListings)
    {
        yield return null;

        string unique = GenerateId();
        string hashedText = hash("fridhg"+"1516652346"+"04q8PzkbcduSoqWDeg7sCH4xe61XuN4F0eO3E1Ax"+unique);
        hashedText = String.Join("", hashedText.Split('-'));
        url = "https://api.booli.se/listings?isNewConstruction=0&offset="+offset+"&limit=499&bbox="+minLat +","+minLong + "," + maxLat + "," + maxLong+"&callerId=fridhg&time=1516652346&unique="+unique+"&hash=" + hashedText;
        using (WWW www = new WWW(url))
        {
            yield return www;
			tempString = www.text;
                var booliObject = JsonConvert.DeserializeObject<bigBooliObject>(tempString);
				
        
                for (int i=0; i<booliObject.listings.Count;i++){

                    allListings.Add(booliObject.listings[i]);

                }
                if(offset < booliObject.totalCount){
                using (StreamWriter file = File.CreateText(@"c:\Users/Claremont/Github/Exjobb2/Assets/jsonFiles/"+offset+".json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, booliObject);
                } 
                    StartCoroutine(go(allListings));
                    offset += 500;
                }
                else{
                    using (StreamWriter file = File.CreateText(@"c:\Users/Claremont/Github/Exjobb2/Assets/jsonFiles/"+offset+".json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Serialize(file, booliObject);
                        }
                      
            } 

        }

    } 
}


