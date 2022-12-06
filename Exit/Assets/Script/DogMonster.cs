using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //protected Rigidbody3D RB;
        protected Rigidbody RB;

    [SerializeField ]
    public float bounceForce = 30f;
    [SerializeField] 
    public float timeHurt = 0.5f;
    [SerializeField ]
    public Transform Enemy;
    [HideInInspector] public bool isWait = false;
    [HideInInspector] public bool sfxM = false;


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
    protected bool attack = false;
    
    [Header("Movimenti")]
    [SerializeField]
    public Transform LP;
    public Transform RP;
    private float horizontal;
    [Header("parametri d'attacco")]
    [SerializeField] Transform agroPos;
    [SerializeField] LayerMask playerlayer;
    [SerializeField] public float agroRange;

    //[Header ("Morte")]
    //public GameObject DIE;



    private void Awake()
    {
        //Inizializzazione
        instance = this;
        LP.parent = null;
        RP.parent = null;
        moveCount = moveTime;
        instance = this;
        anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        HP = MaxHP;
        //HPBarra.SethmaxHP(MaxHP);

    }

     void Update(){
//Calcolo distanza tra player e nemico
float disToPlayer = Vector3.Distance(transform.position, PlayerMovement.instance.transform.position);
Debug.DrawRay(transform.position, new Vector3(agroRange, 0), Color.red);
#region Se il nemico NON sta attaccando...
if(PlayerMovement.instance.death)
{
            waitPlayer();

}
else if(!PlayerMovement.instance.death){


if(!isAttack && disToPlayer > agroRange){

    StopAttack();

            if (moveCount > 0)
            //Tempo di pausa per far fermare il nemico
            {
                moveCount -= Time.deltaTime;
                //MovimentoPer deltatime

                if (movingRight)
                //Se si muove a destra
                {
                    RB.velocity = new Vector3(moveSpeed, RB.velocity.y);
                    //Un vettore lo fa muovere a destra
                    if (transform.position.x > RP.transform.position.x)
                    //Se la posizione è maggiore del RightPoint
                    {
                        movingRight = false;
                        //Non si muove più a destra
                        transform.localScale = new Vector3(-1, transform.localScale.y, 0);
                        //Si volta dall'altra parte e inizia a muoversi
                    }
                }
                else
                {
                    RB.velocity = new Vector3(-moveSpeed, RB.velocity.y);
                    //Il vettore lo fa muovere a sinistra
                    if (transform.position.x < LP.transform.position.x)
                    {
                        movingRight = true;
                        //Si muove a destra
                        transform.localScale = new Vector3(1, transform.localScale.y, 0);
                        //Si volta dall'altra parte e inizia a muoversi
                    }
                }

                if (moveCount <= 0)
                //Se il conteggio del movimento è uguale o inferiore a zero
                {
                    waitCount = Random.Range(waitTime * .75f, waitTime * 1.35f);
                    //Il tempo di attesa diventa randomico
                }

                anim.SetBool("isMoving", true);
            }
            else if (waitCount > 0)
            //Se il conteggio del movimento è maggiore di zero
            {
                waitCount -= Time.deltaTime;
                RB.velocity = new Vector3(0f, RB.velocity.y);
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

#region Se il nemico STA ATTACCANDO
else if(disToPlayer < agroRange && !isWait)
{          
    //Se non sta attaccando 
    if(!isAttack)
    {
    //Insegue il player
    ChasePlayer();
    
    }
   
}
//Altrimenti smettere di inseguirlo
    else if(disToPlayer > agroRange && !isWait)
    {
    StopChasingPlayer();
    }
    //Se il player è in un punto alto in cui il nemico non può raggiungerlo questo aspetta
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 5f, playerlayer))
        {
            isWait = true;
            anim.SetBool("isMoving", false);
            waitPlayer();
        } 
        else if(!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), 5f, playerlayer))
        {
            isWait = false;
            anim.SetBool("isMoving", true);
        }
        else if(disToPlayer > agroRange && !isWait)
        {
        StopChasingPlayer();
        } 

#endregion
} 
     }

#region  indicatori engine
void OnDrawGizmosSelected()
{
     Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(agroPos.position, agroRange);
    
}
#endregion

private void  IdleSound()
{
  AudioManager.instance.PlaySFX(7);
}

private void  AgroSound()
{
  AudioManager.instance.PlaySFX(8);
}

#region  Insegue il player

private void  ChasePlayer()
{
   
    anim.SetBool("isRunning", true);
if(transform.position.x < PlayerMovement.instance.transform.position.x)
{
  
    //Sinistra
    RB.velocity = new Vector3(runSpeed, 0);
    movingRight = true;
    transform.localScale = new Vector3(1, transform.localScale.y,  0);
}
else if(transform.position.x > PlayerMovement.instance.transform.position.x)
{
    //Destra
    
    RB.velocity = new Vector3(-runSpeed, 0, 0);
    movingRight = false;
    transform.localScale = new Vector3(-1, transform.localScale.y, 0);
}
}

private void StopChasingPlayer()
{
        

    StopAttack();
    anim.SetBool("isRunning", false);
    RB.velocity = new Vector3(moveSpeed, 0);
}

private void waitPlayer()
{
    StopAttack();
    anim.SetBool("isRunning", false);
    anim.SetBool("isMoving", false);
    RB.velocity = new Vector3(0, 0);
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

#region  Attacco
public void Attack()
    {
    isAttack = true;
    RB.velocity = new Vector3(0, 0);
    anim.SetBool("isMoving", false);
    anim.SetBool("isAttack", true);
    }

public void StopAttack()
    {
        isAttack = false;
        anim.SetBool("isAttack", false);
        anim.SetBool("isRunning", false);
        moveCount = moveTime;

    }


#endregion


}