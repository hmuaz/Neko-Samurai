using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AllClasses e;

    public int playerHealth = 2;
    public int scorInt = 0;
    private void Awake()
    {
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();

    }

    public int direction = 1;


    private void Update()
    {
        transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    



}
