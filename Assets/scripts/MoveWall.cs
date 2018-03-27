using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour {
    public bool forward;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (forward)
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z + Time.deltaTime*5);

        else
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * 5);


    }
}
