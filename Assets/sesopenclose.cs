using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesopenclose : MonoBehaviour
{
    public GameObject sesAcik, sesKapali;
   // public AudioSource But_Ses;
    void Start()
    {
        //PlayerPrefs.SetInt("sesdurum", 1);
    }


    void Update()
    {
        if (PlayerPrefs.GetInt("sesdurum") == 0)
        {
            sesAcik.SetActive(true);
            sesKapali.SetActive(false);
        }
        else
        {
            sesAcik.SetActive(false);
            sesKapali.SetActive(true);
        }

    }
    public void ses_durum(string durum)
    {
        if (durum == "acik")
        {
            sesAcik.SetActive(false);
            sesKapali.SetActive(true);
            //But_Ses.Play();
            PlayerPrefs.SetInt("sesdurum", 1);
        }
        else if (durum == "kapali")
        {
            sesAcik.SetActive(true);
            sesKapali.SetActive(false);
           // But_Ses.Play();
            PlayerPrefs.SetInt("sesdurum", 0);

        }


    }
}
