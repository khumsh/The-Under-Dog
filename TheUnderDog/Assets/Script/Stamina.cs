using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {
    public static Slider progress;
    public Animator anim;
    public bool canRun;


    void Start() {
        progress = GetComponent<Slider>();
        anim = GetComponent<Animator>();
        canRun = true;
    }

	void Update ()
    {
        if (!Mover.isDead && Input.GetKey(KeyCode.LeftShift) && Mover.canRun)
        {
            progress.value -= 0.5f;
        }
        else
        {
            progress.value += 1f;
        }

        anim.SetFloat("Stamina", progress.value);

	}
}
