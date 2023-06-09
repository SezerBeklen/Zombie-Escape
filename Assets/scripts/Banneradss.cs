using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Banneradss : MonoBehaviour
{
    public BannerView bannerview;
    public string BannerReklamİD;
    string Reklamid;

    void Start()
    {
        RequestBanner();
    }

    public void RequestBanner()
    {

        #if UNITY_ANDROID
                Reklamid = BannerReklamİD;
        #elif UNITY_IPHONE
                            Reklamid="";
        #else
                            Reklamid = "tanımsız";
        #endif


        AdSize adSize = new AdSize(320, 50);
        bannerview = new BannerView(BannerReklamİD, adSize, AdPosition.Bottom);
        // AdRequest adRequest = new AdRequest.Builder().Build();
        bannerview.LoadAd(İstekOlustur());
    }

    AdRequest İstekOlustur()
    {
        return new AdRequest.Builder().Build();//istek döndürme fonksiyonu
    }

   /* public void BannerRemove()
    {
        bannerview.Destroy();
    }*/
}
