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
    private float flashTime =0.5F;
    Color origionalColor;
    public SpriteRenderer renderer;

    public AudioSource enemyDeathSound;
    public AudioSource enemyDamageSound;

    //Timeout For Damage
    bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        origionalColor = GetComponent<Renderer>().material.color;
        animator = GetComponent<Animator>();   
    }

 

  

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyHealth <= 0)
        {


            //gameObject.SetActive(false);
            Destroy(gameObject,1f);


        }
    }

    public void doDamage(int damage)
    {
        
        enemyHealth -= damage;
        enemyDamageSound.Play();
        FlashRed();

        if (enemyHealth <= 0)
        {
            enemyDeathSound.Play();
            animator.SetTrigger("death");

        }

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

    void FlashRed()
    {
        GetComponent<Renderer>().material.color = Color.red;
        Invoke("ResetColor", flashTime);
    }
    void ResetColor()
    {
        GetComponent<Renderer>().material.color = origionalColor;
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
