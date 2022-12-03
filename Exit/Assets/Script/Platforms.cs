using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
public Transform[] points;

    [SerializeField]  float moveSpeed;
    [SerializeField]  int currentPoint;
    [SerializeField]  Transform platform;
    [SerializeField]  bool saw = false;
    
    [Header("Sound")]
        public AudioClip sfx_Platform;
        public AudioClip sfx_Saw;
        
        [HideInInspector]
        public AudioSource audioS;

 private void Awake()
        {
            
            audioS = GetComponent<AudioSource>();
        }
    // Update is called once per frame
    void Update()
    {
        //La piattaforma si muove nei punti e nella velocità stabiliti
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        //Conteggio dei puntidi locazione
        if(Vector3.Distance(platform.position, points[currentPoint].position) <.05f)
        {
            currentPoint++;

            if(currentPoint >= points.Length)
            {
                currentPoint = 0;

            }

            if(saw)
            {
            audioS.PlayOneShot(sfx_Saw);
            } else if(!saw)
            {
            audioS.PlayOneShot(sfx_Platform);
            }

        }
    }

/*

	[SerializeField] private Vector3[] posizioni;
	private int index_posizioni;
	
	public float velocita_totale;
	
    private void FixedUpdate(){
		transform.position = Vector2.MoveTowards(transform.position,posizioni[index_posizioni], Time.deltaTime*velocita_totale);
		
		if (transform.position==posizioni[index_posizioni]){
			if (index_posizioni==posizioni.Length -1){
				index_posizioni=0;
			} else {index_posizioni++;}
		}
    }*/
}
