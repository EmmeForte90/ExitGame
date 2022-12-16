using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEffectArea : MonoBehaviour
{
    /*[SerializeField]
    private string _colliderScript;

     [SerializeField]
     private UnityEvent _colissionEntered;

      [SerializeField]
      private UnityEvent _colissionExit;*/
          public static MusicEffectArea instance;


         [SerializeField]  bool saw = false;
         [SerializeField] public AudioSource bgmS;
        [SerializeField] public AudioSource bgmP;

public void Update()
{
    if(PlayerMovement.instance.death)
{
            stopSound();

}
}


public  IEnumerator FadeOut(AudioSource bgm, float FadeTime)
    {
        float startVolume = bgm.volume;
 
        while (bgm.volume > 0)
        {
            bgm.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        bgm.Stop();
        bgm.volume = startVolume;
    }
 
    public  IEnumerator FadeIn(AudioSource bgm, float FadeTime)
    {
        float startVolume = 0.2f;
 
        bgm.volume = 0;
        bgm.Play();
 
        while (bgm.volume < 1.0f)
        {
            bgm.volume += startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        bgm.volume = 0.3f;
    }

      void OnTriggerEnter(Collider a_Collider)
    {
        ControlledCapsuleCollider controlledCapsuleCollider = a_Collider.GetComponent<ControlledCapsuleCollider>();
        if (controlledCapsuleCollider != null)
        {
            //Prevent death state to be used if the collider is no-clipping
            if (controlledCapsuleCollider.AreCollisionsActive())
            { 

            //_colissionEntered?.Invoke();
             if(saw)
            {
             StartCoroutine(FadeIn(bgmS, 1f));
            } else if(!saw)
            {
             StartCoroutine(FadeIn(bgmP, 1f));
            }


            }
        }
    }
    public void  stopSound()
{
 bgmS.Stop();
bgmP.Stop();
}

      void OnTriggerExit(Collider a_Collider)
    {
        ControlledCapsuleCollider controlledCapsuleCollider = a_Collider.GetComponent<ControlledCapsuleCollider>();
        if (controlledCapsuleCollider != null)
        {
            //Prevent death state to be used if the collider is no-clipping
            if (controlledCapsuleCollider.AreCollisionsActive())
            { 
                         StartCoroutine(FadeOut(bgmS, 1f));
                        StartCoroutine(FadeOut(bgmP, 1f));




            }
        }
    }
}
