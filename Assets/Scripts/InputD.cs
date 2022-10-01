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
    public bool doubleDownAttack = false;

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



        //if (Input.touchCount == 1)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    mousePosition = e.cam.ScreenToWorldPoint(touch.position);

        //    Invoke("AfterAttack", 0.1f);
        //}

        //if (Input.touchCount == 2)
        //{
        //    Touch touch1 = Input.touches[0];
        //    Touch touch2 = Input.touches[1];

        //    Vector3 touch1Position = e.cam.ScreenToWorldPoint(touch1.position);
        //    Vector3 touch2Position = e.cam.ScreenToWorldPoint(touch2.position);

        //    Debug.Log(touch1Position);
        //    Debug.Log(touch2Position);



        //    if (touch1Position.x > 0 && touch2Position.x < 0 && touch1Position.y < 0 && touch2Position.y < 0 || touch1Position.x < 0 && touch2Position.x > 0 && touch1Position.y < 0 && touch2Position.y < 0)
        //    {
        //        if (!doubleDownAttack && !attacked)
        //        {
        //            doubleDownAttack = true;

        //            Invoke("TurnDoubleDownAttackFalse", 0.5f);
        //            Debug.Log("doubluýkilll");
        //        }

        //    }
        //}


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!doubleDownAttack && !attacked)
            {
                doubleDownAttack = true;

                Invoke("TurnDoubleDownAttackFalse", 0.5f);
                Debug.Log("doubluýkilll");
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = e.cam.ScreenToWorldPoint(Input.mousePosition);

            Invoke("AfterAttack", 0.1f);

        }

        if (!doubleDownAttack)
        {
            if (mousePosition.x > 0)
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
        }

        

        
        


        //if (Input.GetMouseButtonUp(0))
        //{
            
        //}

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

    

    void TurnDoubleDownAttackFalse()
    {
        doubleDownAttack = false;
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

    void AfterAttack()
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

}
