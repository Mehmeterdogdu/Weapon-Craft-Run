using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    private int BulletCount = 0;
    public GameObject ConnectedGate;
    private bool isTriggered=false;

    private void Update()
    {
        if (isTriggered)
        {
            if (-6f < transform.position.x)
            {
                transform.position = transform.position - new Vector3(0.1f,0,0);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,transform.position.y,ConnectedGate.transform.position.z+3f), 0.5f); ;
            }
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            BulletCount++;
            transform.GetChild(0).GetComponent<TextMeshPro>().text = BulletCount.ToString();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<SphereCollider>().isTrigger = false;
            isTriggered=true;
            ConnectedGate.GetComponent<GateWeaponLevelUP>().GateLevelUpdate(BulletCount);
        }
    }
}
