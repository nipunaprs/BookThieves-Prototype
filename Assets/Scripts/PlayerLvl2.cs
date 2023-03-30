using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLvl2 : MonoBehaviour
{
    public Animator animator;
    public int health = 100;

    bool isAttacking;
    bool canAttack = true;

    //Second attack code
    bool isPunching;
    bool canPunch = true;
    public Transform spawnPoint;
    public GameObject fireball;
    public float fireSpeed = 10f;
    public float attackDelayTime = 2f;

    public GameObject gameManager;

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

        if(Input.GetKeyDown(KeyCode.X) && canPunch) { 
            HandlePunch();
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            isPunching = false;
            animator.SetBool("punch", false);
        }
    }


    void HandleAttack()
    {
        //Turn off other animations
        animator.SetBool("punch", false);
        isPunching = false;

        //play animation
        animator.SetBool("attack", true);
        isAttacking = true;


    }


    void HandlePunch()
    {

        //play animation
        animator.SetBool("punch", true);
        isPunching = true;

        //Turn off other animations
        animator.SetBool("attack", false);
        isAttacking = false;

        

        //Spawn the instance
        //Start shooting
        GameObject fireballP = (GameObject)Instantiate(fireball, spawnPoint.transform.position, fireball.transform.rotation);
        Rigidbody2D fireballrb = fireballP.GetComponent<Rigidbody2D>();
        if (!isFacingRight())
        {
            fireballrb.velocity = new Vector2(-fireSpeed, 0f);
        }
        else
        {
            fireballrb.velocity = new Vector2(fireSpeed, 0f);
        }


        canPunch = false;
        Invoke("ResetAttack", attackDelayTime);
    }


    void ResetAttack()
    {
        canPunch = true;
    }

    private bool isFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Fall down death
        if (collision.gameObject.layer == 8)
        {
            health = 0;
            gameManager.GetComponent<GameManagerLvl3>().UpdatePlayerHealth(health);
            Destroy(this.gameObject);
        }




        //Reach book
        if (collision.gameObject.tag == "Book")
        {

            collision.gameObject.SetActive(false);
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);

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

            if(collision.gameObject.name == "DemonBoss")
            {
                //update the boss health
                int boss_health = collision.gameObject.GetComponent<EnemyManager>().enemyHealth;
                gameManager.GetComponent<GameManagerLvl3>().UpdateBossHealth(boss_health);
                gameManager.GetComponent<GameManagerLvl3>().UpdateEnemyHealth(boss_health);
            }
            else
            {
                gameManager.GetComponent<GameManagerLvl3>().UpdateEnemyHealth(collision.gameObject.GetComponent<EnemyManager>().enemyHealth);
            }

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
        health -= damage;
        gameManager.GetComponent<GameManagerLvl3>().UpdatePlayerHealth(health);
        //Debug.Log("Player Health: " + health.ToString());
    }

}
