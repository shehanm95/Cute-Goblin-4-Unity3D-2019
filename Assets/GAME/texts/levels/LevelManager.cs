using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public AudioSource clickButton;
    public GameObject[] levels;
    public int CompleatedLevelNumber = 0;
    public Text CompleatedLevelText;
    private levelcontraller name;

    // Start is called before the first frame update
    void Start()
    {
        name = FindObjectOfType<levelcontraller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CompleatedLevelNumber = levelcontraller.CompleatedLvevels;
        CompleatedLevelText.text = CompleatedLevelNumber.ToString();
        ActiveLevels();

        
    }
    public void ActiveLevels()
    {
        if (CompleatedLevelNumber == 0)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].SetActive(false);
            }
        }

        if (CompleatedLevelNumber == 1)
        {
            {
                for (int i = 1; i < levels.Length; i++)
                {
                    levels[i].SetActive(false);
                }
            }
        }

        if (CompleatedLevelNumber == 2)
        {
            for (int i = 2; i < levels.Length; i++)
            {
                levels[i].SetActive(false);
            }
        }

        if (CompleatedLevelNumber == 3)
        {
            for (int i =3; i < levels.Length; i++)
            {
                levels[i].SetActive(false);
            }
        }

        if (CompleatedLevelNumber == 4)
        {
            for (int i = 4; i < levels.Length; i++)
            {
                levels[i].SetActive(false);
            }
        }

        if (CompleatedLevelNumber == 5)
        {
            for (int i =5; i < levels.Length; i++)
            {
                levels[i].SetActive(false);
            }
        }

        if (CompleatedLevelNumber == 6)
        {
            for (int i =6; i < levels.Length; i++)
            {
                levels[i].SetActive(false);
            }
        }

        if (CompleatedLevelNumber == 7)
        {
            levels[7].SetActive(false);
        }
    }

    public void loadlevel1()
    {
        SceneManager.LoadScene("level1");
    }

    public void loadlevel2()
    {
        SceneManager.LoadScene("level2");
    }

    public void loadlevel3()
    {
        SceneManager.LoadScene("level3");
    }

    public void loadlevel4()
    {
        SceneManager.LoadScene("level4");
    }

    public void loadlevel5()
    {
        SceneManager.LoadScene("level5");
    }

    public void loadlevel6()
    {
        SceneManager.LoadScene("level6");
    }

    public void loadlevel7()
    {
        SceneManager.LoadScene("level7");
    }

    public void loadlevel8()
    {
        SceneManager.LoadScene("level8");
    }

    public void loadlevel9()
    {
        SceneManager.LoadScene("level9");
    }

    public void levelmanager()
    {
        SceneManager.LoadScene("levelmanager");
    }

    public void menu()
    {
        SceneManager.LoadScene("intro");
    }

    public void clickButtonsound()
    {
        clickButton.Play();
    }
}
