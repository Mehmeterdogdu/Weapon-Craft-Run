using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateWeaponLevelUP : MonoBehaviour
{
    // Start is called before the first frame update
    private int gateLevel=0;
    public int requaredBullet=2;

    private void Start()
    {
        transform.GetChild(1).GetComponent<TextMeshPro>().text = "0/" + requaredBullet.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().LevelUpWeapon(gateLevel);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }

    public void GateLevelUpdate(int value)
    {
        for(int i=1;i<=value/requaredBullet;i++)
        {
            gateLevel++;
        }
        transform.GetChild(0).GetComponent<TextMeshPro>().text = "Level " + gateLevel.ToString();

        transform.GetChild(1).GetComponent<TextMeshPro>().text = (value/requaredBullet).ToString()+"/" + requaredBullet.ToString();
    }
}
