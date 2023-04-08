using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class caractercont : MonoBehaviour
{
    public int skor;
    public Text Skor;
    public GameObject menuObject;
    public Animator annim;
    public int yanmasayacý;
    public menu _menu;
    public PlayerController player;
    
    private void Start()
    {
       // PlayerPrefs.DeleteAll();
        yanmasayacý = PlayerPrefs.GetInt("yanmasayac");
        annim.Play("idle");
    }
    void Update()
    {
        if (_menu.isStart)
        {
            skor += 1;
           
            
        }

        Skor.text = skor.ToString();
        if (skor > PlayerPrefs.GetInt("_highScore"))
        {
            PlayerPrefs.SetInt("_highScore", skor);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hýzlan")
        {
            player.forwardSpeed += 3f;
            
        }
    }


}
