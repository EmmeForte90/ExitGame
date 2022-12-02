using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMonster : MonoBehaviour
{
public static BatMonster instance;

    [Header("Sistema Di HP")]
    [SerializeField]
    public int HP;
    [SerializeField]
    public int MaxHP;
    [SerializeField]
    public GameObject enemy;
    
    [Header("Fisica")]
    [SerializeField]
    protected Rigidbody2D RB;
    [SerializeField ]
    public float bounceForce = 20f;
    [SerializeField] 
    public float timeHurt = 0.5f;
    [SerializeField ]
    public Transform Enemy;
    [HideInInspector] public bool isWait = false;




 [Header("Movimenti")]
	public Transform[] points;
    public int currentPoint;
    public Transform platform;
        private float horizontal;


    [Header("Shooting")]
    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    public Transform firePoint;
    [SerializeField]
    public float timeBetweenShots;
    [SerializeField]
    public float shotCounter;
    [SerializeField]
    public float FUOCO;
    [SerializeField]
    public GameObject blam;

	[Header("Calcoli distanza")]
	[SerializeField] public float targetRange;
	[SerializeField] Transform attackPos;

[Header("Tempo di movimento")]
    [SerializeField]
    public float moveSpeed;
     [SerializeField]
    public float runSpeed;
    [SerializeField]
    public float moveTime, waitTime;
    [SerializeField]
    public float moveCount, waitCount;
    [SerializeField]
    protected Animator anim;
    protected bool hit = false;
    protected bool isDead = false;
    protected bool movingRight = true;
    protected bool isAttack = false;
    
    
    /*[Header("parametri d'attacco")]
    [SerializeField] Transform agroPos;
    [SerializeField] LayerMask playerlayer;
    [SerializeField] float nextAttackTime;
    [SerializeField] public float attackRange;
    [SerializeField] public float animationAttackRange;
    [SerializeField] public float agroRange;*/


      private void Awake()
    {
        //Inizializzazione
        instance = this;
        moveCount = moveTime;
    }	

	private void FixedUpdate()
	{
		#region  Se il nemico NON sta attaccando
		if(!isAttack)
		{
		//La piattaforma si muove nei punti e nella velocità stabiliti
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
		anim.SetBool("isMoving", true);
        //Conteggio dei puntidi locazione
        if(Vector3.Distance(platform.position, points[currentPoint].position) <.05f)
        {
            currentPoint++;

            if(currentPoint >= points.Length)
            {
                currentPoint = 0;

            }
        }
		}
		#endregion

		#region Se il nemico STA ATTACCANDO
				float disToPlayerToAttack = Vector2.Distance(transform.position, PlayerMovement.instance.transform.position);
		Debug.DrawRay(transform.position, new Vector2(targetRange, 0), Color.red);

		if(disToPlayerToAttack < targetRange)
   			{
    			Shoot();
    			if(isAttack)
        		{	
        		if (transform.position.x < PlayerMovement.instance.transform.position.x)
        		{
					horizontal = 1;
				}
				else 
				{
					horizontal = -1;
				}
        		Flip();
        		}
   			}
			else if(disToPlayerToAttack > targetRange)
   			{
    				StopAttack();
    		}
	}
		#endregion
	
#region Attack
	public void Shoot()
	{
		shotCounter -= Time.deltaTime;
		isAttack = true;
				if (shotCounter <= 0)
				{
					shotCounter = timeBetweenShots;
					//Repeting shooter
					var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
					Instantiate(blam, firePoint.position, firePoint.rotation);
					//AudioManager.instance.PlaySFX(4);
					anim.SetBool("isAttack", isAttack);
					anim.SetTrigger("isShoot");
					newBullet.transform.localScale = Enemy.localScale;
				}
	}
	public void StopAttack()
    {
        isAttack = false;
        anim.SetBool("isAttack", isAttack = false);
        moveCount = moveTime;

    }

	private void Flip()
    {
        if (movingRight && horizontal < 0f || !movingRight && horizontal > 0f)
        {
            movingRight = !movingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
	#endregion

#region  indicatori engine
void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(attackPos.position, targetRange);
}
#endregion

}
