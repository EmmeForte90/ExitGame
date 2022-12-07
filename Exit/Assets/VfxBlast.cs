using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxBlast : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] private float bulletSpeed = 1f;
    //Variabile della velocità del proiettile
    Rigidbody myRigidbody;
    //Il corpo rigido
    BatMonster bat;
    //Attribuscie una variabile allo script di movimento del bat
    //Per permettere al proiettile di emularne l'andamento
    float xSpeed;
    //L'andatura
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        //Recupera i componenti del rigidbody
        bat = FindObjectOfType<BatMonster>();
        //Recupera i componenti dello script
        xSpeed = bat.transform.localScale.x * bulletSpeed;
        //La variabile è uguale alla scala moltiplicata la velocità del proiettile
        //Se il bat si gira  anche lo spawn del proittile farà lo stesso
    }

#region Update
    void Update()
    {
         myRigidbody.velocity = new Vector2 (xSpeed, 0f);
        //La velocità e la direzione del proiettile
        FlipSprite();
        
    }
#endregion

#region  FlipSprite
    void FlipSprite()
    {
        bool bulletHorSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        //se il bat si sta muovendo le sue coordinate x sono maggiori di quelle e
        //di un valore inferiore a 0

        if (bulletHorSpeed) //Se il bat si sta muovendo
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
            //La scala assume un nuovo vettore e il rigidbody sull'asse x 
            //viene modificato mentre quello sull'asse y no. 
        }
        
    }

#endregion
}
