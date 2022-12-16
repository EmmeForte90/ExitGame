using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] GameObject R;
    [SerializeField] GameObject eff;
    int value = 1;

[Header("Sound")]
    [SerializeField] public AudioSource glitchS;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(value == 1)
            {
            Instantiate(eff, R.transform.position, R.transform.rotation);
            glitchS.Play();
            R.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90f);
            value = 2;
            }else if(value == 2)
            {
            Instantiate(eff, R.transform.position, R.transform.rotation);
            glitchS.Play();
            R.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -180f);
            value = 3;
            }else if(value == 3)
            {
            Instantiate(eff, R.transform.position, R.transform.rotation);
            glitchS.Play();
            R.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90f);
            value = 4;
            }else if(value == 4)
            {
            Instantiate(eff, R.transform.position, R.transform.rotation);
            glitchS.Play();
            R.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
            value = 1;
            }
        }




    }
}

