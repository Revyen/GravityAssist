using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interior_Camera_Controller : MonoBehaviour {

    public GameObject Player;
    public Camera cam;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Player.GetComponent<Player_Control>().Useable)
        {
            Vector2 v2 = (Player.transform.position - cam.transform.position) * Time.deltaTime * 2;
            cam.transform.position += new Vector3(v2.x,v2.y, 0f);
        }
	}
}
