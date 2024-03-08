using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateBulletFireRate : GateScript
{

    public override void Gateproperty(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            GateValue += GateAddNumber;
            transform.GetChild(2).GetComponent<TextMeshPro>().text = GateValue.ToString();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangeFireRate(GateValue);
            Destroy(this.gameObject);
        }

        
    }
}
