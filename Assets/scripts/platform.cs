using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class platform : MonoBehaviour
{
    
    
  
    private void OnTriggerEnter(Collider other)
    {
        transform.position += new Vector3(0, 0, transform.GetComponent<Renderer>().bounds.size.z*4);
    }

}
