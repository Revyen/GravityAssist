using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris_Controller : MonoBehaviour {

    public Vector2 parentForce;
	// Use this for initialization
	void Start () {
        Rigidbody2D[] debris = gameObject.GetComponentsInChildren<Rigidbody2D>();
        foreach(Rigidbody2D d in debris)
        {
            Debug.Log("My speed is: "+ parentForce.ToString());
            d.AddRelativeForce(parentForce,ForceMode2D.Impulse);
            d.AddRelativeForce(new Vector2(Random.Range(-10,10),Random.Range(-10,10)), ForceMode2D.Impulse);
            foreach (Rigidbody2D g in debris)
            {
                Physics2D.IgnoreCollision(g.gameObject.GetComponent<Collider2D>(),GetComponent<Collider2D>());
            }
            Debug.Log("My speed is: "+ d.velocity.ToString());
        }
        //random Inpulse
        //gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(Random.Range(-3,3),Random.Range(-3,3)),ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void Update () {


    }
}
