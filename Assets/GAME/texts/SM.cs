using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM : MonoBehaviour
{
    public AudioSource fire, jump, damage, clickButton, balastEnemy, JuimpWater, coin;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void firesound()
    {
        fire.Play();
    }


    public void jumpsound()
    {
        jump.Play();
    }


    public void damagesound()
    {
        damage.Play();
    }


    public void clickButtonsound()
    {
        clickButton.Play();
    }


    public void balastEnemysound()
    {
        balastEnemy.Play();
    }


    public void JuimpWatersound()
    {
        JuimpWater.Play();
    }

    public void coinsound()
    {
        coin.Play();
    }


}
