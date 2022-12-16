using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] GameObject B;
    [SerializeField] GameObject R;
    [SerializeField] GameObject eff;
    [SerializeField] GameObject Coll;

[Header("Sound")]
    [SerializeField] public AudioSource glitchS;
    [SerializeField] bool Blu;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && Blu)
        {
            B.SetActive(false);
            Instantiate(eff, B.transform.position, B.transform.rotation);
            glitchS.Play();
            R.SetActive(true);
            Blu = false;
        }else if(Input.GetKeyDown(KeyCode.LeftShift) && !Blu)
        {
            B.SetActive(true);
            Instantiate(eff, R.transform.position, R.transform.rotation);
            glitchS.Play();
            R.SetActive(false);
            Blu = true;

        }

if (Blu)
        {
            Coll.SetActive(true);
		}
        else if (!Blu)
        {
            Coll.SetActive(false);
		}

/*
if (!PlayerMovement.instance.Blu && Blu)
        {
            Coll.SetActive(false);
		}
        else if (!PlayerMovement.instance.Blu && !Blu)
        {
            Coll.SetActive(true);
		}
*/

    }

    }










