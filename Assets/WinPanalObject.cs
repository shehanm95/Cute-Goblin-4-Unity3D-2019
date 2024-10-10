using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanalObject : MonoBehaviour
{
    [Header("COIN")]
    public float AllCoins;
    public float CollectedCoins;
    public Text CoinRateText;
    public float CoinPeresentage;


    [Header("KILLING")]
    public float AllEnemies;
    public float KilledCount;
    public Text KillingRateText;
    public float KillinPresentage;

    [Header("Skill level")]

    public Text SkillLevel;

    [Header("Skill level")]

    public GameObject[] Diactivation;



    private playerContraller player;
    private InterstitialAdsScript ad;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerContraller>();
        ad = FindObjectOfType<InterstitialAdsScript>();
        CollectedCoins = player.CoinAmount;
        KilledCount = player.KillAmount;
        diactivate();
    }

    // Update is called once per frame
    void Update()
    {
        
        KillPresentageMaker();
        CoinPresentageMaker();
        PrintSkillLevel();
    }

    public void KillPresentageMaker()
    {
        float X = KilledCount / AllEnemies * 100;
        KillinPresentage = X;
        KillingRateText.text = KillinPresentage.ToString("0") + "%";
    }

    public void CoinPresentageMaker()
    {
        float X = CollectedCoins / AllCoins * 100;
        CoinPeresentage = X;
        CoinRateText.text = CoinPeresentage.ToString("0") + "%";
    }
    public void NextLevel()
    {
        ad.vedioAD();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restartCurrentScene()
    {
        ad.vedioAD();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void PrintSkillLevel()
    {
        float fullSkill = (CoinPeresentage + KillinPresentage) / 2;
        
        if (fullSkill > 80)
        {
            SkillLevel.color = new Color32(255, 0, 0, 255);
            SkillLevel.text = "EXELENT SKILL";
        }

        if (fullSkill < 80 && fullSkill > 60)
        {
            SkillLevel.color = new Color32(215, 66, 66, 255);
            SkillLevel.text = "GOOD SKILL";
        }

        if (fullSkill < 60 && fullSkill > 40)
        {
            SkillLevel.color = new Color32(133, 133, 133, 255);
            SkillLevel.text = "NORMAL SKILL";
        }

        if (fullSkill < 40)
        {
            SkillLevel.color = new Color32(133, 133, 133, 255);
            SkillLevel.text = "VERY POOR SKILL";
        }
    }
    public void diactivate() {
        for (int i = 0; i < Diactivation.Length; i++)
        {
            Diactivation[i].SetActive(false);
        }
}
}
