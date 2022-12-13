using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
     public GameObject B;
     public GameObject R;
     public GameObject eff;

     bool Blu;


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
        }
    }

