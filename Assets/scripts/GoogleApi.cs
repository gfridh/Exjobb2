
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleApi : MonoBehaviour
{

    public RawImage img;
    public GameObject plane;

    string url;

    public float lat;
    public float lon;

    LocationInfo li;

    public int zoom;
    private int prevZoom;
    public int mapWidth = 512;
    public int mapHeight = 410;

    public enum mapType { roadmap, satellite, hybrid, terrain }
    public mapType mapSelected;
    public int scale;
    private Material material;



    public IEnumerator Map()
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&key=AIzaSyBY5Tpg1Osyzes_4OKVqJ1udA8datBq5lE";
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        plane.GetComponent<Renderer>().material = material;
        /*         img.SetNativeSize(); */

    }
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Map());
        img = gameObject.GetComponent<RawImage>();
        /*         GetComponent<RectTransform>().sizeDelta = new Vector2( W, H) */
    }

    // Update is called once per frame
    void Update()
    {
        if (zoom != prevZoom)
        {
            print("zoomar");
            StartCoroutine(Map());
            prevZoom = zoom;
        }

    }
}