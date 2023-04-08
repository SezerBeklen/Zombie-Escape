using UnityEngine;
using GoogleMobileAds.Api;


public class rewardedAD : MonoBehaviour
{
    public RewardedAd Odullu_Reklam;
    public string �d�ll�Rekalm�D;
    string Reklam�d;
    public menu men�deathbuton;
    public void Start()
    {
        Reward_Ad_Request();
    }

    public void Reward_Ad_Request()
    {
#if UNITY_ANDROID
        Reklam�d = �d�ll�Rekalm�D;
#elif UNITY_IPHONE
                Reklam�d="";
#else
                Reklam�d = "tan�ms�z";
#endif


        Odullu_Reklam = new RewardedAd(Reklam�d);
        Odullu_Reklam.OnUserEarnedReward += OdulKazan�ld�;

        AdRequest request = new AdRequest.Builder().Build();
        Odullu_Reklam.LoadAd(request);
    }

    public void OdulKazan�ld�(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        men�deathbuton.isRewardedAd = true;
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

