using UnityEngine;
using System.Collections;

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

    private float startingDistance;
    private float prevDistance;


    void Start()
    {
        cam = GetComponent<Camera>();
        googleScript = googleHolder.GetComponent<GoogleApi>();
        currentMiddlelatitude = googleScript.lat;
        currentMiddlelongitude = googleScript.lon;
        zoomLevel = googleScript.zoom;
        startingDistance = Vector3.Distance (transform.position, googleHolder.transform.position);
        prevDistance = startingDistance;
    }

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
/*         print(ray); */
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            internalCoordinates = map.transform.InverseTransformPoint( hit.point );
/*             print(((internalCoordinates.y/256)*(170/Mathf.Pow(2, zoomLevel)/2)*2 + currentMiddlelatitude));
            print((internalCoordinates.x/256)*(360/Mathf.Pow(2, zoomLevel)/2)*2 + currentMiddlelongitude); */
            print(prevDistance - Vector3.Distance (transform.position, googleHolder.transform.position));
            
            if (prevDistance - Vector3.Distance (transform.position, googleHolder.transform.position) > 0.5f || prevDistance - Vector3.Distance (transform.position, googleHolder.transform.position) < -0.5f ){
                prevDistance = Vector3.Distance (transform.position, googleHolder.transform.position);
                prevZoom = googleScript.zoom;
                googleScript.lat = (internalCoordinates.y/64)*(170/Mathf.Pow(2, zoomLevel)/2)*2 + currentMiddlelatitude;
                googleScript.lon = (internalCoordinates.x/64)*(360/Mathf.Pow(2, zoomLevel)/2)*2 + currentMiddlelongitude;
                if(prevDistance - Vector3.Distance (transform.position, googleHolder.transform.position) > 0.5f){
                    googleScript.zoom --;
                    zoomLevel --;
                }
                else if(prevDistance - Vector3.Distance (transform.position, googleHolder.transform.position) < -0.5f){
                    googleScript.zoom ++;
                    zoomLevel ++;
                }
                
/*                 print(googleScript.lat);
                print(googleScript.lon); */
                currentMiddlelatitude = googleScript.lat;
                currentMiddlelongitude = googleScript.lon;
                StartCoroutine(googleScript.Map());
            }
            
        }
        else{
            /*             print("I'm looking at nothing!"); */
        }

        Cube.transform.position = hit.point;
    }
}