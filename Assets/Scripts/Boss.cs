using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{

    Animator animator;
    public GameObject player;
    private Rigidbody2D rb;

    //Player detection variables
    public float detectDist = 20f;
    //public float attackDist = 3f;


    //Movement variables
    public float speed = 3f;
    public float stoppingDist = 5f;
    bool facingLeft = true;

    //Attack variables
    bool canAttack = true; //Use for timeout btwn attacks
    bool isAttacking = false;
    bool isIdle = true;
    bool isWalking = false;
    float attackCooldown = 1.0f;

    bool doDamageTimeout = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float player_dis = player.transform.position.x - transform.position.x;
        float directionSign = Mathf.Sign(player_dis);
        //Debug.Log(Mathf.Abs(player_dis));

       
        //Debug.Log(Mathf.Abs(player_dis) <= stoppingDist && canAttack);

        //If player is in range, and can attack -- start attacking
        if (Mathf.Abs(player_dis) <= stoppingDist && canAttack)
        {

            //Debug.Log("attacking distance + attacking");
            HandleAttack();
            HandleAnimations();

        }
        else if(Mathf.Abs(player_dis) <= detectDist && Mathf.Abs(player_dis) > stoppingDist) //Player is in detect range, but not attack range
        {
            //Activate move towards player
            //Debug.Log("moving towards player");
            MoveTowards();
        }
        else if(Mathf.Abs(player_dis) > detectDist) //Idle walk if the player is not in detect distance
        {
            //Debug.Log("idling");
            isIdle = true;
            isWalking = false;
            isAttacking = false;
            HandleAnimations();

        }
        else if (Mathf.Abs(player_dis) <= stoppingDist && !canAttack)
        {

            //Debug.Log("waiting on cooldown");
            isIdle = true;
            isAttacking = false;
            Debug.Log(isAttacking);
            HandleAnimations();

        }



        //Handle flipping
        if (directionSign < 0)
        {
            //Face left
            facingLeft = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            facingLeft = false;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }

    void HandleAttack()
    {

        //Play attack animations
        //Debug.Log("Inside Handle Attack");
        isAttacking = true;
        isWalking = false;
        isIdle = false;
        HandleAnimations();


        //Reset attack
        canAttack = false;
        //isAttacking = false;
        //isIdle = true;
        Invoke("ResetAttack", attackCooldown);
    }

    void ResetAttack()
    {
        //Debug.Log("Invoked");
        canAttack = true;
    }

    void HandleAnimations()
    {
        if (isIdle && !isAttacking && !isWalking)
        {


            animator.SetBool("walk", false);
            animator.SetBool("attack", false);
        }
        else if(!isIdle && !isAttacking && isWalking){
            animator.SetBool("walk", true);


            animator.SetBool("attack", false);

        }
        else if (!isIdle && isAttacking && !isWalking)
        {
            animator.SetBool("attack", true);

            animator.SetBool("walk", false);
        }
        
    }


    void MoveTowards()
    {
        
        //Set velocity to zero first
        rb.velocity = Vector2.zero;

        //Code to move towards players location
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        isWalking = true;
        isAttacking = false;
        isIdle = false;
        HandleAnimations();

        /*
        //If player is in attack range start attacking
        if (Vector2.Distance(transform.position, player.transform.position) < stoppingDist)
        {

            transform.position = this.transform.position;
            isWalking = false;
            isIdle = true;
            HandleAnimations();
        }
        else
        {
            //Code to move towards players location
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            isWalking = true;
            isIdle = false;
            HandleAnimations();
        }*/
        
    }


    void OnTriggerStay2D(Collider2D col)
    {
        /*
        if (col.tag == "PlayerFireball")
        {   
            
            //Decrease health by 5
            health = health - 5;
            //If hit with knife, start attacking
            attackNow = true;
            
        }*/
        Debug.Log("collision detected");
        //If playing attack animation and colliding with player, then do damage
        if (col.tag == "Player" && this.animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            Debug.Log("player detected");
            //Access take damage function in player and do 1 damage
            if(!doDamageTimeout)
                player.GetComponent<PlayerLvl2>().doDamage(15);
            doDamageTimeout = true;
            Invoke("WaitDamage", 1.0f);

        }

    }

    void WaitDamage()
    {
        doDamageTimeout = false;
    }

}
