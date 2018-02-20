
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleApi : MonoBehaviour
{

    public RawImage img;

    string url;

    public float lat;
    public float lon;

    LocationInfo li;

    public int zoom = 1;
    private int prevZoom;
    public int mapWidth = 512;
    public int mapHeight = 410;

    public enum mapType { roadmap, satellite, hybrid, terrain }
    public mapType mapSelected;
    public int scale;

    public GameObject camera;
    


    public IEnumerator Map()
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&key=AIzaSyBY5Tpg1Osyzes_4OKVqJ1udA8datBq5lE";
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();
        prevZoom = zoom;

    }
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Map());
        img = gameObject.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(zoom != prevZoom){
            StartCoroutine(Map());
        }
/*        var dist = Vector3.Distance(camera.transform.position, transform.position);
       // Debug.Log(dist);
        if(dist > 1000 && zoom != 8){
            zoom = 8;
            StartCoroutine(Map());
        }
        else if (dist>=600 && dist<=800 && zoom != 9){
            zoom = 10;
            StartCoroutine(Map());
        }
        else if (dist < 600 && dist>=400 && zoom != 10){
            zoom = 12;
            StartCoroutine(Map());
        }
        else if (dist < 400 && dist>=200 && zoom != 11){
            zoom = 14;
            StartCoroutine(Map());
        }
        else if (dist < 200 && zoom != 12){
            zoom = 16;
            StartCoroutine(Map());
        }
         */

    }
}