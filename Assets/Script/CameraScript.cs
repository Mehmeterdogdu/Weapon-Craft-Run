using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private int Speed;
    public GameObject PlayerController;
    public float distanceCameraAndPlayer = 2.65f;
    private Vector3 PlayerPosition;
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PlayerPosition = PlayerController.GetComponent<Transform>().position;
        transform.position = new Vector3(PlayerPosition.x, transform.position.y, PlayerPosition.z - distanceCameraAndPlayer);
    }
}
