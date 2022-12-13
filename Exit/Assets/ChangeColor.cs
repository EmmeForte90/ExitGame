using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] GameObject B;
    [SerializeField] GameObject R;
    [SerializeField] GameObject eff;
    [SerializeField] GameObject Coll;


    [SerializeField] bool Blu;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && Blu)
        {
            B.SetActive(false);
            Instantiate(eff, B.transform.position, B.transform.rotation);
            R.SetActive(true);
            Blu = false;
        }else if(Input.GetKeyDown(KeyCode.LeftShift) && !Blu)
        {
            B.SetActive(true);
            Instantiate(eff, R.transform.position, R.transform.rotation);
            R.SetActive(false);
            Blu = true;

        }

if (PlayerMovement.instance.Blu && Blu)
        {
            Coll.SetActive(true);
		}
        else if (PlayerMovement.instance.Blu && !Blu)
        {
            Coll.SetActive(false);
		}


if (!PlayerMovement.instance.Blu && Blu)
        {
            Coll.SetActive(false);
		}
        else if (!PlayerMovement.instance.Blu && !Blu)
        {
            Coll.SetActive(true);
		}


    }

    }








