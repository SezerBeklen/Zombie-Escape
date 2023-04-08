using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Banneradss : MonoBehaviour
{
    public BannerView bannerview;
    public string BannerReklam�D;
    string Reklamid;

    void Start()
    {
        RequestBanner();
    }

    public void RequestBanner()
    {

        #if UNITY_ANDROID
                Reklamid = BannerReklam�D;
        #elif UNITY_IPHONE
                            Reklamid="";
        #else
                            Reklamid = "tan�ms�z";
        #endif


        AdSize adSize = new AdSize(320, 50);
        bannerview = new BannerView(BannerReklam�D, adSize, AdPosition.Bottom);
        // AdRequest adRequest = new AdRequest.Builder().Build();
        bannerview.LoadAd(�stekOlustur());
    }

    AdRequest �stekOlustur()
    {
        return new AdRequest.Builder().Build();//istek d�nd�rme fonksiyonu
    }

   /* public void BannerRemove()
    {
        bannerview.Destroy();
    }*/
}
