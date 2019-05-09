using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMover : MonoBehaviour {
    public GameObject player;
    public GameObject road0;
    public GameObject road1;
    public float distance;
    public int count = 0;
    private float road0z;
    private float road1z;
    private float width = 495f;

    // Update is called once per frame

    void Update () {
        road0z = road0.transform.position.z;
        road1z = road1.transform.position.z;
        distance = player.transform.position.z -  width * count;

            if (distance >= width)
            {
                distance = 0;
                count++;
                Reposition(road0z, road1z);

            }
    }

    void Reposition(float road0z, float road1z)
    {
        Vector3 offset = new Vector3(0f, 0f, 2 * width);
        

        if (road0z > road1z)
        {
            road1.transform.position = road1.transform.position + offset;


        } else if (road0z < road1z)
        {
            road0.transform.position = road0.transform.position + offset;
        }
    }
}
