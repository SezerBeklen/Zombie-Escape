using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class carObstacle : MonoBehaviour
{
    public static bool isZeroSpeed;

    [SerializeField] private PlayerController player;
    public caractercont yanmasayac;
    public zombiController zombi;
    public playerfollow kamera;
    public menu U�;
    public Camera cam;
    public Swipemanager swipe;

    public AudioSource zombiYemeSes;
    public AudioSource �arpmases;
    public AudioSource �lmeses;

    private Vector3 zombiPos;
    private float zombimesafesi;
    public �nterstitialads ge�i�Reklam;
   

    
    private void Start()
    {
       

        isZeroSpeed = false;
    }
    private void Update()
    {
        if (U�.isStart)
        {
            if (yanmasayac.yanmasayac� >= 4)
            {
                yanmasayac.yanmasayac� = 0;

            }

        }
        PlayerPrefs.SetInt("yanmasayac", yanmasayac.yanmasayac�);
        if (player._menu.isDeathbutton && player._menu.isStart)
        {
            Vector3 camrot2 = new Vector3(20, 0, 0);
            cam.transform.DOLocalRotate(camrot2, 1f);
            zombiYemeSes.Stop();
            swipe.enabled = true;
            player.enabled = true;
            zombi.transform.position = new Vector3(0, 0, -30);
        }
        zombiPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
       
        if (player.transform.position.y < 0)
         {
             zombiPos = new Vector3(player.transform.position.x, 0, player.transform.position.z);
         }

        zombimesafesi = Vector3.Distance(zombi.transform.position, player.transform.position);
        
         
        if (zombimesafesi <= 2f && U�.isStart == false)
        {
            zombi.zombianim.Play("yeme");
            zombi.transform.position = new Vector3(player.transform.position.x, 0.2f, player.transform.position.z);
        }
        
        if (isZeroSpeed)
        {
            player.forwardSpeed = 0;
            
        }
    }
    //yanmay� burdan kontrol edece�iz arabalar i�in
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            yanmasayac.yanmasayac� += 1;
            �arpmases.Play();
            Debug.Log("yand�n");
            StartCoroutine(waithdeathAnimfinish()); 
            isZeroSpeed = true;
            player.anim.Play("�lme");
            U�.isStart = false;
            U�.pausebutton.SetActive(false);
            swipe.enabled = false;
            player.enabled = false;
            if (yanmasayac.yanmasayac� >= 4)
            {
                //gecisreklamg�ster
                ge�i�Reklam.GecisVideo_Reklam_Goster();
            }
        }
    }

    IEnumerator waithdeathAnimfinish()
    {
        yield return new WaitForSeconds(0.3f);
        player.gameObject.transform.DOMoveY(-0.3f, 0.5f);
 //-----------------------------------------------------      

        Vector3 camrot = new Vector3(50, 0, 0);
        cam.transform.DOLocalRotate(camrot, 3f);
 //-----------------------------------------------------        

        zombi.transform.DOMove(zombiPos, 2f);
        zombi.zombianim.SetBool("run", true);
 //-----------------------------------------------------
      
        yield return new WaitForSeconds(1.5f);

        zombiYemeSes.Play();
        �lmeses.Play();

        yield return new WaitForSeconds(2f);
        U�.deathScreen.SetActive(true);
       
    }

    
}
