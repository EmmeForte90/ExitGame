using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [Header("Tempo di esplosione")]
    [SerializeField] public float lifeTime;
    float startFade = 1f;
    [SerializeField] GameObject FadeAnm;

    void Update()
    {
        Destroy(gameObject, lifeTime);
        StartCoroutine(Fade());
        
    }

    IEnumerator Fade()
    {  
    yield return new WaitForSeconds(startFade);
            FadeAnm.gameObject.SetActive(true);
    }

}
