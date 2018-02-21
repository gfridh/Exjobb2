using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Newtonsoft.Json;

public class BooliApi : MonoBehaviour {
    public string url;
    private string text;
    public string minLong = "16.65711";
    public string maxLong = "19.46937";
    public string maxLat ="59.9986";
    public string minLat = "58.67059";
    public int offset = 0;


        IEnumerator go()
    {
        string unique = GenerateId();
        string hashedText = hash("fridhg"+"1516652346"+"04q8PzkbcduSoqWDeg7sCH4xe61XuN4F0eO3E1Ax"+unique);
        Debug.Log(hashedText);
        hashedText = String.Join("", hashedText.Split('-'));
        url = "https://api.booli.se/listings?q=s&offset="+offset+"&limit=499&bbox="+minLat +","+minLong + "," + maxLat + "," + maxLong+"&callerId=fridhg&time=1516652346&unique="+unique+"&hash=" + hashedText;
        Debug.Log("bbox="+ minLat +","+minLong + "," + maxLat + "," + maxLong);
        using (WWW www = new WWW(url))
        {
            yield return www;

                var booliObject = JsonConvert.DeserializeObject<bigBooliObject>(www.text);
                print(www.text);
/*                 print(booliObject.listings[0]); */
/*                 print(booliObject.totalCount); */
                for (int i=0; i<booliObject.listings.Count;i++){
                    print (i);
                    string locationObject = JsonConvert.SerializeObject(booliObject.listings[i]);
                    var locationObject2 = JsonConvert.DeserializeObject<locationObject>(locationObject);
/*                     print(locationObject2.location); */

                    string locationObject3 = JsonConvert.SerializeObject(locationObject2.location);
                    var positionObject = JsonConvert.DeserializeObject<positionObject>(locationObject3);
    /*                 print(positionObject.position); */

                    string realPositionObject = JsonConvert.SerializeObject(positionObject.position);
                    var realPositionObject2 = JsonConvert.DeserializeObject<realPositionObject>(realPositionObject);
                    print(realPositionObject2.longitude);
                    print(realPositionObject2.latitude);
                }




/*             myObject = JsonUtility.FromJson<bigBooliObject>(www.text);
            string json = JsonUtility.ToJson(myObject); */
        } 
    }
        void Start()
    {
        StartCoroutine(go());
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
}

public class bigBooliObject {
    public List<object> listings;
    public string count;
    public int totalCount;
}

public class locationObject {
    public object location;
}

public class positionObject {
    public object position;
}

public class realPositionObject {
    public float longitude;
    public float latitude;
}