using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearMessage : MonoBehaviour
{
   [SerializeField] public GameObject boof;
    [SerializeField] public GameObject key;
    [Header("Sound")]
    [SerializeField] public AudioSource AudioK;


    


     
      void OnTriggerEnter(Collider a_Collider)
    {
        ControlledCapsuleCollider controlledCapsuleCollider = a_Collider.GetComponent<ControlledCapsuleCollider>();
        if (controlledCapsuleCollider != null)
        {
            //Prevent death state to be used if the collider is no-clipping
            if (controlledCapsuleCollider.AreCollisionsActive())
            { 
            Instantiate(boof, key.transform.position, key.transform.rotation);
            key.gameObject.SetActive(true);
            AudioK.Play();


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
            Instantiate(boof, key.transform.position, key.transform.rotation);
            key.gameObject.SetActive(false);



            }
        }
    }

}
