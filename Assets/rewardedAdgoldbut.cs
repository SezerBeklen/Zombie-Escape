using UnityEngine;
using GoogleMobileAds.Api;

public class rewardedAdgoldbut : MonoBehaviour
{
    public RewardedAd Odullu_ReklamGold;
    public string �d�ll�Rekalm�D_Gold;
    string Reklam�d_Gold;
    public golScore gold;
   
    public void Start()
    {
        Reward_Ad_Request_Gold();
    }

    public void Reward_Ad_Request_Gold()
    {
#if UNITY_ANDROID
        Reklam�d_Gold = �d�ll�Rekalm�D_Gold;
#elif UNITY_IPHONE
                Reklam�d="";
#else
                Reklam�d = "tan�ms�z";
#endif


        Odullu_ReklamGold = new RewardedAd(Reklam�d_Gold);
        Odullu_ReklamGold.OnUserEarnedReward += OdulKazan�ld�Gold;

        AdRequest request = new AdRequest.Builder().Build();
        Odullu_ReklamGold.LoadAd(request);
    }

    public void OdulKazan�ld�Gold(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        gold.goldCountMenu += 1000;
    }

    public void Odullu_Reklam_Show_Gold()
    {
        if (Odullu_ReklamGold.IsLoaded())
        {
            Odullu_ReklamGold.Show();
        }
        else
        {
            Reward_Ad_Request_Gold();
        }

    }
}
