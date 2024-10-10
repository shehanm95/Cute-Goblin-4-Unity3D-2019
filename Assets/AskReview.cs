using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AskReview : MonoBehaviour
{
    public GameObject ReviewPanalObject;
    public GameObject winpanal;
    public GameObject winPanalObject;
    InterstitialAdsScript ad;

    // Start is called before the first frame update
    void Start()
    {
        ad = FindObjectOfType<InterstitialAdsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenReviewPanal()
    {
        ReviewPanalObject.SetActive(true);
        winPanalObject.SetActive(false);
        winpanal.SetActive(false);
    }

    public void DoThereview()
    {
         Application.OpenURL("market://details?id=com.mshehan.cutegoblin5");
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.mshehan.cutegoblin5");
    }

    public void NextLevel()
    {
        ad.vedioAD();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
