using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(!GetComponentInChildren<Camera>().enabled)
        {
            GetComponent<Animator>().Play("");
        }
	}
}
