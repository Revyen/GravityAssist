using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmg_Indicator_Control : MonoBehaviour {

    public ShipControll ship;
	// Use this for initialization
	void Start () {
		ship = GetComponentInParent<UI_Controller>().ship.GetComponent<ShipControll>();
    }
	
	// Update is called once per frame
	void Update () {
        int i = 0;
		foreach(SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>())
        {
            if(s.color.g > 0.5f)
            {
                s.color = new Color(ship.PartDmg[i] * 2, ship.PartDmg[i], ship.PartDmg[i++]);
            }
            else
            {
                s.color = new Color(ship.PartDmg[i] * 2, ship.PartDmg[i], ship.PartDmg[i++], (Mathf.Sin(Time.time * 4) + 1.0f) / 2.0f + 0.2f);
            }
            
        }
	}
}
