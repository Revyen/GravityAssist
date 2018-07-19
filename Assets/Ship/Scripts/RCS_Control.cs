using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCS_Control : MonoBehaviour {


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") > 0)
        {
            transform.GetChild(1).GetComponent<ParticleSystem>().Emit(1);
            transform.GetChild(2).GetComponent<ParticleSystem>().Emit(1);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.GetChild(0).GetComponent<ParticleSystem>().Emit(1);
            transform.GetChild(3).GetComponent<ParticleSystem>().Emit(1);
        }
    }
}
