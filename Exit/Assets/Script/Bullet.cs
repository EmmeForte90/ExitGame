using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   [Header("Bullet")]
    [SerializeField] float bulletSpeed = 20f;
    //Variabile della velocità del proiettile
    [SerializeField] GameObject Explode;
    [SerializeField] Transform prefabExp;
    private float lifeTime = 0.5f;
    //Riservato allo shotgun

    Rigidbody myRigidbody;
    //Il corpo rigido
    GameObject Enemies;
    //Attribuscie una variabile allo script di movimento del player
    //Per permettere al proiettile di emularne l'andamento
    float xSpeed;
    //L'andatura
    //Riservato alla bomb

    


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        //Recupera i componenti del rigidbody
        //Recupera i componenti dello script
        xSpeed = Enemies.transform.localScale.x * bulletSpeed;
        //La variabile è uguale alla scala moltiplicata la velocità del proiettile
        //Se il player si gira  anche lo spawn del proittile farà lo stesso
        

        
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
        //se il player si sta muovendo le sue coordinate x sono maggiori di quelle e
        //di un valore inferiore a 0

        if (bulletHorSpeed) //Se il player si sta muovendo
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
            //La scala assume un nuovo vettore e il rigidbody sull'asse x 
            //viene modificato mentre quello sull'asse y no. 
        }
        
        
    }

#endregion


    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        //Se il proiettile tocca il nemico
        {            
            Instantiate(Explode, transform.position, transform.rotation);
            //CameraShake.Shake(0.10f, 0.50f);
            
            Destroy(gameObject);
            

            
           
        }

        if(other.gameObject.tag == "Ground")
        //Se il proiettile tocca il nemico
        {            
            Instantiate(Explode, transform.position, transform.rotation);
            //CameraShake.Shake(0.10f, 0.50f);
            Destroy(gameObject);
            //Viene distrutto
        }
        
        
    }

    void Destroy()
    {
        Destroy(gameObject);   
    }

    void OnCollisionEnter(Collision other) 
    {
        Destroy(gameObject);   
        //Se il proiettile tocca una superficie viene distrutto 
    }

}
