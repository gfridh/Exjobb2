using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRaycast : MonoBehaviour
{
    public LineRenderer raycastLine;
    public GameObject houseMarker;
    public GameObject googleHolder;
    private GoogleApi googleScript;

    // Use this for initialization
    void Start()
    {
        googleScript = googleHolder.GetComponent<GoogleApi>();
        raycastLine.positionCount = 2;
        raycastLine.material = new Material(Shader.Find("Particles/Multiply"));
        raycastLine.SetColors(Color.blue, Color.blue);
        raycastLine = Instantiate(raycastLine);
        houseMarker = Instantiate(houseMarker);

    }

    // Update is called once per frame
    void Update()
    {
        if (googleScript.zoom > 11)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform.tag == "Map" || hit.transform.tag == "houseMarker" || hit.transform.tag == "house")
                {
                    {
                        houseMarker.transform.position = new Vector3(hit.point.x, hit.point.y, googleHolder.transform.position.z);
                        raycastLine.SetPosition(0, this.transform.position);
                        raycastLine.SetPosition(1, hit.point);
                    }
                }
                else
                {
                    raycastLine.SetPosition(0, this.transform.position);
                    raycastLine.SetPosition(1, this.transform.position);
                }
            }
            else
            {

            }
        }
        else
        {
            raycastLine.SetPosition(0, this.transform.position);
            raycastLine.SetPosition(1, this.transform.position);
        }




    }
}
