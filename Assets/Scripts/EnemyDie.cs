using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public AllClasses e;
    Enemy enemyScript;
    private void Awake()
    {
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();
        enemyScript = GetComponent<Enemy>();
    }


    public void EnemyDies()
    {
        enemyScript.enemyDead = true;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.isKinematic = false;
        rb.gravityScale = 5;

        Invoke("DestroyEnemy", 1f);
        
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
        e.gameOverScript.GameOverF();
    }
}
