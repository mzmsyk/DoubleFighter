using UnityEngine;
using System;
using GoogleMobileAds.Api;
using System.Collections;
using UnityEngine.UI;

public enum AdType
{
    INTERSTITIAL,
    REWARDEDBIGGER,
    REWARDEDEXTRA,
    REWARDED2X,
    REWARDED3X,
    REWARDED5X,
}

public class ads : MonoBehaviour
{
    [HideInInspector]
    public string interstitialId, rewardedAdIdBigger, rewardedAdIdExtra;
    [HideInInspector]
    public string rewardedAdId2x, rewardedAdId3x, rewardedAdId5x;

    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAdBigger;
    private RewardedAd rewardedAdExtra;
 

    private RewardedAd rewardedAd2x;
    private RewardedAd rewardedAd3x;
    private RewardedAd rewardedAd5x;

    public static ads instance;
    private IAPManager iapManager;

    [SerializeField] private GameObject noAdsButton;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) instance = this;
        else Destroy(this.gameObject);

        iapManager = new IAPManager();
        NoAdsButtonAktifligi();
        // ctrl + k + c
        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    interstitialId = "ca-app-pub-1131363594533119/9369877922";

        //    rewardedAdIdChange = "ca-app-pub-1131363594533119/5430632913";

        //    rewardedAdIdLetter = "ca-app-pub-1131363594533119/5430632913";
        //}
        //else
        //{
        //    interstitialId = "ca-app-pub-1131363594533119/3379184647";

        //    rewardedAdIdChange = "ca-app-pub-1131363594533119/2233909348";

        //    rewardedAdIdLetter = "ca-app-pub-1131363594533119/2233909348";
        //}

        #region TestId

        interstitialId = "ca-app-pub-3940256099942544/1033173712";

        rewardedAdIdBigger = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdIdExtra = "ca-app-pub-3940256099942544/5224354917";

        

        rewardedAdId2x = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdId3x = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdId5x = "ca-app-pub-3940256099942544/5224354917";



        #endregion
    }

    void Start()
    {
        MobileAds.Initialize(reklamDurumu => { });

        requestAds(AdType.INTERSTITIAL);
        requestAds(AdType.REWARDEDBIGGER);
        requestAds(AdType.REWARDEDEXTRA);

        

        requestAds(AdType.REWARDED2X);
        requestAds(AdType.REWARDED3X);
        requestAds(AdType.REWARDED5X);


        this.rewardedAdExtra.OnUserEarnedReward += RewardExtra;
        this.rewardedAdBigger.OnUserEarnedReward += RewardBigger;

        
        this.rewardedAd2x.OnUserEarnedReward += Reward2x;
        this.rewardedAd3x.OnUserEarnedReward += Reward3x;
        this.rewardedAd5x.OnUserEarnedReward += Reward5x;

        this.rewardedAdExtra.OnAdClosed += RequestRewardedExtra;
        this.rewardedAdBigger.OnAdClosed += RequestRewardedBigger;
        this.interstitialAd.OnAdClosed += RequestInterstitial;

       
        this.rewardedAd2x.OnAdClosed += RequestRewarded2x;
        this.rewardedAd3x.OnAdClosed += RequestRewarded3x;
        this.rewardedAd5x.OnAdClosed += RequestRewarded5x;

    }

    #region CallBacks

    #region Load & Show

    void RewardExtra(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        //yonetici.ExtraBallReklam();

    }
    void RewardBigger(object sender, Reward args)
    {
        Debug.Log("Change Ödülü");

        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        //yonetici.BiggerBallReklam();


    }
    
    void Reward2x(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        moneybar moneyBar = FindObjectOfType<moneybar>();

        moneyBar.IkiX();

    }
    void Reward3x(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        moneybar moneyBar = FindObjectOfType<moneybar>();

        moneyBar.UcX();

    }
    void Reward5x(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        moneybar moneyBar = FindObjectOfType<moneybar>();

        moneyBar.BesX();


    }
    #endregion

    private void RequestRewardedExtra(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDEXTRA);
    }
    private void RequestRewardedBigger(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDBIGGER);
    }
    private void RequestInterstitial(object sender, EventArgs args)
    {
        requestAds(AdType.INTERSTITIAL);
    }

   
    private void RequestRewarded2x(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDED2X);
    }
    private void RequestRewarded3x(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDED3X);
    }
    private void RequestRewarded5x(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDED5X);
    }

    //Show
    public void ShowRewardedExtra()
    {
        this.rewardedAdExtra.OnUserEarnedReward -= RewardExtra;
        this.rewardedAdExtra.OnUserEarnedReward += RewardExtra;

        this.rewardedAdExtra.OnAdClosed -= RequestRewardedExtra;
        this.rewardedAdExtra.OnAdClosed += RequestRewardedExtra;


        if (rewardedAdExtra.IsLoaded())
            rewardedAdExtra.Show();
    }
    public void ShowRewardedBigger()
    {
        this.rewardedAdBigger.OnUserEarnedReward -= RewardBigger;
        this.rewardedAdBigger.OnUserEarnedReward += RewardBigger;

        this.rewardedAdBigger.OnAdClosed -= RequestRewardedBigger;
        this.rewardedAdBigger.OnAdClosed += RequestRewardedBigger;

        if (rewardedAdBigger.IsLoaded())
            rewardedAdBigger.Show();
    }
    public void ShowInter()
    {
        if (iapManager.ReklamEngellendimi()) return; //REKLAM ENGELLENDÝ

        //this.interstitialAd.OnAdClosed -= RequestInterstitial;
        //this.interstitialAd.OnAdClosed += RequestInterstitial;

        if (interstitialAd.IsLoaded())// REKLAM ÇALIÞTI
            interstitialAd.Show();
    }

    
    public void ShowRewarded2x()
    {
        //this.rewardedAdChange.OnUserEarnedReward -= RewardChange;
        //this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        //this.rewardedAdChange.OnAdClosed -= RequestRewardedChange;
        //this.rewardedAdChange.OnAdClosed += RequestRewardedChange;

        if (rewardedAd2x.IsLoaded())
            rewardedAd2x.Show();
    }
    public void ShowRewarded3x()
    {
        //this.rewardedAdChange.OnUserEarnedReward -= RewardChange;
        //this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        //this.rewardedAdChange.OnAdClosed -= RequestRewardedChange;
        //this.rewardedAdChange.OnAdClosed += RequestRewardedChange;

        if (rewardedAd3x.IsLoaded())
            rewardedAd3x.Show();
    }
    public void ShowRewarded5x()
    {
        //this.rewardedAdChange.OnUserEarnedReward -= RewardChange;
        //this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        //this.rewardedAdChange.OnAdClosed -= RequestRewardedChange;
        //this.rewardedAdChange.OnAdClosed += RequestRewardedChange;

        if (rewardedAd5x.IsLoaded())
            rewardedAd5x.Show();
    }



    #endregion

    #region  Request&Load
    public void requestAds(AdType type)
    {
        switch (type)
        {
            case AdType.INTERSTITIAL:
                {
                    if (interstitialAd != null) interstitialAd.Destroy();
                    interstitialAd = new InterstitialAd(interstitialId);
                    interstitialAd.LoadAd(new AdRequest.Builder().Build());
                    break;

                }

            case AdType.REWARDEDBIGGER:
                {
                    if (rewardedAdBigger != null) rewardedAdBigger.Destroy();
                    rewardedAdBigger = new RewardedAd(rewardedAdIdBigger);
                    rewardedAdBigger.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDEDEXTRA:
                {
                    if (rewardedAdExtra != null) rewardedAdExtra.Destroy();
                    rewardedAdExtra = new RewardedAd(rewardedAdIdExtra);
                    rewardedAdExtra.LoadAd(new AdRequest.Builder().Build());
                    break;
                }

            
            case AdType.REWARDED2X:
                {
                    if (rewardedAd2x != null) rewardedAd2x.Destroy();
                    rewardedAd2x = new RewardedAd(rewardedAdId2x);
                    rewardedAd2x.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDED3X:
                {
                    if (rewardedAd3x != null) rewardedAd3x.Destroy();
                    rewardedAd3x = new RewardedAd(rewardedAdId3x);
                    rewardedAd3x.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDED5X:
                {
                    if (rewardedAd5x != null) rewardedAd5x.Destroy();
                    rewardedAd5x = new RewardedAd(rewardedAdId5x);
                    rewardedAd5x.LoadAd(new AdRequest.Builder().Build());
                    break;
                }


        }
    }
    #endregion
    public void NoAdsButtonAktifligi()
    {
        //SATIN ALMA ÝÞLEMÝ BÝTTÝKTEN SONRA BUTON AKTÝFLÝÐÝ SORGULAMA
        noAdsButton.SetActive(!iapManager.ReklamEngellendimi());
    }
    public void NoAdsButton()
    {
        // REKLAMI ENGELLEMEK ÝÇÝN BUTON ATAMASI
        iapManager.OnPurchaseClicked();
    }
}