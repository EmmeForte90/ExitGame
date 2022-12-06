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

         [SerializeField]  bool saw = false;

      void OnTriggerEnter(Collider a_Collider)
    {
        ControlledCapsuleCollider controlledCapsuleCollider = a_Collider.GetComponent<ControlledCapsuleCollider>();
        if (controlledCapsuleCollider != null)
        {
            //Prevent death state to be used if the collider is no-clipping
            if (controlledCapsuleCollider.AreCollisionsActive())
            { 
                            AudioManager.instance.StopMFX(0);

            //_colissionEntered?.Invoke();
             if(saw)
            {
            AudioManager.instance.PlaySFX(5);
            } else if(!saw)
            {
            AudioManager.instance.PlaySFX(6);
            }


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
            AudioManager.instance.StopSFX(6);
            AudioManager.instance.StopSFX(5);


            }
        }
    }
}
