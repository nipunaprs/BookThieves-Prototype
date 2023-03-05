using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyHealth = 80;
    public int damageAmmout = 10;
    public int takeDamageAmmount = 20; //default take 20 damage
    public bool collisionDamage = true;
    public GameObject player;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
     animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    async void Update()
    {
        if (enemyHealth <= 0)
        {
            animator.SetTrigger("death");


            //gameObject.SetActive(false);
            Destroy(gameObject,0.5f);


        }
    }

    public void doDamage(int damage)
    {
        
        enemyHealth -= damage;
        Debug.Log("Enemy Health: " + enemyHealth.ToString());
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collisionDamage == true)
        {
            collision.gameObject.GetComponent<PlayerManager>().doDamage(damageAmmout);
        }
    }

}
