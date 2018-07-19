using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sonar_Controll : MonoBehaviour {

    public float pingtime;
    RawImage img;
    // Use this for initialization
    void Start() {
        img = GetComponent<RawImage>();
        InvokeRepeating("Ping", pingtime, pingtime);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        img.CrossFadeAlpha(0, pingtime,false);
    }

    void Ping()
    {
        img.CrossFadeAlpha(1, 0, false);
    }
}
