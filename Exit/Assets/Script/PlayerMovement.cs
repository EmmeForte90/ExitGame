using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public GameObject _player;
    [SerializeField] Transform player;
    public Rigidbody myRigidbody;
    [SerializeField] public LayerMask layerMask;
bool platform = false;
    public static PlayerMovement instance;
     void Awake()
    {
        instance = this;

    }
        
           
#region Collisioni

void OnCollisionEnter(Collision other)
    {
        //Se il player tocca una piattaforma
        if (other.gameObject.tag == "Platforms")
        {
            platform = true;
            //Debug.Log("Hai tocca la paittaforma" + isGround);
            if (platform){_player.transform.parent = other.transform;}
		}

        
	}

    
private void OnCollisionExit(Collision other){
	if (other.gameObject.tag == "Platforms")
        {
            //Debug.Log("Sei uscito dalla piattaforma");
            platform = false;
			_player.transform.parent = null;
		}
	}
#endregion 


}
