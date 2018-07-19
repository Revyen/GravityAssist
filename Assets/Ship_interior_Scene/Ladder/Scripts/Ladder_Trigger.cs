using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Trigger : MonoBehaviour {

    public float speed = 6;
    private void OnTriggerExit2D(Collider2D coll)
    {
        coll.GetComponent<Player_Control>().isClimbing = false;
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag == "Player" && (Input.GetAxis("Vertical") > 0) && coll.GetComponent<Player_Control>().Useable)
        {
            coll.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            coll.GetComponent<Player_Control>().isClimbing = true;
        }
        else if(coll.tag == "Player" && (Input.GetAxis("Vertical") < 0))
        {
            coll.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else
        {
            coll.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.1f);
        }
    }
}
