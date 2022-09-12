using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reach : MonoBehaviour
{

    public AllClasses e;

    private void Awake()
    {
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("lan");

            if (e.inputScript.upperAttack)
            {

                EnemyDie enemyScript = collision.gameObject.GetComponent<EnemyDie>();
                enemyScript.EnemyDies();

            }

            
        }

        
        
    }
}
