using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    void Update()
    {
        //transform.LookAt(player.transform.position);
        transform.position = player.transform.position + offset;
    }
}
