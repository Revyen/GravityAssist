using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap_Rocket_Control : MonoBehaviour {

    GameObject Ship;
	// Use this for initialization
	void Start () {
        Ship = GetComponentInParent<UI_Controller>().ship;
	}
	
	// Update is called once per frame
	void Update () {
        if(Ship != null)
        {
            transform.rotation = Ship.transform.rotation;
        }
	}
}
