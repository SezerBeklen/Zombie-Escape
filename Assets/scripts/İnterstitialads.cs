using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class İnterstitialads : MonoBehaviour
{
   
    public InterstitialAd gecisVideo;
    
    public string interstitial_ad_IDvideo;
    
    string ReklamİDvideo;


    public void Start()
    {
       
        İnterstitialdVideoRequest();
    }
   
    public void İnterstitialdVideoRequest()
    {
        #if UNITY_ANDROID
                ReklamİDvideo = interstitial_ad_IDvideo;
        #elif UNITY_IPHONE
               ReklamİDvideo="";
        #else
               ReklamİDvideo = "tanımsız";
        #endif
        gecisVideo = new InterstitialAd(ReklamİDvideo);
        AdRequest requestt = new AdRequest.Builder().Build();
        gecisVideo.LoadAd(requestt);
    }
  

    public void GecisVideo_Reklam_Goster()
    {
        if (gecisVideo.IsLoaded())
        {
            gecisVideo.Show();
        }
        else
        {
            İnterstitialdVideoRequest();
        }
    }

}
