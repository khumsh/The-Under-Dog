using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBackCamera : MonoBehaviour {
    public GameObject player;

    // Use this for initialization
    public float offsetX = 0f;
    public float offsetY = -50f;
    public float offsetZ = 35f;


    Vector3 cameraPosition;
    Vector3 cameraRotation;

    void Update()
    {

        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        transform.position = cameraPosition;


    }
}
