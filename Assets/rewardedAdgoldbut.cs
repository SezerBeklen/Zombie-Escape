using UnityEngine;
using GoogleMobileAds.Api;

public class rewardedAdgoldbut : MonoBehaviour
{
    public RewardedAd Odullu_ReklamGold;
    public string ÖdüllüRekalmÝD_Gold;
    string ReklamÝd_Gold;
    public golScore gold;
   
    public void Start()
    {
        Reward_Ad_Request_Gold();
    }

    public void Reward_Ad_Request_Gold()
    {
#if UNITY_ANDROID
        ReklamÝd_Gold = ÖdüllüRekalmÝD_Gold;
#elif UNITY_IPHONE
                ReklamÝd="";
#else
                ReklamÝd = "tanýmsýz";
#endif


        Odullu_ReklamGold = new RewardedAd(ReklamÝd_Gold);
        Odullu_ReklamGold.OnUserEarnedReward += OdulKazanýldýGold;

        AdRequest request = new AdRequest.Builder().Build();
        Odullu_ReklamGold.LoadAd(request);
    }

    public void OdulKazanýldýGold(object sender, Reward args)
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
