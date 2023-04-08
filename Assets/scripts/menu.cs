using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Text _highScoreText;
    public caractercont karakter;
    public PlayerController player;
    public AudioSource ZombiattackSound;
    //public zombiController ZombiContolscript;
    public Camera cam;
    public GameObject Menuobj;
    public GameObject CreditsScreen;
    public GameObject scoreyazı;
    public GameObject playcontinue;
    public GameObject pausebutton;
    public GameObject deathScreen;
    public GameObject settingsScreen;
    public GameObject GoldButon;
    public GameObject[] RespawnPoints;
    public bool isStart;
    public bool isPause;
    public bool isZombiFollow;
    public bool isDeathbutton;
    public bool isRewardedAd;
    public rewardedAD ödüllüreklam;
    public rewardedAdgoldbut AltınButonu;
   // public zombiController zombii;
   // public carObstacle obstacle;
    void Start()
    {
        isRewardedAd = false;
        // PlayerPrefs.DeleteAll();
        _highScoreText.text = PlayerPrefs.GetInt("_highScore").ToString();
        isStart = false;
        isPause = false;
        isZombiFollow = false;
        isDeathbutton = false;
        scoreyazı.SetActive(false);
    }
    private void Update()
    {
        if (isRewardedAd)
        {
            karakter.transform.position = RespawnPoints[Random.Range(0, RespawnPoints.Length)].transform.position;
            deathScreen.SetActive(false);
            karakter.annim.Play("runn");
            isStart = true;
            isDeathbutton = true;
            player.forwardSpeed = PlayerPrefs.GetFloat("hız");
            carObstacle.isZeroSpeed = false;
            pausebutton.SetActive(true);
            player.controller.center = new Vector3(0, 0.51f, 0.06f);
            if (isRewardedAd)
            {
                isRewardedAd = false;
            }
        }
    }

    public void StartGame()
     {
        pausebutton.SetActive(true);
      //  men.gameObject.SetActive(true);
        Time.timeScale = 1;
        Menuobj.SetActive(false);
        isStart = true;
        cam.transform.DOMoveX(0, 3f);
        Vector3 camrot = new Vector3(20,0 , 0);
        cam.transform.DOLocalRotate(camrot, 2f);
        
        StartCoroutine(waithanim());
       
       
    }

    public void CreditsButton()
    {
        Menuobj.SetActive(false);
        CreditsScreen.SetActive(true);
        
    }
    public void CreditsBackButton()
    {
        Menuobj.SetActive(true);
        CreditsScreen.SetActive(false);
        if (settingsScreen.activeInHierarchy)
        {
            settingsScreen.SetActive(false);
        }
    }

    public void Pausebutton()
    {
        
        Time.timeScale = 0;
        playcontinue.SetActive(true);
        pausebutton.SetActive(false);
        isPause = true;
        isStart = false;
      //  men.skorartıshızı = 50;
       
    }
    public void PlayContinuebutton()
    {
        
        Time.timeScale = 1;
        playcontinue.SetActive(false);
        pausebutton.SetActive(true);
        isStart = true;
        isPause = false;
       //  men.skorartıshızı = 1;
       
    }

    public void menuIcon()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void DeathButton()
    {
        ödüllüreklam.Odullu_Reklam_Show();
       
    }
    
    public void watchADButton()
    {
        AltınButonu.Odullu_Reklam_Show_Gold();
    }
    public void yıldızlamaButton()
    {
        Application.OpenURL("market://details?id=com.MegAzeGames.EndlessRunning2");
    }
    public void Ayarlar()
    {
        Menuobj.SetActive(false);
        settingsScreen.SetActive(true);

    }


    IEnumerator waithanim()
    {
        yield return new WaitForSeconds(0.8f);
        ZombiattackSound.Play();
        karakter.annim.Play("korku");
        yield return new WaitForSeconds(1f);
        karakter.GetComponent<PlayerController>().enabled = true;
        cam.GetComponent<playerfollow>().enabled = true;
        isDeathbutton = false;
        scoreyazı.SetActive(true);
        GoldButon.SetActive(true);
        //ZombiContolscript.zombianim.SetBool("atlama", false);
        Quaternion target = Quaternion.Euler(0, 0, 0);
        karakter.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 0.125f);
        karakter.annim.SetTrigger("run");
        isZombiFollow = true;
    }
}
