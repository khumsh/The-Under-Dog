/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMover : MonoBehaviour {
    public GameObject player;
    public GameObject road0, road1, testRoad0, testRoad1;
    public float distance;
    public int count = 0;
    private float road0z, road1z, testRoad0z, testRoad1z;
    private float width = 500f;

    // Update is called once per frame

    void Update () {
        road0z = road0.transform.position.z;
        road1z = road1.transform.position.z;
        testRoad0z = testRoad0.transform.position.z;
        testRoad1z = testRoad1.transform.position.z;
        distance = player.transform.position.z -  width * count;

            if (distance >= width)
            {
                distance = 0;
                count++;
                Reposition(road0z, road1z, testRoad0z, testRoad1z);
            }
    }

    void Reposition(float road0z, float road1z, float testRoad0z, float testRoad1z)
    {
        Vector3 offset = new Vector3(0f, 0f, width);
        
        if(count <= 4){
            if (road0z > road1z)
            {
                road1.transform.position = road1.transform.position + offset;


            } else if (road0z < road1z)
            {
                road0.transform.position = road0.transform.position + offset;
            }
        }else if(count > 4){
            if (testRoad0z > testRoad1z)
            {
                testRoad1.transform.position = testRoad1.transform.position + offset;


            } else if (testRoad0z < testRoad1z)
            {
                testRoad0.transform.position = testRoad0.transform.position + offset;
            }
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMover1 : MonoBehaviour {
    public GameObject player;
    public GameObject road0;
    public GameObject road1;
    public float distance;
    public int count = 0;
    private float road0z;
    private float road1z;
    private float width = 500f;

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
