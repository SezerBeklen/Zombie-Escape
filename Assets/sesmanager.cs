using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesmanager : MonoBehaviour
{
    public AudioSource ses_kontrol;
    
     
    void Update()
    {
        if (PlayerPrefs.GetInt("sesdurum") == 0)
        {
            ses_kontrol.mute = false;
        }
        else
        {
            ses_kontrol.mute = true;
        }

    }
}
