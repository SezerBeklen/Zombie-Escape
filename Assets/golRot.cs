using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golRot : MonoBehaviour
{
    private int speed = 20;
    
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed*5);
    }
}
