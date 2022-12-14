using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
		[Header("GameObject e Target")]
	public Transform thePlatform, slammerTarget, slammerPoint, slammerReset; 
    private Vector3 startPoint;
    public float slamSpeed, waitAfterSlam, resetSpeed;
    private float waitCounter;
    [SerializeField] public float agroRange;
    private bool slamming, resetting;
    [SerializeField]
    protected Animator _anim;
    bool danger = false;
	
	[Header("Time")]
	[SerializeField] float timerValue;
	[SerializeField] float waitFall;//Il valore numero del timer

    void Awake()
    {
        startPoint = thePlatform.position;
		timerValue = waitFall;
        _anim = GetComponent<Animator>();


    }
#region  indicatori engine
void OnDrawGizmosSelected()
{
     Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(slammerReset.position, agroRange);
    
}
#endregion

    void Update()
    {
#region Targetizzazione
        //Se non sta attaccando

        float disToPlayer = Vector2.Distance(transform.position, PlayerMovement.instance.transform.position);

        if(disToPlayer < agroRange)
        {
            if (!slamming && !resetting)
        {
            danger = true;
            _anim.SetBool("danger", true);
            StartCoroutine(UpdateTimer());
			
        }
        }
       
        if (slamming)
        {
            thePlatform.position = Vector3.MoveTowards(thePlatform.position, slammerTarget.position, slamSpeed * Time.deltaTime);


            //Quando colpisce l'area designata
            if (thePlatform.position == slammerTarget.position)
            {

                waitCounter -= Time.deltaTime;
                if (waitCounter <= 0)
                {
                    slamming = false;
                    resetting = true;
                    danger = false;
                    _anim.SetBool("danger", false);
                }

            }
        }
        //Modalità di ripristino
        if (resetting)
        {
            thePlatform.position = Vector3.MoveTowards(thePlatform.position, slammerReset.position, resetSpeed * Time.deltaTime);
           

            if (thePlatform.position == slammerReset.position)
            {
                resetting = false;
				timerValue = waitFall;

            }
        }
    }
	#endregion

private IEnumerator UpdateTimer()
{
    yield return new WaitForSeconds(timerValue);
    slamming = true;
    waitCounter = waitAfterSlam;
}
	
/*void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        //Indica quanto valore perde la variabile a frame
            if(timerValue < 0) //E il valore del timer è maggiore di 0
            {
                slamming = true;
                waitCounter = waitAfterSlam;
            }
           
    }*/
}
