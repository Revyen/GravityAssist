using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchView : MonoBehaviour {

    public Camera OtherCam;
    public Camera ActiveCamera;

    protected GameObject Ship;
    protected GameObject Player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Ship = GameObject.FindGameObjectWithTag("Ship");
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetButtonDown("Fire2") && Ship != null)
        {
            if (Ship.GetComponent<ShipControll>().isLanded)
            {
                ActiveCamera.enabled = !ActiveCamera.enabled;
                ActiveCamera.GetComponent<AudioListener>().enabled = !ActiveCamera.GetComponent<AudioListener>().enabled;
                Ship.GetComponent<ShipControll>().Useable = !Ship.GetComponent<ShipControll>().Useable;
                Player.GetComponent<Player_Control>().Useable = !Player.GetComponent<Player_Control>().Useable;
                Player.transform.localPosition = new Vector2(0, 0.9f);
                OtherCam.enabled = !OtherCam.enabled;
                OtherCam.GetComponent<AudioListener>().enabled = !OtherCam.GetComponent<AudioListener>().enabled;
            }
        }
    }
}
