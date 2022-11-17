using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class LevelChanger : MonoBehaviour
{
    public string sLevelToLoad;
    [SerializeField]
    private string _colliderScript;

     [SerializeField]
     private UnityEvent _colissionEntered;


    void OnTriggerEnter(Collider a_Collider)
    {
        ControlledCapsuleCollider controlledCapsuleCollider = a_Collider.GetComponent<ControlledCapsuleCollider>();
        if (controlledCapsuleCollider != null)
        {
            //Prevent death state to be used if the collider is no-clipping
            if (controlledCapsuleCollider.AreCollisionsActive())
            { 
                StartCoroutine(NextLevel());
                _colissionEntered?.Invoke();

            }
        }
    }



     IEnumerator NextLevel()
     {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sLevelToLoad);

     }
    


/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "Player")
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if(useIntegerToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);

        }else
        {
            {
              SceneManager.LoadScene(sLevelToLoad);

            }
        }
    }*/
}
