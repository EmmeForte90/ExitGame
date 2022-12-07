using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{


    //public AudioManager theAM;
    [SerializeField] public GameObject theAM;


    [Header("Music")]
    [SerializeField] public AudioSource[] bgm;

        [Header("Sound")]

        [SerializeField] public AudioSource[] sound;

 
 
 public static AudioManager instance { get; private set; }
// Game Instance Singleton
     public static AudioManager Instance
     {
         get
         { 
             return instance; 
         }
     }

private void Awake() 
{ 
    // if the singleton hasn't been initialized yet
         if (instance != null && instance != this) 
         {
             Destroy(this.gameObject);
         }
 
         instance = this;
         DontDestroyOnLoad( this.gameObject );
}

   


#region Music

    public void PlayMFX(int soundToPlay)
    {
        bgm[soundToPlay].Stop();
        bgm[soundToPlay].pitch = Random.Range(.9f, 1.1f);
        bgm[soundToPlay].Play();
    }

    public void StopMFX(int soundToPlay)
    {
        bgm[soundToPlay].Stop();

    }




#endregion

#region sound

    public void PlaySFX(int soundToPlay)
    {
        //sound[soundToPlay].Stop();
        //sound[soundToPlay].pitch = Random.Range(.9f, 1.1f);
        sound[soundToPlay].Play();
    }

    public void StopSFX(int soundToPlay)
    {
        sound[soundToPlay].Stop();
    }
#endregion

}

