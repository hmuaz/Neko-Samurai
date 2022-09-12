using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public AllClasses e;
    private void Awake()
    {
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();
    }

    // Update is called once per frame
    void Update()
    {
        e.playerAnimator.SetBool("Attacked", e.inputScript.attacked);
        e.playerAnimator.SetBool("UpperAttacked", e.inputScript.upperAttack);


    }

    //public bool AnimatorisPlaying()
    //{
    //    return e.playerAnimator.GetCurrentAnimatorStateInfo(0).length > e.playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;

    //}

    //public bool AnimationisPlaying(string stateName)
    //{
    //    return AnimatorisPlaying() && e.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    //}

    

    
}
