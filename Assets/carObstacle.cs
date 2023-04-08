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
    public menu Uý;
    public Camera cam;
    public Swipemanager swipe;

    public AudioSource zombiYemeSes;
    public AudioSource çarpmases;
    public AudioSource ölmeses;

    private Vector3 zombiPos;
    private float zombimesafesi;
    public Ýnterstitialads geçiþReklam;
   

    
    private void Start()
    {
       

        isZeroSpeed = false;
    }
    private void Update()
    {
        if (Uý.isStart)
        {
            if (yanmasayac.yanmasayacý >= 4)
            {
                yanmasayac.yanmasayacý = 0;

            }

        }
        PlayerPrefs.SetInt("yanmasayac", yanmasayac.yanmasayacý);
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
        
         
        if (zombimesafesi <= 2f && Uý.isStart == false)
        {
            zombi.zombianim.Play("yeme");
            zombi.transform.position = new Vector3(player.transform.position.x, 0.2f, player.transform.position.z);
        }
        
        if (isZeroSpeed)
        {
            player.forwardSpeed = 0;
            
        }
    }
    //yanmayý burdan kontrol edeceðiz arabalar için
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            yanmasayac.yanmasayacý += 1;
            çarpmases.Play();
            Debug.Log("yandýn");
            StartCoroutine(waithdeathAnimfinish()); 
            isZeroSpeed = true;
            player.anim.Play("ölme");
            Uý.isStart = false;
            Uý.pausebutton.SetActive(false);
            swipe.enabled = false;
            player.enabled = false;
            if (yanmasayac.yanmasayacý >= 4)
            {
                //gecisreklamgöster
                geçiþReklam.GecisVideo_Reklam_Goster();
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
        ölmeses.Play();

        yield return new WaitForSeconds(2f);
        Uý.deathScreen.SetActive(true);
       
    }

    
}
