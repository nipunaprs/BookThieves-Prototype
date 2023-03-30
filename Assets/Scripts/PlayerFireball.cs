using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{
    public int damageAmmount = 15;
    public GameObject gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer == 6);
        if (collision != null && (collision.gameObject.tag == "Wall" || collision.gameObject.layer == 6))
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else if (collision != null && collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyManager>().doDamage(damageAmmount);
            int currentEnemyHealth = collision.gameObject.GetComponent<EnemyManager>().enemyHealth;
            gameManager.GetComponent<GameManagerLvl3>().UpdateEnemyHealth(currentEnemyHealth);
            if(collision.gameObject.name == "DemonBoss")
                gameManager.GetComponent<GameManagerLvl3>().UpdateBossHealth(currentEnemyHealth);

            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

    }

   
}
