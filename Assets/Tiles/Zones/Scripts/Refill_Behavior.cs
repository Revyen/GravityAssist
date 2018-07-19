using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refill_Behavior : MonoBehaviour {

    public int RefuelFactor;
    public float MaxFuelReserve;

    private void Update()
    {
        transform.Rotate(0f, 1f, 0f);
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.GetComponent<ShipControll>() == null)
        {
            return;
        }
        ShipControll Ship = coll.gameObject.GetComponent<ShipControll>();

        //Wenn das Schiff gelandet ist UND der Treibstoff kleiner ist als das Maximum UND Die Ladung der station größer 0
        if (Ship.isLanded && Ship.Fuel < Ship.MaxHP && MaxFuelReserve >= 0)
        {
            //Getankten Treibstoff ausrechnen
            float Pumped = RefuelFactor * Time.deltaTime;
            //Triebstoff von der Ladung Abziehen
            MaxFuelReserve -= Pumped;
            //Treibstoff dem Schiff Hinzufügen
            Ship.Fuel += Pumped;
            Debug.Log("Healed: " + Pumped);
        }
    }
}
