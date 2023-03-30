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
    public float detectDist = 7f;
    public float attackDist = 3f;


    //Movement variables
    public float speed = 3f;
    public float stoppingDist = 2;
    bool facingLeft = true;

    //Attack variables
    bool canAttack = false; //Use for timeout btwn attacks
    bool attackingNow = false;
    float attackCooldown = 2f;



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

        //If player is in range, and can attack -- start attacking
        if (Mathf.Abs(player_dis) <= attackDist && canAttack)
        {

            HandleAttack();

        }
        else if(Mathf.Abs(player_dis) <= detectDist) //Player is in detect range, but not attack range
        {
            //Activate move towards player
            MoveTowards();
        }
        else if(Mathf.Abs(player_dis) > detectDist) //Idle walk if the player is not in detect distance
        {

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


        //Check collisions


        canAttack = false;
        Invoke("ResetAttack", attackCooldown);
    }

    void ResetAttack()
    {
        canAttack = true;
    }

    void MoveTowards()
    {
        /*
         * UPDATE THIS CODE TO MATCH
         * 
        //Set velocity to zero first
        myrigidbody.velocity = Vector2.zero;

        //If player is in attack range start attacking
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {

            transform.position = this.transform.position;
            isAttacking = true;

        }
        else
        {
            //Code to move towards players location
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            isAttacking = false;
            ResetValues();
        }
        */
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerFireball")
        {   
            /*
            //Decrease health by 5
            health = health - 5;
            //If hit with knife, start attacking
            attackNow = true;
            */
        }

        //If playing attack animation and colliding with player, then do damage
        if (col.tag == "Player" && this.animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {

            //Access take damage function in player and do 1 damage
            player.GetComponent<PlayerManager>().doDamage(5);

        }

    }
}
