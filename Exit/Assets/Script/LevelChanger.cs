using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
   // public int iLevelToLoad;
    public string sLevelToLoad;
    //public bool useIntegerToLoadLevel = false;

    void OnTriggerEnter(Collider a_Collider)
    {
        ControlledCapsuleCollider controlledCapsuleCollider = a_Collider.GetComponent<ControlledCapsuleCollider>();
        if (controlledCapsuleCollider != null)
        {
            //Prevent death state to be used if the collider is no-clipping
            if (controlledCapsuleCollider.AreCollisionsActive())
            { 
                              SceneManager.LoadScene(sLevelToLoad);

            }
        }
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
