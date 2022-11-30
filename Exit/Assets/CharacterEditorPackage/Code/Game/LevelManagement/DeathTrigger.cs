using UnityEngine;
using System.Collections;
//--------------------------------------------------------------------
//When the player enters, respawn them
//--------------------------------------------------------------------
public class DeathTrigger : MonoBehaviour {

    [SerializeField] GameObject DieAnm;
    //[SerializeField] GameObject PlayerC;

    [SerializeField] public float startDie;



    void OnTriggerEnter(Collider a_Collider)
    {
        ControlledCapsuleCollider controlledCapsuleCollider = a_Collider.GetComponent<ControlledCapsuleCollider>();
        if (controlledCapsuleCollider != null)
        {
            //Prevent death state to be used if the collider is no-clipping
            if (controlledCapsuleCollider.AreCollisionsActive())
            { 

                Instantiate(DieAnm, PlayerMovement.instance.transform.position, transform.rotation);
                PlayerMovement.instance._player.gameObject.SetActive(false);
                StartCoroutine(Die());


            
            }
        }
    }

IEnumerator Die()
    {  
    yield return new WaitForSeconds(startDie);
    Debug.Log("Death triggered by: " + transform.name);
                if (InSceneLevelSwitcher.Get())
                {
                    InSceneLevelSwitcher.Get().Respawn();
                PlayerMovement.instance._player.gameObject.SetActive(true);

                }
    }

}
