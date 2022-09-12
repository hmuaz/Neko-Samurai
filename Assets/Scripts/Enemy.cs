using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator enemyAnimator;
    public bool enemyDead = false;
    EnemyDie enemyScript;
    Rigidbody2D rb;


    public AllClasses e;
    private void Awake()
    {
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();
        enemyAnimator = GetComponent<Animator>();
        enemyScript = GetComponent<EnemyDie>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        enemyAnimator.SetBool("EnemyDead", enemyDead);
        Debug.Log(e.inputScript.attacked);
        Debug.Log(e.inputScript.upperAttack);

        rb.velocity = new Vector2(-5, 0);

    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ReachUp")
        {
            Debug.Log("bas");
            if (e.inputScript.upperAttack)
            {
                Debug.Log("lan");

                enemyScript.EnemyDies();
            }
        }
        else if (collision.gameObject.tag == "ReachDown")
        {
            if (e.inputScript.attacked)
            {
                Debug.Log("lan");

                enemyScript.EnemyDies();
            }
        }
    }

}
