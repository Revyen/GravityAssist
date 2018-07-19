using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltitudeTach_Control : MonoBehaviour {

    public ShipControll ship;
    protected Meter_Controll[] texts;
	// Use this for initialization
	void Start () {
        texts = GetComponentsInChildren<Meter_Controll>();
        ship = GetComponentInParent<UI_Controller>().ship.GetComponent<ShipControll>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if(GetComponentInParent<UI_Controller>().ship != null)
        {
            texts[0].value = ship.Altitude * 10;
            texts[1].value = ship.GetComponent<Rigidbody2D>().velocity.x * 10;
            if(Mathf.Abs(ship.GetComponent<Rigidbody2D>().velocity.x) < ship.dmgModifier)
            {
                texts[1].marc.gameObject.SetActive(false);
            }
            else
            {
                texts[1].marc.gameObject.SetActive(true);
            }
            texts[2].value = ship.GetComponent<Rigidbody2D>().velocity.y * 10;
            if (Mathf.Abs(ship.GetComponent<Rigidbody2D>().velocity.y) < ship.dmgModifier)
            {
                texts[2].marc.gameObject.SetActive(false);
            }
            else
            {
                texts[2].marc.gameObject.SetActive(true);
            }
        }
        
    }
}
