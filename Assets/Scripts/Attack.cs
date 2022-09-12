using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public AllClasses e;

    private void Awake()
    {
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();
    }

    private void Update()
    {
        if (e.inputScript.attacked)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    
}
