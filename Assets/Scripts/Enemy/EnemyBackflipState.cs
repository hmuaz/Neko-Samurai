using UnityEngine;

public class EnemyBackflipState : EnemyBaseState
{
    public override void Enter(EnemyStateManager enemy)
    {
        Debug.Log("sa");


        enemy.rb.velocity = enemy.attackVector * Vector2.left *10;


        

        
    }

    public override void Update(EnemyStateManager enemy)
    {

        float distance = Vector2.Distance(enemy.transform.position, enemy.e.playerScript.transform.position);

        Debug.Log(distance);

        if (distance >= 5)
        {
            enemy.rb.velocity = Vector2.zero;
            enemy.StartCoroutine(enemy.WaitBeforeAttack(enemy.waitFloat));
        }
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collision)
    {
        throw new System.NotImplementedException();
    }

    


}
