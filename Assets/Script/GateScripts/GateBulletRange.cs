using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateBulletRange : GateScript
{
    public override void Gateproperty(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            int BulletLevel=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().WeaponLevel;
            GateValue += GateAddNumber*BulletLevel;
            transform.GetChild(2).GetComponent<TextMeshPro>().text = GateValue.ToString();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangeLifeTime(GateValue/10);

            Destroy(this.gameObject);
        }

        
    }
}
