using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class screenLoading : MonoBehaviour
{
    public Slider progressBar;

    public void Start()
    {
        StartCoroutine(startLoading(1));
    }

    IEnumerator startLoading(int level)
    {
        yield return new WaitForSeconds(3f);
        AsyncOperation async = SceneManager.LoadSceneAsync(level);
        while (!async.isDone)
        {
           
            progressBar.value = async.progress;
            yield return null;
        }
        
    }
}
