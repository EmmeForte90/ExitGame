using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMonster : MonoBehaviour
{
    //public int HP { get; set; }
    public static DogMonster instance;

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
    
    [Header("Movimenti")]
    [SerializeField]
    public Transform LP;
    public Transform RP;
    private float horizontal;
    [Header("parametri d'attacco")]
    [SerializeField] Transform attackPos;
    [SerializeField] Transform agroPos;
    [SerializeField] LayerMask playerlayer;
    [SerializeField] float nextAttackTime;
    [SerializeField] public float attackRange;
    [SerializeField] public float animationAttackRange;
    [SerializeField] public float agroRange;

    //[Header ("Morte")]
    //public GameObject DIE;


    //Variabile per il tempo d'attacco

    private void Awake()
    {
        //Inizializzazione
        instance = this;
        LP.parent = null;
        RP.parent = null;
        moveCount = moveTime;
        instance = this;
        anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        HP = MaxHP;
        //HPBarra.SethmaxHP(MaxHP);

    }

void Update()
{    
    #region Se il nemico NON sta attaccando...

/*float disToPlayer = Vector2.Distance(Enemy.transform.position, PlayerMovement.instance.transform.position);
Debug.DrawRay(transform.position, new Vector2(agroRange, 0), Color.red);
Debug.DrawRay(transform.position, new Vector2(attackRange, 0), Color.blue);
if(!isAttack && disToPlayer > agroRange){
*/

            if (moveCount > 0)
            //Tempo di pausa per far fermare il nemico
            {
                moveCount -= Time.deltaTime;
                //MovimentoPer deltatime

                if (movingRight)
                //Se si muove a destra
                {
                    RB.velocity = new Vector2(moveSpeed, RB.velocity.y);
                    //Un vettore lo fa muovere a destra
                    if (transform.position.x > RP.transform.position.x)
                    //Se la posizione è maggiore del RightPoint
                    {
                        movingRight = false;
                        //Non si muove più a destra
                        transform.localScale = new Vector2(-1, transform.localScale.y);
                        //Si volta dall'altra parte e inizia a muoversi
                    }
                }
                else
                {
                    RB.velocity = new Vector2(-moveSpeed, RB.velocity.y);
                    //Il vettore lo fa muovere a sinistra
                    if (transform.position.x < LP.transform.position.x)
                    {
                        movingRight = true;
                        //Si muove a destra
                        transform.localScale = new Vector2(1, transform.localScale.y);
                        //Si volta dall'altra parte e inizia a muoversi
                    }
                }

                if (moveCount <= 0)
                //Se il conteggio del movimento è uguale o inferiore a zero
                {
                    waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
                    //Il tempo di attesa diventa randomico
                }

                anim.SetBool("isMoving", true);
            }
            else if (waitCount > 0)
            //Se il conteggio del movimento è maggiore di zero
            {
                waitCount -= Time.deltaTime;
                RB.velocity = new Vector2(0f, RB.velocity.y);
                //Il personaggio si muove
                if (waitCount <= 0)
                //Se il conteggio del movimento è uguale o inferiore a zero
                {
                    moveCount = Random.Range(moveTime * .75f, waitTime * .75f);
                    //Il tempo di movimento diventa randomico
                }
                anim.SetBool("isMoving", false);
            }
        } 
#endregion



    #region  indicatori engine
void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(attackPos.position, attackRange);
     Gizmos.color = Color.white;
    Gizmos.DrawWireSphere(agroPos.position, agroRange);
     Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(attackPos.position, animationAttackRange);
}
#endregion

#region  Flippa lo sprite
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


}
