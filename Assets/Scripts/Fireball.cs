using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            collision.gameObject.GetComponent<PlayerManager>().doDamage(damageAmmount);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        
    }
}
