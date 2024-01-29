using GoogleMobileAds.Api;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class adsMasterAbmode : MonoBehaviour
{
    //public TextMeshProUGUI totalCoinst;

    public string appId = "ca-app-pub-3793647457139129~4736502491";
    // public  TextMeshProUGUI totalcointTxt;
   // public SkinsAds monedasSave;


   // string bannerId = "ca-app-pub-3793647457139129/8465045319";
    // string rewardedId = "ca-app-pub-3793647457139129/9946173282";
    string interId = "ca-app-pub-3793647457139129/7526317368";


    //#elif UNITY_IPHONE

    //#else
    // string adUnitId = "unexpected_platform";

    //BannerView bannerView; //desactivado
    InterstitialAd interstitialAd;
   // RewardedAd rewardedAd;  // desactivado

    public int adsInter, adsRewaner = 0;

    private void Start()
    {


        // la nueva forma d edar recompensas  //
        //
        MobileAds.RaiseAdEventsOnUnityMainThread = true;  //inicializar anucios 
        MobileAds.Initialize(InitializationStatus =>
        {

            print("Ads intilialised !!");

        });


        //////this.LoadBannerAd();
        this.LoadInterstitalAd();
       // this.LoadRewarded();
    }



    
    #region Banner
    /*
    public void LoadBannerAd()
    {
        // creater a banner 
        CreateBannerView();
        // listen to banner events 
        ListenToBannerEvents();
        // load the banner 
        if (bannerView == null)
        {
            CreateBannerView();
        }

        var adRequest = new AdRequest(); // lo esta instanicvando 
        adRequest.Keywords.Add("unity-admob-sample");
        // Load the banner with the request.

        print("loading banner ad !!");
        this.bannerView.LoadAd(adRequest); // show the banner on the screen 
    }
    void CreateBannerView()
    {
        if (bannerView != null)
        {
            DestroyBannerAd();
        }
        this.bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);


    }
    void ListenToBannerEvents()
    {
        // Raised when an ad is loaded into the banner view.
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };
        // Raised when the ad is estimated to have earned money.
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Banner view paid {0} {1}." +
                adValue.Value +
                adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };

    }

    public void DestroyBannerAd()
    {
        if (bannerView != null)
        {
            print("destroy banner ad");
            bannerView.Destroy();
            bannerView = null;

        }
    }
    */
    #endregion  // desactivado 
    
    #region interstitial
    public void LoadInterstitalAd()  // cargar interstitcial  
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;

        }
        var adRequest = new AdRequest(); // lo esta instanicvando 
        adRequest.Keywords.Add("unity-admob-sample");

        InterstitialAd.Load(interId, adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                print("intertitial ad  failed to load " + error);
            }
            print("interstital ad failed to load " + ad.GetResponseInfo());


            interstitialAd = ad;
            InterstitialEvent(interstitialAd);

        });

    }
    public void ShowInterstitalAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
            adsInter = 1;
        }
        else
        {
            print("interstitial  ad  no ready ");
            Debug.Log("no se mostro mostro ");
            LoadInterstitalAd();
        }
    }
    public void InterstitialEvent(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        interstitialAd.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Interstitial ad paid {0} {1}." +
                adValue.Value +
                adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        interstitialAd.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        interstitialAd.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    
    #endregion

    #region Rewarded 
   /*
    public void LoadRewarded()  //pideindo un anucio
    {
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }
        var adRequest = new AdRequest(); // lo esta instanicvando 
        adRequest.Keywords.Add("unity-admob-sample");

        RewardedAd.Load(rewardedId, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                print("Rewarded failed to load" + error);
                return;

            }

            print("rewarded ad loaded");
            rewardedAd = ad;
            RewardedAdEvents(rewardedAd);
        });
    }
    public void ShowRewardedAd()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {

                print("give reward to player !!");
                adsRewaner = 1;
                GrantCoins();

            });

        }
        else
        {
            print("reward ad not ready");
        }


    }
    public void RewardedAdEvents(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Rewarded ad paid {0} {1}." +
                adValue.Value +
                adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };

    } */
    #endregion

    #region extra 
    void GrantCoins()
    {
        //int crrcoins = PlayerPrefs.GetInt("totalCoins");
        //crrcoins += Coins;
        //PlayerPrefs.SetInt("totalcoin", crrcoins);           //aqui esta mirando cuantos  monedas tengo y te esta dando mas ?
        //mostar monedas

       // monedasSave.recompensa();


        //  showcoins();
    }
    ///void showcoins()
    //{
    // totalcointTxt.text = PlayerPrefs.GetInt("totalcoins").ToString();  //aqui te esta imprimiendo el las monedas 

    //}

    #endregion
}
