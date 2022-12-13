using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity.AttachmentTools;
using Spine.Unity;
using Spine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] public GameObject _player;
    [SerializeField] public GameObject _fade;
    [SerializeField] public GameObject DieAnm;
    [SerializeField] public GameObject pause;
    [SerializeField] public GameObject eff;
    [SerializeField] public GameObject B;
    [SerializeField] public GameObject R;
    [SerializeField] public SkeletonMecanim skelMecanim;

    [SerializeField] Transform player;
    public Rigidbody myRigidbody;
    [SerializeField] public LayerMask layerMask;
    [HideInInspector] public bool death = false;
    [HideInInspector] public bool buttonPress = false;
    [HideInInspector] public bool Blu;

    [Header("Sound")]
    [SerializeField] public AudioSource ChangeColorS;
    [SerializeField] public AudioSource Walk;



    bool platform = false;
    public static PlayerMovement instance;


     void Awake()
    {
        instance = this;
        var skeleton = skelMecanim.Skeleton;
            skeleton.SetSkin("blu");
            R.SetActive(false);
            Blu = true;

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

        if(Input.GetKeyDown(KeyCode.LeftShift) && Blu)
        {

            Instantiate(eff, _player.transform.position, _player.transform.rotation);
            B.SetActive(false);
            ChangeColorS.Play();
            var skeleton = skelMecanim.Skeleton;
            skeleton.SetSkin("red");
            R.SetActive(true);
            Blu = false;
        }else if(Input.GetKeyDown(KeyCode.LeftShift) && !Blu)
        {
            Instantiate(eff, _player.transform.position, _player.transform.rotation);
            B.SetActive(true);
            ChangeColorS.Play();
            var skeleton = skelMecanim.Skeleton;
            skeleton.SetSkin("blu");
            R.SetActive(false);
            Blu = true;

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

    public void  WalkSound()
{
                Walk.Play();
}


 public void  NullParent()
{
                platform = false;
			_player.transform.parent = null;
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

