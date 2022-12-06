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
            AudioManager.instance.PlayMFX(2);
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
            AudioManager.instance.StopMFX(0);
            AudioManager.instance.StopMFX(2);
            AudioManager.instance.PlayMFX(1);
            AudioManager.instance.StopSFX(8);
            AudioManager.instance.StopSFX(7);
            DogMonster.instance.sfxM = false;


            }
        }
    }

}
