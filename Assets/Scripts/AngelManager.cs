using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class AngelManager : MonoBehaviour
{
    public float movementSpeed = 2f;
    bool goingDown = true;
    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingDown)
        {
            rb.velocity = new Vector2(0f, -movementSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0f, movementSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && transform.position.y < -0.3 && collision.gameObject.tag=="Wall")
        {
            //Debug.Log("reached floor");
            goingDown = false;
        }
        else if(collision != null && transform.position.y > -0.3 && collision.gameObject.tag == "Wall")
        {
            goingDown = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("attack",true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("attack", false);
        }
    }

}
