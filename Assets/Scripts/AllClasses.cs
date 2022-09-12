using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllClasses : MonoBehaviour
{
    public Attack attackScript;
    public Player playerScript;
    public InputD inputScript;
    public Camera cam;
    public Animator playerAnimator;
    public Animations animationsScript;
    public GameOver gameOverScript;
    

    private void Awake()
    {
        attackScript = GameObject.Find("Neko").GetComponent<Attack>();
        playerScript = GameObject.Find("Neko").GetComponent<Player>();
        inputScript = GameObject.Find("GameManager").GetComponent<InputD>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        playerAnimator = GameObject.Find("Neko").GetComponent<Animator>();
        animationsScript = GameObject.Find("GameManager").GetComponent<Animations>();
        gameOverScript = GameObject.Find("Neko").GetComponent<GameOver>();
    }
}
