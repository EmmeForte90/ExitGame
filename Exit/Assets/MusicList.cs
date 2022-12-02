using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicList : MonoBehaviour
{
    public void musicPlayTrackMainMenu()
    {
            AudioManager.instance.PlayMFX(0);

    }

    public void musicPlayTrackStage1()
    {
            AudioManager.instance.PlayMFX(1);

    }

    public void musicPlayDanger()
    {
            AudioManager.instance.PlayMFX(2);

    }

    public void StopMusic()
    {
            AudioManager.instance.StopMFX(0);
            AudioManager.instance.StopMFX(1);
            AudioManager.instance.StopMFX(2);



    }
}
