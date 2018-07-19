using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

    public GameObject ship;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - ship.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(ship != null)
        {
            transform.position = ship.transform.position + offset;
        }
        
        else
        {
            Debug.Log("Debri null");
            ship = GameObject.FindGameObjectWithTag("Debris_Cockpit");
        }
	}
}
