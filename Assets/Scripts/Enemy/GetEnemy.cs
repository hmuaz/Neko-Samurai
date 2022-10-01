using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemy : MonoBehaviour
{
    public AllClasses e;
    GameObject calledEnemy;

    List<GameObject> activeEnemies = new List<GameObject>();
    private void Awake()
    {
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();
        calledEnemy = e.enemyPoolScript.GetEnemy();
        ChangeEnemiesPosition(calledEnemy);
        
    }

    private void Update()
    {
        if(activeEnemies.Count != 0)
        {
            if (!activeEnemies[0].activeInHierarchy && !activeEnemies[1].activeInHierarchy)
            {
                activeEnemies.RemoveRange(0, 2);
            }
        }
        

        if (!calledEnemy.activeInHierarchy && activeEnemies.Count == 0)
        {
            System.Random rand = new System.Random();

            if (rand.Next(0, 4) == 0)
            {
                Debug.Log("mevzuya girdik");

                GameObject enemy1 = e.enemyPoolScript.GetEnemy();
                GameObject enemy2 = e.enemyPoolScript.GetEnemy();

                enemy1.GetComponent<EnemyStateManager>().attackDirection = 1;
                enemy2.GetComponent<EnemyStateManager>().attackDirection = -1;


                activeEnemies.Add(enemy1);
                activeEnemies.Add(enemy2);

                ChangeEnemiesPosition(enemy1);
                ChangeEnemiesPosition(enemy2);
            }
            else
            {
                calledEnemy = e.enemyPoolScript.GetEnemy();
                EnemyStateManager enemyState = calledEnemy.GetComponent<EnemyStateManager>();
                if (rand.Next(0, 2) == 0)
                {
                    enemyState.attackDirection = 1;
                }
                else
                {
                    enemyState.attackDirection = -1;
                }
                ChangeEnemiesPosition(calledEnemy);
            }
            

        }
    }

    public void ChangeEnemiesPosition(GameObject enemy)
    {
        EnemyStateManager enemyState = enemy.GetComponent<EnemyStateManager>();

        System.Random rand = new System.Random();
        

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
