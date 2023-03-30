using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public int enemyHealth = 80;
    public int damageAmmout = 10;
    public int takeDamageAmmount = 20; //default take 20 damage
    public bool collisionDamage = true;
    public GameObject player;
    Animator animator;

    //Timeout For Damage
    bool canAttack = true;

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
        
    }
    
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collisionDamage == true)
        {
            collision.gameObject.GetComponent<PlayerManager>().doDamage(damageAmmout);
        }
    }*/

    private void OnCollisionStay2D(Collision2D collision)
    {

        //Take consistent damange every 1 second when touching
        if (collision.gameObject.tag == "Player" && collisionDamage == true && canAttack == true)
        {
            //Debug.Log("Trigger CoRoutine : " + Time.time);
            StartCoroutine(ExampleCoroutine());

            if(SceneManager.GetActiveScene().name == "Lvl1")
                collision.gameObject.GetComponent<PlayerManager>().doDamage(damageAmmout);
            else
                collision.gameObject.GetComponent<PlayerLvl2>().doDamage(damageAmmout);

            //Debug.Log("Damage Done : " + Time.time);
        }
        
       

    }


    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        canAttack = false;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        canAttack = true;
        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

  
}
