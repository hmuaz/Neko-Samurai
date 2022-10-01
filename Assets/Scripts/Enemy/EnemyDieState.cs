using UnityEngine;

public class EnemyDieState : EnemyBaseState
{
    
    public override void Enter(EnemyStateManager enemy)
    {

        enemy.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        enemy.rb.isKinematic = false;

        enemy.enemyDied = true;

        enemy.Invoke("DestroyEnemy", 1f);


    }

    public override void Update(EnemyStateManager enemy)
    {

    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collision)
    {

    }

    public override void OnTriggerStay2D(EnemyStateManager enemy, Collider2D collision)
    {

    }


}
