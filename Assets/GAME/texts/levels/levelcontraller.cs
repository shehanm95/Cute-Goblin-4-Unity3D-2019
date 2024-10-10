using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelcontraller : MonoBehaviour
{

    public int tempnum;
    static public int CompleatedLvevels;
    public int returnumber;
    public Text levelText;



    // Start is called before the first frame update
    void Start()
    {
        load();
        levelText.text = CompleatedLvevels.ToString();
        returnumber = CompleatedLvevels;
    }

    // Update is called once per frame
    void Update()
    {
        selectnumber();
    }

    public void selectnumber()
    {
        if (tempnum > CompleatedLvevels)
        {
            CompleatedLvevels = tempnum;
            returnumber = CompleatedLvevels;
            save();
        }
    }

    public void loadlintro()
    {
        SceneManager.LoadScene("intro");
    }

    public void loadlevels()
    {
        SceneManager.LoadScene("levelmanager");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void reastart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

    }
    public void save() {
        PlayerPrefs.SetInt("CompleatedLvevels", CompleatedLvevels);
            }

    public void load()
    {
        CompleatedLvevels = PlayerPrefs.GetInt("CompleatedLvevels", 0);
    }

   public void subscribe()
    {
        SceneManager.LoadScene("level10");
    }

    public void delete()
    {
        PlayerPrefs.DeleteAll();
        CompleatedLvevels = 0;
        levelText.text = CompleatedLvevels.ToString();
        save();
    }
}
