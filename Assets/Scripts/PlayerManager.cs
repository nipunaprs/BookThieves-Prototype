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
        }
    }


    void HandleAttack()
    {
        //play animation
        animator.SetBool("attack", true);
        isAttacking = true;
 

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //do damange if enemy collider check
        if (isAttacking && collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyManager>().doDamage(20);
        }
    }


}
