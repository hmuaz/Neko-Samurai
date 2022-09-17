using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;

    public int attackDirection = -1;
    public float attackSpeed = 5f;
    public Vector2 attackVector;

    public float waitFloat = 1f;

    public Rigidbody2D rb;


    public EnemyAttackState AttackState = new EnemyAttackState();
    public EnemyDieState DieState = new EnemyDieState();
    public EnemyBackflipState BackFlipState = new EnemyBackflipState();

    public AllClasses e;
    private void Awake()
    {
        e = GameObject.Find("GameManager").GetComponent<AllClasses>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currentState = AttackState;

        currentState.Enter(this);

        attackVector = new Vector2(attackDirection * attackSpeed, 0);

    }

    private void Update()
    {
        Debug.Log(attackVector);

        currentState.Update(this);
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
        Debug.Log("çalýþ lan");
    }
}
