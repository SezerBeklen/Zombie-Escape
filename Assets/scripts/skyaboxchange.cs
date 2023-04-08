using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyaboxchange : MonoBehaviour
{
    public Material[] skymats;

    public int skymatsCount;

    private void Awake()
    {
        skymatsCount = Random.Range(0, 2);
        //Debug.Log("random deðeri:" + skymatsCount);
        RenderSettings.skybox = skymats[skymatsCount];

    }
    


}
