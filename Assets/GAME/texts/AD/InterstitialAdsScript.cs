using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdsScript : MonoBehaviour
{

    string gameId = "3462142";
    bool testMode = false;

    void Start()
    {
        // Initialize the Ads service:
        Advertisement.Initialize(gameId, testMode);
        // Show an ad:

    }

    public void vedioAD()
    {
        Advertisement.Show();
    }
}
