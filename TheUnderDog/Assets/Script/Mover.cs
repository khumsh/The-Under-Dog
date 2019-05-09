using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{   

    public Animator dogAnimator;
    public Rigidbody dogrb;
    public float speed;
    public bool camSwitch = false;
    public Camera ForwardCam, BackCam;

    private int jumpCount = 0;
    public static bool isDead = false;
    private bool isGrounded = true;
    private bool isCollided = false;
    public static float xSpeed;
    public static bool canRun;
    public Text notEnoughStam;
    public Image sliderFill;

    // Use this for initialization
    void Start()
    {
        dogrb = GetComponent<Rigidbody>();
        dogAnimator = GetComponent<Animator>();
        canRun = true;
        speed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        xSpeed = xInput * 8f;
        if (Mover.isDead)
        {
            xSpeed = 0;
        }
        if (!isCollided)
        {

            Vector3 dogVector = new Vector3(xSpeed, 0, speed);
            dogrb.velocity = dogVector;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canRun)
        {
            dogAnimator.SetBool("Run", true);
            speed *= 2;

        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            dogAnimator.SetBool("Run", false);
            speed /= 2;

            if(Stamina.progress.value < 50){
                canRun = false;
                notEnoughStam.gameObject.SetActive(true);
                sliderFill.color = Color.red;
            }else{
                canRun = true;
                notEnoughStam.gameObject.SetActive(false);
                sliderFill.color = Color.yellow;
            }
        }

        if(!isDead && Stamina.progress.value <= 0)
        {
            canRun = false;
            dogAnimator.SetBool("Run", false);
        }
        else if(!isDead && dogAnimator.GetBool("Run"))
        {
            speed = 40f;
        }
        else if(!isDead)
        {
            speed = 20f;
        }
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            camSwitch = !camSwitch;
            ForwardCam.gameObject.SetActive(!camSwitch);
            BackCam.gameObject.SetActive(camSwitch);
        } else if (Input.GetKeyUp(KeyCode.Space))
        {
            camSwitch = !camSwitch;
            ForwardCam.gameObject.SetActive(!camSwitch);
            BackCam.gameObject.SetActive(camSwitch);
        }
        if (!isDead && Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < 1 && canRun)
        {
            dogrb.AddForce(Vector3.up * 3000f, ForceMode.Impulse);
            dogAnimator.SetBool("Jump", true);
            isGrounded = false;
            Stamina.progress.value -= 20f;
            jumpCount++;
            
        }

        if (isCollided)
        {
            dogrb.velocity = new Vector3(xSpeed, 0, 0);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ground")
        {
            isGrounded = true;
            dogAnimator.SetBool("Jump", false);
            jumpCount = 0;

        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Prefab")
        {
            isCollided = true;
        }
        else { isCollided = false; }
    }

    public void Die()
    {

        if (!isDead) { 
        isDead = true;
        dogAnimator.SetTrigger("Die");
        speed = 0f;
 
        }
    }
}
