using UnityEngine;
using System.Collections;
//--------------------------------------------------------------------
//When the player enters, respawn them
//--------------------------------------------------------------------
public class DeathTrigger : MonoBehaviour {

    

    //[SerializeField] GameObject PlayerC;

    float startDie = 2f;



    void OnTriggerEnter(Collider a_Collider)
    {
        ControlledCapsuleCollider controlledCapsuleCollider = a_Collider.GetComponent<ControlledCapsuleCollider>();
        if (controlledCapsuleCollider != null)
        {
            //Prevent death state to be used if the collider is no-clipping
            if (controlledCapsuleCollider.AreCollisionsActive())
            { 

                Instantiate(PlayerMovement.instance.DieAnm, PlayerMovement.instance.transform.position, transform.rotation);
                PlayerMovement.instance._player.gameObject.SetActive(false);
                PlayerMovement.instance.NullParent();
                PlayerMovement.instance.death = true;
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
                    PlayerMovement.instance.death = false;
                Instantiate(PlayerMovement.instance._fade, PlayerMovement.instance.transform.position, transform.rotation);
                PlayerMovement.instance._player.gameObject.SetActive(true);
                    PlayerMovement.instance.NullParent();


                }
    }

}
