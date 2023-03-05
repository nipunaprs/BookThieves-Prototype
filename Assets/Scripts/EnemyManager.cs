using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyHealth = 40;
    public int damageAmmout;
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
        Debug.Log(enemyHealth);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().doDamage(damageAmmout);
        }
    }

}
