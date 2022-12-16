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



        public void Update()
{
    if(PlayerMovement.instance.death)
{
            stopSound();

}
}

   public void  stopSound()
{
                AudioManager.instance.PlayMFX(1);
bgmN.Stop();
bgmD.Stop();
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
             StartCoroutine(FadeIn(bgmD, 1f));


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
            
            AudioManager.instance.StopMFX(0);
            AudioManager.instance.StopMFX(1);
            AudioManager.instance.StopMFX(2);
            StartCoroutine(FadeIn(bgmN, 1f));
                        StartCoroutine(FadeOut(bgmD, 1f));

            

            }
        }
    }




}
