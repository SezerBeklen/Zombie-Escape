using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
 


public class playerfollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    void LateUpdate()
     {
         transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z-3f)+offset;
        transform.DOMoveY(2.5f, 3f);
     }



}
