using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UISystem : MonoBehaviour
{
    public AllClasses e;

    public GameObject heart1;
    public GameObject heart2;

    public Text scoreText;

    private void Awake()
    {
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();
    }

    private void Update()
    {
        GetCurrentLives();
        SetScore();
    }

    public void GetCurrentLives()
    {
        if(e.playerScript.playerHealth == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
        }
        else if (e.playerScript.playerHealth == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
        }
        else if (e.playerScript.playerHealth == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
        }
    }

    public void SetScore()
    {
        scoreText.text = e.playerScript.scorInt.ToString();
    }



}
