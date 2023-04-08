using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class envirmanager : MonoBehaviour
{
    public GameObject[] environment;
    public float envdistance;
    public GameObject player;
    
    void Update()
    {
        
        foreach (GameObject env in environment)
        {
            envdistance = Vector3.Distance(player.transform.position,env.transform.position);
            if (envdistance > 50)
            {
                env.gameObject.SetActive(false);
            }
            else
            {
                env.gameObject.SetActive(true);
            }
            
        }
    }
}
