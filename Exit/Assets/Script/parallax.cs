using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class parallax : MonoBehaviour
{
    private float horizontal;
    private bool bool_dir_dx = true;
	public GameObject character;
	public float speed;
	public int distance;
	
	public float speed_2;
	public int distance_2;
	
	public float speed_3;
	public int distance_3;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.x<character.transform.position.x){horizontal=1;}
		else {horizontal=-1;}
        if (Vector2.Distance(transform.position, character.transform.position)>distance){
			if (Vector2.Distance(transform.position, character.transform.position)>distance_2){
				if (Vector2.Distance(transform.position, character.transform.position)>distance_3){
					transform.position = Vector2.MoveTowards(transform.position, character.transform.position, speed_3*Time.deltaTime);
				} else {
					transform.position = Vector2.MoveTowards(transform.position, character.transform.position, speed_2*Time.deltaTime);
				}
			} else {
				transform.position = Vector2.MoveTowards(transform.position, character.transform.position, speed*Time.deltaTime);
			}
		}
    }
	
	
}
