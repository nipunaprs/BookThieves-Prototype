using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject gameManager;
    public Animator animator;
    public int health = 100;

    bool isAttacking;
    bool canAttack = true;

    public AudioSource collectSound;
    public AudioSource lvlCompleteSound;
    public AudioSource deathSound;
    public AudioSource kickAttackSound;
    public AudioSource losingHealth;


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
        kickAttackSound.Play();



    }
    private void OnTriggerEnter2D(Collider2D colision)
    {

        if (colision.gameObject.layer == 10)//if they get collectibles their health increases by 2
        {
            collectSound.Play();

            health += 2;
            Debug.Log(health);
            gameManager.GetComponent<GameManagerLvl3>().UpdatePlayerHealth(health);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Fall down death
        if (collision.gameObject.layer == 8)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;

            //SceneManager.LoadScene(currentScene);

            deathSound.Play();
            Destroy(this.gameObject);
            health = 0;
            gameManager.GetComponent<gameManv1>().UpdatePlayerHealth(health);

        }




        //Reach book
        if (collision.gameObject.tag == "Book")
        {

            collision.gameObject.SetActive(false);
            int currentScene = SceneManager.GetActiveScene().buildIndex;

            
            lvlCompleteSound.Play();

            SceneManager.LoadScene(currentScene+1);

            //Switch scenes to end screen
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //do damange if enemy collider check every 1 second
        
        if (isAttacking && collision.gameObject.tag == "Enemy" && canAttack)
        {
            //Debug.Log("Doing Damage");
            StartCoroutine(ExampleCoroutine());
            int damageAmmount = collision.gameObject.GetComponent<EnemyManager>().takeDamageAmmount;
            collision.gameObject.GetComponent<EnemyManager>().doDamage(damageAmmount);


            gameManager.GetComponent<gameManv1>().UpdateEnemyHealth(collision.gameObject.GetComponent<EnemyManager>().enemyHealth);
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

    public void doDamage(int damage)
    {
        losingHealth.Play();
        health -= damage;
        gameManager.GetComponent<gameManv1>().UpdatePlayerHealth(health);
        //Debug.Log("Player Health: " + health.ToString());
    }


}
