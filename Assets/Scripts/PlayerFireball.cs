using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{
    public int damageAmmount = 10;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Wall")
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else if (collision != null && collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyManager>().doDamage(damageAmmount);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

    }
}
