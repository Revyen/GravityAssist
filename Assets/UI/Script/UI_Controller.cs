using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {

    public GameObject ship;

    protected Text text;
    protected string tmp;
	// Use this for initialization
	void Start () {
        /*text = gameObject.GetComponentInChildren<Text>();
        tmp = text.text;*/
    }
	
	// Update is called once per frame
	void Update () {
        /*if(ship != null)
        {
            text.text = string.Format(tmp, ship.GetComponent<ShipControll>().HP, ship.GetComponent<Rigidbody2D>().velocity.magnitude, ship.GetComponent<ShipControll>().Fuel);
        }
        else
        {
            text.text = string.Format(tmp + "\n You died", "NaN", "NaN","NaN");
        }*/
        
    }
}
