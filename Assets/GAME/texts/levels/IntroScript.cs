using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class IntroScript : MonoBehaviour
{
    public AudioSource clickButton;
    public GameObject IntroPnal;
    public GameObject ExitPnal;

    public void Start()
    {
        IntroPnal.SetActive(true);
        ExitPnal.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void ActiveExitGamePanal()
    {
        ExitPnal.SetActive(true);
        IntroPnal.SetActive(false);
    }

    public void OffExitGamePanal()
    {
        ExitPnal.SetActive(false);
        IntroPnal.SetActive(true);
    }

    public void exitgame()
    {
        Application.Quit();
    }

    public void ToLevelScene()
    {
        SceneManager.LoadScene("levelManager");
    }
    public void clickButtonsound()
    {
        clickButton.Play();
    }

}
