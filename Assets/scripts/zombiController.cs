using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class zombiController : MonoBehaviour
{
    public Animator zombianim;
    public Transform playerým;
    public menu _menum;

    private void Start()
    {
        if (_menum.isZombiFollow)
        {
            // transform.position = new Vector3(0, transform.position.y,transform.position.z);
            //zombianim.SetBool("run", true);
            transform.DOMoveX(0, 0.5f);

        }
    }
    void Update()
    {


       

        if (_menum.isStart && !_menum.isZombiFollow)
        {

            zombianim.SetBool("atlama", true);
             transform.DOMoveX(0.60f, 1f);
           
        }


    }

 
}
