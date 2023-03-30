using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{
    public int damageAmmount = 5;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Wall")
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else if(collision != null && collision.gameObject.tag == "Player")
        {

            if (SceneManager.GetActiveScene().name == "Lvl1")
                collision.gameObject.GetComponent<PlayerManager>().doDamage(damageAmmount);
            else
                collision.gameObject.GetComponent<PlayerLvl2>().doDamage(damageAmmount);

            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        
    }
}
