using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public GameObject _player;
    [SerializeField] public GameObject _fade;
    [SerializeField] public GameObject DieAnm;
    [SerializeField] public GameObject pause;
    [SerializeField] Transform player;
    public Rigidbody myRigidbody;
    [SerializeField] public LayerMask layerMask;
    public bool death = false;
    public bool buttonPress = false;

    bool platform = false;
    public static PlayerMovement instance;


     void Awake()
    {
        instance = this;

    }
        
          

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Escape) && !buttonPress)
        {
            Debug.Log("Escape key was pressed");
            Time.timeScale = 0;
            buttonPress = true;
            pause.gameObject.SetActive(true);

        } else if (Input.GetKeyDown(KeyCode.Escape) && buttonPress)
        {
            Debug.Log("Escape key was pressed");
            Time.timeScale = 1;
            buttonPress = false;
            pause.gameObject.SetActive(false);

        }
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

        //Se il player tocca una piattaforma
        if (other.gameObject.tag == "Die")
        {
             platform = false;
			_player.transform.parent = null;
		}

        
	}

    private void  WalkSound()
{
  AudioManager.instance.PlaySFX(4);
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
