using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Musicdanger : MonoBehaviour
{
    /*[SerializeField]
    private string _colliderScript;

     [SerializeField]
     private UnityEvent _colissionEntered;

      [SerializeField]
      private UnityEvent _colissionExit;*/
    [SerializeField] public AudioSource bgmN;
        [SerializeField] public AudioSource bgmD;

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
 
        bgm.volume = 0.5f;
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
            AudioManager.instance.StopMFX(0);
            AudioManager.instance.StopMFX(1);
            AudioManager.instance.StopMFX(2);
            StartCoroutine(FadeOut(bgmN, 1f));
            //AudioSourceCrossfade.instance.Fade();
             StartCoroutine(FadeIn(bgmD, 1f));

            //AudioManager.instance.PlayMFX(2);
            DogMonster.instance.sfxM = true;


            }
        }
    }

      void OnTriggerExit(Collider a_Collider)
    {
        ControlledCapsuleCollider controlledCapsuleCollider = a_Collider.GetComponent<ControlledCapsuleCollider>();
        if (controlledCapsuleCollider != null)
        {
            //Prevent death state to be used if the collider is no-clipping
            if (controlledCapsuleCollider.AreCollisionsActive())
            { 
            //_colissionExit?.Invoke();
            
            StartCoroutine(FadeOut(bgmD, 1f));
            AudioManager.instance.StopMFX(0);
            AudioManager.instance.StopMFX(1);
            AudioManager.instance.StopMFX(2);
            StartCoroutine(FadeIn(bgmN, 1f));
            //AudioManager.instance.PlayMFX(1);
            //AudioManager.instance.PlayMFX(1);
            //AudioManager.instance.StopSFX(8);
            //AudioManager.instance.StopSFX(7);
            DogMonster.instance.sfxM = false;


            }
        }
    }




}
