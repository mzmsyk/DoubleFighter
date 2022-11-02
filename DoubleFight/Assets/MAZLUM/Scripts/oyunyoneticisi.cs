using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class oyunyoneticisi : MonoBehaviour
{
    GameObject manager;
    public int dusmanSaiyisi;
    public GameObject yenidenOynaPanel;
    public GameObject yeniLevelPanel;
    public GameObject mainPanel;
    public static bool kontrol = false;
    int level;
    public TextMeshProUGUI topSaiyisiText;
    public static int dolar=100;
    public static int dolarReklamBigger=100;
    public static int dolarReklamExtra=100;
    public static int levelBiggerReklam=1;
    public static int levelExtraReklam=1;
    public TextMeshProUGUI dolarText;
    public static int dolarKayit;
    public TextMeshProUGUI biggerTextLevel;
    public TextMeshProUGUI extraTextLevel;
    public TextMeshProUGUI fireiggerTextLevel;
    public TextMeshProUGUI biggerTextPara;
    public TextMeshProUGUI extraTextPara;

    void Start()
    {
        biggerTextLevel.text = "Lvl. " + levelBiggerReklam.ToString();
        extraTextLevel.text = "Lvl. " + levelExtraReklam.ToString();
        PlayerPrefs.SetInt("dolarKayit", dolar);
        dolarKayit = PlayerPrefs.GetInt("dolarKayit");
        dolarText.text = dolarKayit.ToString();
        biggerTextPara.text = dolarReklamBigger.ToString();
        extraTextPara.text = dolarReklamExtra.ToString();
        manager = GameObject.FindGameObjectWithTag("Player");
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));
        level = PlayerPrefs.GetInt("kayit");
        topSaiyisiText.text = manager.GetComponent<Manager>().balls.Count.ToString();
        yenidenOynaPanel.SetActive(false);
        yeniLevelPanel.SetActive(false);
        Time.timeScale = 0;
    }

    
    void Update()
    {
        biggerTextLevel.text = "Lvl. " + levelBiggerReklam.ToString();
        extraTextLevel.text = "Lvl. " + levelExtraReklam.ToString();


        dolarText.text = dolarKayit.ToString();
        PlayerPrefs.SetInt("dolarKayit", dolar);
        topSaiyisiText.text = manager.GetComponent<Manager>().balls.Count.ToString();
        if (Manager.sayac<=0||manager.GetComponent<Manager>().balls.Count <= 0|| manager.GetComponent<Manager>().balls.Count <= dusmanSaiyisi && kontrol)
        {
            
            yenidenOynaPanel.SetActive(true);
            ads.instance.ShowInter();
            manager.GetComponent<karakterhareket>().enabled = false;
            //Time.timeScale = 0;
            
        }
        if (manager.GetComponent<Manager>().balls.Count >= dusmanSaiyisi&&kontrol)
        {
            dolar += dolar;
            yeniLevelPanel.SetActive(true);
            //Time.timeScale = 0;
            //SceneManager.LoadScene(level+1);
        }
        
    }
    public void YeniLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name + 1);
    }
    public void YenidenOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void OyunaBasla()
    {
        mainPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void BiggerBall()
    {
        if (dolarReklamBigger<=dolar)
        {
            dolarKayit -= dolarReklamBigger;
            dolarReklamBigger += 25;
            levelBiggerReklam += 1;
            biggerTextPara.text = dolarReklamBigger.ToString();
            
            manager.GetComponent<Manager>().SpawnPlayer(3);
            mainPanel.SetActive(false);
            Time.timeScale = 1;
        }
        
    }
    public void BiggerBallReklam()
    {
        levelBiggerReklam += 1;
        manager.GetComponent<Manager>().SpawnPlayer(3);
        mainPanel.SetActive(false);
        ads.instance.ShowRewardedBigger();

    }
    public void ExtraBall()
    {
        if (dolarReklamExtra<=dolar)
        {
            dolarKayit -= dolarReklamExtra;
            dolarReklamExtra += 25;
            levelExtraReklam += 1;
            int t = Random.Range(0, 10);
            extraTextPara.text = dolarReklamExtra.ToString();
            manager.GetComponent<Manager>().SpawnPlayer(t);
            mainPanel.SetActive(false);
            Time.timeScale = 1;
        }
        
    }
    public void ExtraBallReklam()
    {
        levelExtraReklam += 1;
        int t = Random.Range(0, 10);
        manager.GetComponent<Manager>().SpawnPlayer(t);
        mainPanel.SetActive(false);
        ads.instance.ShowRewardedExtra();
    }
}
