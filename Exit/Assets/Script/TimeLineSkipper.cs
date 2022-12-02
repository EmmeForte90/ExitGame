using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class TimeLineSkipper : MonoBehaviour
{
    private PlayableDirector timeline = null;
    [SerializeField] 
    private float skipToSecond;
    public GameObject pressSpace;
    private bool pressSecond = true;

    private void Awake()
    {
        timeline = GetComponent<PlayableDirector>();
    }
void Update()
{
 if(Input.GetKeyDown("space") && pressSecond)
        {
            pressSpace.gameObject.SetActive(true);
            pressSecond = false;
            
        } 
        else if(Input.GetKeyDown("space") && timeline.time != 0 && !pressSecond)
        {
            pressSpace.gameObject.SetActive(false);
            timeline.time = skipToSecond;
            StartCoroutine(skipOneFrame());
            pressSecond = true;
             
        }
}
    

    IEnumerator skipOneFrame()
    {
        yield return null;
        timeline.time = timeline.time;
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
}
