using UnityEngine;
using GoogleMobileAds.Api;


public class rewardedAD : MonoBehaviour
{
    public RewardedAd Odullu_Reklam;
    public string ÖdüllüRekalmİD;
    string Reklamİd;
    public menu menüdeathbuton;
    public void Start()
    {
        Reward_Ad_Request();
    }

    public void Reward_Ad_Request()
    {
#if UNITY_ANDROID
        Reklamİd = ÖdüllüRekalmİD;
#elif UNITY_IPHONE
                Reklamİd="";
#else
                Reklamİd = "tanımsız";
#endif


        Odullu_Reklam = new RewardedAd(Reklamİd);
        Odullu_Reklam.OnUserEarnedReward += OdulKazanıldı;

        AdRequest request = new AdRequest.Builder().Build();
        Odullu_Reklam.LoadAd(request);
    }

    public void OdulKazanıldı(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        menüdeathbuton.isRewardedAd = true;
    }

    public void Odullu_Reklam_Show()
    {
        if (Odullu_Reklam.IsLoaded())
        {
            Odullu_Reklam.Show();
        }
        else
        {
            Reward_Ad_Request();
        }

    }

}

