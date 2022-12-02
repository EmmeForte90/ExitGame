using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //public AudioManager theAM;
    [SerializeField] public GameObject theAM;


    [Header("Music")]
    [SerializeField] public AudioSource[] bgm;
    //[SerializeField] public AudioSource[] soundEffects;
 
 
 public static AudioManager instance { get; private set; }


private void Awake() 
{ 
    // If there is an instance, and it's not me, delete myself.
    
    if (instance != null && instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        instance = this; 
    } 
}

   




#region Sound 
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

/*
#region Music

    
     public void playMusic()
    {
        bgm.Play();
    }
    
    public void DieMusic()
    {
        bgm.Stop();
        dieMusic.Play();
    }
    

    #endregion*/
}
