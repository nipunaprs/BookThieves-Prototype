using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Animator animator;
    public float health = 100;

    bool isAttacking;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Fall down death
        if (collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }

        
        //do damange if enemy collider check
        if (isAttacking && collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Doing Damage");
            int damageAmmount = collision.gameObject.GetComponent<EnemyManager>().takeDamageAmmount;
            collision.gameObject.GetComponent<EnemyManager>().doDamage(damageAmmount);
        }

        //Reach book
        if (collision.gameObject.tag == "Book")
        {
            
            collision.gameObject.SetActive(false);
            SceneManager.LoadScene(2);

            //Switch scenes to end screen
        }
    }

    public void doDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health.ToString());
    }


}
