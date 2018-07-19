using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter_Controll : MonoBehaviour {

    public float value;
    protected string text;
    public Text marc;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>().text;

    }
	
	// Update is called once per frame
	void LateUpdate () {
        if(GetComponentInParent<UI_Controller>().ship == null)
        {
            GetComponent<Text>().text = string.Format(text, "NaN");
        }
        else
        {
            GetComponent<Text>().text = string.Format(text, value);
        }
        
	}
}
