using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject BackgroundSoundClip;

    [SerializeField] private GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
        ContinueGame();
    }
    void Update()
    {

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
        BackgroundSoundClip.SetActive(false);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
        BackgroundSoundClip.SetActive(true);
    }
}