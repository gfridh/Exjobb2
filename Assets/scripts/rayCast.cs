﻿using UnityEngine;
using System.Collections;
using System;
using VRTK;

public class rayCast : MonoBehaviour
{
    Camera cam;
    public GameObject map;
    public GameObject Cube;
    private Vector3 internalCoordinates;
    public float currentMiddlelongitude;
    public float currentMiddlelatitude;
    private int zoomLevel;
    private int prevZoom = 0;
    public GameObject googleHolder;
    private GoogleApi googleScript;

    private float prevDistance;
    private float prevLat;
    private float prevLon;
    private bool start = true;
    public GameObject dataLoggerHolder;
    public DataLogger dataloggerScript;
    public GameObject loadingBar;
    public bool loadingbarOnTop = false;
    public Material red;
    public Material blue;
    public GameObject leftController;
    public bool touchpadPressed = false;
    public Vector2 touchAxis;


    void Start()
    {
        leftController.GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(TouchpadPressed);
        cam = GetComponent<Camera>();
        googleScript = googleHolder.GetComponent<GoogleApi>();
        currentMiddlelatitude = googleScript.lat;
        currentMiddlelongitude = googleScript.lon;
        zoomLevel = googleScript.zoom;
        dataloggerScript = dataLoggerHolder.GetComponent<DataLogger>();
    }

    void Update()
    {
        touchAxis = leftController.GetComponent<VRTK_ControllerEvents>().GetTouchpadAxis();
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        /*         print(ray); */
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Map" || hit.transform.tag == "house" || hit.transform.tag == "houseMarker")
            {
                internalCoordinates = map.transform.InverseTransformPoint(hit.point);
                if (internalCoordinates.y < -32 && loadingbarOnTop == false)
                {

                    loadingBar.transform.localPosition = new Vector3(loadingBar.transform.localPosition.x, 3.2f, loadingBar.transform.localPosition.z);
                    loadingbarOnTop = true;
                }

                else if (internalCoordinates.y > -32 && loadingbarOnTop == true)
                {
                    loadingBar.transform.localPosition = new Vector3(loadingBar.transform.localPosition.x, -3.2f, loadingBar.transform.localPosition.z);
                    loadingbarOnTop = false;
                }


                /*             print(((internalCoordinates.y/256)*(170/Mathf.Pow(2, zoomLevel)/2)*2 + currentMiddlelatitude));
                            print((internalCoordinates.x/256)*(360/Mathf.Pow(2, zoomLevel)/2)*2 + currentMiddlelongitude); */
                Color tmp = Cube.GetComponent<SpriteRenderer>().color;
                //tmp.a = (Mathf.Abs(movementDifference)/0.15f);



                Cube.GetComponent<SpriteRenderer>().color = tmp;
                if (touchpadPressed)
                {
                    prevZoom = googleScript.zoom;
                    if (touchAxis.y > 0)
                    {
                        touchpadPressed = false;
                        float lon_rad = googleScript.lon * Mathf.Deg2Rad;
                        float lat_rad = googleScript.lat * Mathf.Deg2Rad;
                        float n = Mathf.Pow(2, googleScript.zoom);
                        float tileX = ((googleScript.lon + 180) / 360) * n;
                        float tileY = n * (1 - (Mathf.Log(Mathf.Tan(lat_rad) + (1 / Mathf.Cos(lat_rad)), 2.71828f) / Mathf.PI)) / 2;
                        float lon_deg = (tileX + (internalCoordinates.x / 64)) / n * 360 - 180;
                        float lat_rad2 = Mathf.Atan((float)Math.Sinh(Mathf.PI * (1 - 2 * (tileY - (internalCoordinates.y / 64)) / n)));
                        float lat_deg = lat_rad2 * 180.0f / Mathf.PI;
                        googleScript.lat = lat_deg;
                        googleScript.lon = lon_deg;
                        prevLat = googleScript.lat;
                        prevLon = googleScript.lon;
                        googleScript.zoom += 1;
                        if (googleScript.zoom == 13 && prevZoom == 12)
                        {
                            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("house");
                            foreach (GameObject target in gameObjects)
                            {
                                target.transform.localScale = new Vector3(1, 4, 1);
                            }
                        }

                        zoomLevel += 1;
                        dataloggerScript.zoomIn += 1;


                        prevDistance = (transform.position - googleHolder.transform.position).z;
                    }
                    else if (touchAxis.y < 0 && prevZoom != 8 && prevZoom != 8)
                    {
                        touchpadPressed = false;

                        if (prevZoom == 9)
                        {
                            googleScript.lat = 59.33459f;
                            googleScript.lon = 18.06324f;
                        }
                        else
                        {
                            googleScript.lat = prevLat;
                            googleScript.lon = prevLon;
                        }


                        googleScript.zoom -= 1;
                        zoomLevel -= 1;
                        dataloggerScript.zoomOut += 1;

                        if (googleScript.zoom == 12 && prevZoom == 13)
                        {
                            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("house");
                            foreach (GameObject target in gameObjects)
                            {
                                target.transform.localScale = new Vector3(0.5f, 1, 0.5f);
                            }
                        }

                        prevDistance = (transform.position - googleHolder.transform.position).z;
                    }

                    else if (touchAxis.y < 0 && prevZoom == 8)
                    {
                        touchpadPressed = false;
                    }

                    /*                 print(googleScript.lat);
                                    print(googleScript.lon); */
                    currentMiddlelatitude = googleScript.lat;
                    currentMiddlelongitude = googleScript.lon;
                    StartCoroutine(googleScript.Map());
                }
                if (start)
                {
                    start = false;
                    touchpadPressed = false;
                    prevDistance = (transform.position - googleHolder.transform.position).z;
                }

                Cube.transform.position = new Vector3(hit.point.x,hit.point.y, googleHolder.transform.position.z);
            }

        }
        else
        {
        }

    }

    private void TouchpadPressed(object sender, ControllerInteractionEventArgs e)
    {
        touchpadPressed = true;
        

    }

}