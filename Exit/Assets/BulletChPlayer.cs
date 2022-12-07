using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChPlayer : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 7f;
	private Rigidbody rb;
	PlayerMovement target;
	Vector2 moveDirection;
	[SerializeField] GameObject Explode;
	

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		target = GameObject.FindObjectOfType<PlayerMovement>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
	}
	
	private void OnCollisionEnter(Collision collision){
		Destroy(gameObject);

	}

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
}
