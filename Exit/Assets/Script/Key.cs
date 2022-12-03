using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Key : MonoBehaviour
{

        [SerializeField] public GameObject boof;
        [SerializeField] public GameObject key;


    [SerializeField]
    private string _colliderScript;

     [SerializeField]
     private UnityEvent _colissionEntered;

      [SerializeField]
      private UnityEvent _colissionExit;



     
      void OnTriggerEnter(Collider a_Collider)
    {
        ControlledCapsuleCollider controlledCapsuleCollider = a_Collider.GetComponent<ControlledCapsuleCollider>();
        if (controlledCapsuleCollider != null)
        {
            //Prevent death state to be used if the collider is no-clipping
            if (controlledCapsuleCollider.AreCollisionsActive())
            { 
            _colissionEntered?.Invoke();
            Instantiate(boof, boof.transform.position, boof.transform.rotation);
            key.gameObject.SetActive(false);


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
            _colissionExit?.Invoke();
            Instantiate(boof, boof.transform.position, boof.transform.rotation);
            key.gameObject.SetActive(false);



            }
        }
    }

     



}
