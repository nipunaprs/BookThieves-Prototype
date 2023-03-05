using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulManager : MonoBehaviour
{

    public float movementSpeed = 2f;
    Rigidbody2D rigidbody2;
    bool m_FacingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
 
        

        if (isFacingRight())
        {
            rigidbody2.velocity = new Vector2(movementSpeed, 0f);
        }
        else
        {
            rigidbody2.velocity = new Vector2(-movementSpeed, 0f);
        }
    
        



    }

    private bool isFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
            transform.localScale = new Vector2(-(Mathf.Sign(rigidbody2.velocity.x)),transform.localScale.y);
    }



}
