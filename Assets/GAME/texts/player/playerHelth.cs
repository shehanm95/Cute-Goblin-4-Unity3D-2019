using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHelth : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject BackgroundSoundClip;
    private SM SM;

    [Header("ABOUT HELTH")]
    public Slider helthbar;
    public Text helthText;
    public float maxhelth = 100f;
    public float curHelth;
    public float bounesHelth = 15f;

    public float EnemyHelthReduser = 3f;
    public float FireHelthReduser = 0.2f;
    public float water;

    [Header("On Wi Fi Button")]
    public GameObject AdPlayButton;
    

    //dead
    public bool deads = false;
    Animator anim1;
    public GameObject button;
    // Use this for initialization
    void Start()
    {
        SM = FindObjectOfType<SM>();
        GameOver.SetActive(false);

        //normal helth
        if (curHelth == 100f)
        {
            helthbar.value = maxhelth;
        }

        if (curHelth != 100f)
        {
            curHelth = helthbar.value;
            
        }

        curHelth = helthbar.value;
        

        //dead
        anim1 = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        helthText.text = helthbar.value.ToString("0") + "%";
        OnWiFiButtonfunc();
        deadfunction();

        //dead

        if (helthbar.value < 1)
        {
            deads = true;
            // anim1.SetBool("isIdle", false);
            //anim1.SetBool("isDead", true);
        }
        
    }

    public void deadfunction()
    {
        if (deads)
        {
            print("died");
            button.SetActive(false);
            GetComponent<playerContraller>().enabled = false;
           BackgroundSoundClip.SetActive(false);
           GameOver.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "saw")
        {
            helthbar.value -= 0.5f;
            curHelth = helthbar.value;
        }

        if (collision.gameObject.tag == "water")
        {

            helthbar.value -= water;
            curHelth = helthbar.value;

        }

        if (collision.gameObject.tag == "enemy")
        {
            helthbar.value -= EnemyHelthReduser;
            curHelth = helthbar.value;
            SM.damagesound();
            
        }

        if (collision.gameObject.tag == "fire")
        {
            helthbar.value -= FireHelthReduser;
            curHelth = helthbar.value;
            SM.damagesound();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "helth")
        {

            if (curHelth < maxhelth)
            {
                helthbar.value = helthbar.value + bounesHelth;



            }
        }
        if (collision.gameObject.tag == "water")
        {
            SM.JuimpWatersound();
        }


     }



    public void OnWiFiButtonfunc()
    {
        if (helthbar.value > 40)
        {


            AdPlayButton.SetActive(false);
            

        }
        if (helthbar.value < 40)
        {
            AdPlayButton.SetActive(true);
            
        }
    }

    public void addhelth()
    {
        helthbar.value = helthbar.value + 40f;
    }

}

// ==================== helth script instructions ===========

// 1. you need to fill slider valus 
// - sing unity.UI
// - max 100
// - whole
// - left to right
// - fill the publics


