using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair_Behavior : MonoBehaviour {

    public int HealFactor;
    public float MaxHealPool;

    public void Update()
    {
        transform.Rotate(0f, 1f, 0f);
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.GetComponent<ShipControll>() == null)
        {
            return;
        }
        ShipControll Ship = coll.gameObject.GetComponent<ShipControll>();

        //Wenn das Schiff gelandet ist UND die Hp kleiner sind als das Maximum UND Die Ladung der station größer 0
        if (Ship.isLanded && Ship.HP < Ship.MaxHP && MaxHealPool >= 0)
        {
            //Geheilte HP ausrechnen
            float Heal =  HealFactor * Time.deltaTime;
            //HP von der Ladung Abziehen
            MaxHealPool -= Heal;
            //HP dem Schiff Hinzufügen
            Ship.HP += Heal;
            Debug.Log("Healed: "+Heal);
        }
    }
}
