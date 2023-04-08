using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class volumeControl : MonoBehaviour
{

    public skyaboxchange sky;
    [SerializeField] private VolumeProfile gameVolume;
    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        ColorAdjustments cA;
        if(gameVolume.TryGet<ColorAdjustments>(out cA))
        {
            colorAdjustments = cA;
            if(sky.skymatsCount == 0)
            {
                colorAdjustments.postExposure.value = 0.5f;
            }
            else if (sky.skymatsCount == 1)
            {
                colorAdjustments.postExposure.value = -0.5f;
            }
        }
           
       
        
    }
}
//sky.skymatsCount == 0  colorAdjustments.postExposure.value = 0.5f;  colorAdjustments = cA;