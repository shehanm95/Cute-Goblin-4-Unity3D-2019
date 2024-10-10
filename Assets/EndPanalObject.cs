using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanalObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void moreGames()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Sajidesign");
    }

    public void faceBook()
    {
        Application.OpenURL("https://www.facebook.com/Eastern-Pearl-Game-Studio-Sri-Lanka-111454393794662/");
    }
    public void Insta()
    {
        Application.OpenURL("https://www.instagram.com/eastern_pearl_game_studio/");
    }
    public void Twiter()
    {
        Application.OpenURL("https://twitter.com/EasternSri");
    }
    public void youtube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCpH_c0vdcc4hldc22ilMVgg?view_as=subscriber");
    }

    public void Back()
    {
        SceneManager.LoadScene("levelmanager");
    }

}
