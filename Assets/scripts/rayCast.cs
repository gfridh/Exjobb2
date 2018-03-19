using UnityEngine;
using System.Collections;
using System;

public class rayCast : MonoBehaviour
{
    Camera cam;
    public GameObject map;
    public GameObject Cube;
    private Vector3 internalCoordinates;
    public float currentMiddlelongitude ;
    public float currentMiddlelatitude ;
    private int zoomLevel;
    private int prevZoom = 0;
    public GameObject googleHolder;
    private GoogleApi googleScript;

    private float movementDifference;
    private float prevDistance;
    private float prevLat;
    private float prevLon;
    private bool start = true;


    void Start()
    {
        cam = GetComponent<Camera>();
        googleScript = googleHolder.GetComponent<GoogleApi>();
        currentMiddlelatitude = googleScript.lat;
        currentMiddlelongitude = googleScript.lon;
        zoomLevel = googleScript.zoom;
    }

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
/*         print(ray); */
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Map")
        {
            internalCoordinates = map.transform.InverseTransformPoint( hit.point );
            /*             print(((internalCoordinates.y/256)*(170/Mathf.Pow(2, zoomLevel)/2)*2 + currentMiddlelatitude));
                        print((internalCoordinates.x/256)*(360/Mathf.Pow(2, zoomLevel)/2)*2 + currentMiddlelongitude); */
            Color tmp = Cube.GetComponent<SpriteRenderer>().color;
            print((Mathf.Abs(movementDifference) / 0.3f));
            tmp.a = (Mathf.Abs(movementDifference)/0.3f);
            Cube.GetComponent<SpriteRenderer>().color = tmp;
            if (movementDifference > 0.3f || movementDifference < -0.3f ){
                prevZoom = googleScript.zoom;
                if(prevDistance - Vector3.Distance (transform.position, googleHolder.transform.position) > 0.3f){
                    googleScript.lat = (internalCoordinates.y / 64) * (170 / Mathf.Pow(2, zoomLevel) / 2) * 2 + currentMiddlelatitude;
                    googleScript.lon = (internalCoordinates.x / 64) * (360 / Mathf.Pow(2, zoomLevel) / 2) * 2 + currentMiddlelongitude;
                    prevLat = googleScript.lat;
                    prevLon = googleScript.lon;
                    googleScript.zoom += 2;
                    zoomLevel += 2;
                    
                    prevDistance = Vector3.Distance (transform.position, googleHolder.transform.position);
                }
                else if(prevDistance - Vector3.Distance (transform.position, googleHolder.transform.position) < -0.3f && prevZoom != 8){
                    googleScript.lat = prevLat;
                    googleScript.lon = prevLon;

                    googleScript.zoom -= 2;
                    zoomLevel -= 2;
                    
                    prevDistance = Vector3.Distance (transform.position, googleHolder.transform.position);
                }
                
                
/*                 print(googleScript.lat);
                print(googleScript.lon); */
                currentMiddlelatitude = googleScript.lat;
                currentMiddlelongitude = googleScript.lon;
                StartCoroutine(googleScript.Map());
            }
            if(start){
                movementDifference = 0;
                start = false;
                prevDistance = Vector3.Distance (transform.position, googleHolder.transform.position);
            }
            else{
                movementDifference = prevDistance - Vector3.Distance (transform.position, googleHolder.transform.position);
            }
            Cube.transform.position = hit.point;
        }
        else{
        }

    }

}