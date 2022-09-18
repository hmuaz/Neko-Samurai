using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemy : MonoBehaviour
{
    public AllClasses e;
    GameObject calledEnemy;
    private void Awake()
    {
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();
        calledEnemy = e.enemyPoolScript.GetEnemy();
        ChangeEnemiesPosition(calledEnemy);
        
    }

    private void Update()
    {


        if (!calledEnemy.activeInHierarchy)
        {
            calledEnemy = e.enemyPoolScript.GetEnemy();
            ChangeEnemiesPosition(calledEnemy);

        }
    }

    public void ChangeEnemiesPosition(GameObject enemy)
    {
        EnemyStateManager enemyState = enemy.GetComponent<EnemyStateManager>();
        int direction = enemyState.attackDirection;
        enemyState.SwitchState(enemyState.AttackState);

        if (direction == 1)
        {
            enemy.transform.position = new Vector3(-14, -5, 0);
        }
        else
        {
            enemy.transform.position = new Vector3(14, -5, 0);
        }
    }
}
