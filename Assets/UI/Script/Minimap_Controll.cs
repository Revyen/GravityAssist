using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap_Controll : MonoBehaviour {

    public Transform ship;

    private Vector3 offset;
    private void Start()
    {
        offset = transform.position - ship.transform.position;
    }
    void LateUpdate()
    {
        if (ship != null)
        {
            transform.position = ship.position + offset;
        }
    }
}
