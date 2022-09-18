using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private Queue<GameObject> enemies;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private int poolSize;

    private void Awake()
    {
        enemies = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {

            GameObject obj = Instantiate(enemyPrefab);

            obj.SetActive(false);

            enemies.Enqueue(obj);
        }
    }

    public GameObject GetEnemy()
    {
        GameObject obj = enemies.Dequeue();

        obj.SetActive(true);

        enemies.Enqueue(obj);

        return obj;

    }

}
