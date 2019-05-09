using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCamera : MonoBehaviour {
    public GameObject player;

    // Use this for initialization
    public float offsetX = 0f;
    public float offsetY = -50f;
    public float offsetZ = -35f;

    Vector3 cameraPosition;
    Vector3 cameraRotation;

    void LateUpdate()
    {
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = 0 + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;
       
        transform.position = cameraPosition;
    }
}
