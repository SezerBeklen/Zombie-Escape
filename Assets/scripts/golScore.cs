using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class golScore : MonoBehaviour
{
    public Text goldText;
    public int goldCount;
    public int goldCountMenu;
    public Text golTextMenu;
    public ParticleSystem goldparticle;
    public AudioSource coin;
    void Start()
    {
        goldCountMenu = PlayerPrefs.GetInt("goldm");
       
        goldCountMenu += PlayerPrefs.GetInt("gold");

       
    }

  
    void Update()
    {
        goldText.text = goldCount.ToString();

        golTextMenu.text = goldCountMenu.ToString();
        PlayerPrefs.SetInt("goldm", goldCountMenu);
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("gold"))
        {
            goldCount += 1;
            PlayerPrefs.SetInt("gold", goldCount);
            other.gameObject.SetActive(false);
            StartCoroutine(goldActive(other));
            goldparticle.Play();
            coin.Play();
        }
    }

    IEnumerator goldActive(Collider other)
    {
        yield return new WaitForSeconds(5f);
        other.gameObject.SetActive(true);
    }
  
   
}
