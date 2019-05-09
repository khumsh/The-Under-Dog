using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class REGAME : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        Invoke("Regame", 8);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Intro");
        }
    }

    public void Regame()
    {
        SceneManager.LoadScene("Intro");
    }
}