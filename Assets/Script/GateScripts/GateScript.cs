using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public String GateName ="deneme";
    public float GateAddNumber = 10f;
    public float GateValue = 0f;

    // Start is called before the first frame update
    void Start()
    {

        transform.GetChild(0).GetComponent<TextMeshPro>().text = GateName;

        if (GateAddNumber >= 0)
        {
            transform.GetChild(1).GetComponent<TextMeshPro>().text = "+" + GateAddNumber.ToString();
        }
        else
        {
            transform.GetChild(1).GetComponent<TextMeshPro>().text = "-" + GateAddNumber.ToString();
        }
        
        transform.GetChild(2).GetComponent<TextMeshPro>().text = GateValue.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        Gateproperty(other);

    }

    public virtual void Gateproperty(Collider other)
    {
    }


}
