using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator animator;
    public float health = 100;

    bool isAttacking;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            HandleAttack();
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            //set attacking to false
            isAttacking = false;
            animator.SetBool("attack", false);
        }
    }


    void HandleAttack()
    {
        //play animation
        animator.SetBool("attack", true);
        isAttacking = true;
 

        
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "DeathArea")
        {
            Destroy(gameObject);
        }


        //do damange if enemy collider check
        if (isAttacking && collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collision");
            collision.gameObject.GetComponent<EnemyManager>().doDamage(20);
        }
    }

    public void doDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health.ToString());
    }


}
