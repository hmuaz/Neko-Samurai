using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputD : MonoBehaviour
{
    public AllClasses e;

    public bool attacked = false;

    public bool upperAttack = false;
    public bool rightSide = false;
    public bool leftSide = false;
    public bool canAttack = true;

    public bool enemyAndNekoCollision = false;


    public float upperAnimEndTime = 1f;
    public float attackAnimEndTime = 1f;


    public Vector3 mousePosition;
    float playersHead;


    private void Awake()
    {
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();
    }

    private void Update()
    {
        playersHead = e.playerScript.transform.position.y + 1;

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = e.cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if(mousePosition.x > 0)
        {
            rightSide = true;
            leftSide = false;
            e.playerScript.direction = 1;
        }
        else if (mousePosition.x < 0)
        {
            e.playerScript.direction = -1;
            leftSide = true;
            rightSide = false;

        }

        if (canAttack)
        {
            if (mousePosition.y > 0)
            {
                upperAttack = true;
                attacked = false;
            }
            else if (mousePosition.y < 0)
            {
                attacked = true;
                upperAttack = false;
                canAttack = false;
                Invoke("TurnCanAttackTrue", 1f);
            }
        }

        
        


        if (Input.GetMouseButtonUp(0))
        {
            mousePosition = Vector3.zero;
            if (attacked)
            {
                Invoke("TurnAttackedFalse", attackAnimEndTime);
            }
            else if (upperAttack)
            {
                Invoke("TurnUpperAttackedFalse", upperAnimEndTime);

            }
        }

        //if (e.animationsScript.AnimationisPlaying("Attack"))
        //{
        //    attacked = false;
        //}

        //if (e.animationsScript.AnimationisPlaying("UpperAttack"))
        //{
        //    upperAttack = false;
        //}

        //if (e.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        //{
        //    attacked = false;
        //}

        //if (e.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("UpperAttack"))
        //{
        //    upperAttack = false;

        //}




        //if(mousePosition.y > )


    }

    

    

    void TurnAttackedFalse()
    {
        attacked = false;
    }

    void TurnUpperAttackedFalse()
    {
        upperAttack = false;
    }

    void TurnCanAttackTrue()
    {
        canAttack = true;
    }

}
