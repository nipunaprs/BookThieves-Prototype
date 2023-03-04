using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rayCastHit = Physics2D.Raycast(rayPoint.transform.position, raypoint.transform.forward);

        if (hit.collider != null)
        {
            //Calc distance
            float distance = Mathf.Abs(rayCastHit);
        }
    }
}
