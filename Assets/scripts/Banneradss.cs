using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Banneradss : MonoBehaviour
{
    public BannerView bannerview;
    public string BannerReklamÝD;
    string Reklamid;

    void Start()
    {
        RequestBanner();
    }

    public void RequestBanner()
    {

        #if UNITY_ANDROID
                Reklamid = BannerReklamÝD;
        #elif UNITY_IPHONE
                            Reklamid="";
        #else
                            Reklamid = "tanýmsýz";
        #endif


        AdSize adSize = new AdSize(320, 50);
        bannerview = new BannerView(BannerReklamÝD, adSize, AdPosition.Bottom);
        // AdRequest adRequest = new AdRequest.Builder().Build();
        bannerview.LoadAd(ÝstekOlustur());
    }

    AdRequest ÝstekOlustur()
    {
        return new AdRequest.Builder().Build();//istek döndürme fonksiyonu
    }

   /* public void BannerRemove()
    {
        bannerview.Destroy();
    }*/
}
