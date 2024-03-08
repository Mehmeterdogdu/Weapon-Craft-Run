using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public float HitPoint;

    private void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshPro>().text = HitPoint.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            HitPoint = HitPoint - other.GetComponent<BulletController>().BulletDamage;
            transform.GetChild(0).GetComponent<TextMeshPro>().text = HitPoint.ToString();
            Destroy(other.gameObject);
            if(HitPoint<=0)
                Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().LoseGame();
            
        }
    }
}
