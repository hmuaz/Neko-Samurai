using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public EnemyBaseState currentState;

    public int attackDirection;
    public float attackSpeed = 5f;
    public Vector2 attackVector;
    public Animator enemyAnimator;

    public bool enemyDied;


    public float waitFloat = 1f;

    public Rigidbody2D rb;


    public EnemyAttackState AttackState = new EnemyAttackState();
    public EnemyDieState DieState = new EnemyDieState();
    public EnemyBackflipState BackFlipState = new EnemyBackflipState();

    public AllClasses e;

    Enemy enemyScript;

    private void Awake()
    {

        //System.Random rand = new System.Random();
        //if (rand.Next(0, 2) == 0)
        //{
        //    attackDirection = 1;
        //}
        //else
        //{
        //    attackDirection = -1;
        //}

        enemyAnimator = GetComponent<Animator>();
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();
        rb = GetComponent<Rigidbody2D>();
        enemyScript = GetComponent<Enemy>();
    }

    private void Start()
    {
        currentState = AttackState;

        currentState.Enter(this);


    }

    private void Update()
    {
        attackVector = new Vector2(attackDirection * attackSpeed, 0);

        enemyAnimator.SetBool("EnemyDead", enemyDied);


        currentState.Update(this);


        transform.localScale = new Vector3(attackDirection * -1, transform.localScale.y, transform.localScale.z);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.Enter(this);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter2D(this, collision);
    }

    public IEnumerator WaitBeforeAttack(float waitFloat)
    {
        yield return new WaitForSeconds(waitFloat);
        SwitchState(AttackState);
    }

    public void DestroyEnemy()
    {
        gameObject.active = false;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.isKinematic = true;
        enemyDied = false;
    }



    public void OnTriggerStay2D(Collider2D collision)
    {
        currentState.OnTriggerStay2D(this, collision);
    }

    

    
}
