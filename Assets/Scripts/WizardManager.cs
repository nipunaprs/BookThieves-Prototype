using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardManager : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;

    public GameObject player;
    public GameObject fireball;
    public GameObject firePoint;
    public float detectRange = 15f;
    public float fireSpeed = 10f;
    public float attackDelayTime = 3f;
    bool canAttack = true;
    bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float player_dis = player.transform.position.x - transform.position.x;
        float directionSign = Mathf.Sign(player_dis);

        //If player is in range, start shooting fireballs
        if (Mathf.Abs(player_dis) <= detectRange && canAttack) {

            HandleAttack();
        
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
        //Start shooting
        GameObject fireballP = (GameObject)Instantiate(fireball, firePoint.transform.position, fireball.transform.rotation);
        Rigidbody2D fireballrb = fireballP.GetComponent<Rigidbody2D>();
        if (facingLeft)
        {
            fireballrb.velocity = new Vector2(-fireSpeed, 0f);
        }
        else
        {
            fireballrb.velocity = new Vector2(fireSpeed, 0f);
        }
        

        canAttack = false;
        Invoke("ResetAttack", attackDelayTime);
    }

    void ResetAttack()
    {
        canAttack = true;
    }
}
