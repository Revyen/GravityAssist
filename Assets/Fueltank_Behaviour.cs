using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fueltank_Behaviour : MonoBehaviour {

    public GameObject Ship;
    public float duration;
    public float smoothness;

    // Use this for initialization
    void Start () {
        Ship = GameObject.FindGameObjectWithTag("Ship");

    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            if(Input.GetButtonDown("Fire3"))
            {
                StartCoroutine(Repair(coll));
            }
        }
    }

    IEnumerator Repair(Collider2D coll)
    {
        coll.GetComponent<Player_Control>().Useable = false;
        float progress = 0;
        float increment = smoothness / duration;
        while(progress < 1)
        {
            Ship.GetComponent<ShipControll>().PartDmg[1] = Mathf.Lerp(Ship.GetComponent<ShipControll>().PartDmg[1], 1, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        coll.GetComponent<Player_Control>().Useable = true;
        yield return true;

        
        
        

    }
}
