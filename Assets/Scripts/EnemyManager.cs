using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyHealth = 40;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doDamage(int damage)
    {
        
        enemyHealth -= damage;
        Debug.Log(enemyHealth);
    }
}
