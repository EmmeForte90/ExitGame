using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Transform player;
    public Rigidbody myRigidbody;
    [SerializeField] public LayerMask layerMask;

    public static PlayerMovement instance;
     void Awake()
    {
        instance = this;

    }
        
            


}
