using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [Header("Tempo di esplosione")]
    [SerializeField] public float lifeTime;
    float startFade = 1f;
    [SerializeField] GameObject FadeAnm;
    [SerializeField] bool needFade = true;

    void Update()
    {
        Destroy(gameObject, lifeTime);
        if(needFade)
        {
        StartCoroutine(Fade());
        }
        
    }

    IEnumerator Fade()
    {  
    yield return new WaitForSeconds(startFade);
            FadeAnm.gameObject.SetActive(true);
    }

}
