using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar_Control : MonoBehaviour
{

    public ShipControll ship;
    public Image fill;
    // Use this for initialization
    void Start()
    {
        ship = GetComponentInParent<UI_Controller>().ship.GetComponent<ShipControll>();
        GetComponent<Slider>().maxValue = ship.Fuel;
        foreach (Image i in GetComponentsInChildren<Image>())
        {
            if (i.gameObject.name == "Fill")
            {
                fill = i;
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GetComponentInParent<UI_Controller>().ship == null)
        {
            GetComponent<Slider>().value = 0;
            fill.enabled = false;
        }
        else
        {
            GetComponent<Slider>().value = ship.Fuel;
        }
        if (ship.Fuel < ship.MaxFuel * 0.5f)
        {
            if (ship.Fuel > ship.MaxFuel * 0.2f)
            {
                fill.color = new Color(1, 0.5f, 0);
            }
            else
            {
                fill.color = new Color(1, 0, 0, (Mathf.Sin(Time.time * 4) + 1.0f) / 2.0f + 0.2f);
            }
        }
        else
        {
            fill.color = new Color(1, 1, 1);
        }
    }
}
