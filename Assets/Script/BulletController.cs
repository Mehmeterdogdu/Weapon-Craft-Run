using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int BulletDamage = 1;
    private float SpeedZ;
    private GameObject player;
    private float BulletLifeTimer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SpeedZ =player.GetComponent<PlayerController>().bulletSpeed;
        BulletLifeTimer = player.GetComponent<PlayerController>().BulletLifeTimer;
        Invoke("BulletDestroy", BulletLifeTimer);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + SpeedZ * Time.deltaTime);
    }

    void BulletDestroy()
    {
        Destroy(this.gameObject);
    }
}
