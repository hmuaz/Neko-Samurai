using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{

    public override void Enter(EnemyStateManager enemy)
    {


       


    }

    public override void Update(EnemyStateManager enemy)
    {
        Debug.Log("lan");


        enemy.rb.velocity = enemy.attackVector;
    }

    

    public override void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (enemy.e.playerScript.playerHealth > 1)
            {
                enemy.SwitchState(enemy.BackFlipState);
                enemy.e.playerScript.playerHealth--;
            }
            else if (enemy.e.playerScript.playerHealth <= 1)
            {
                enemy.e.gameOverScript.GameOverF();
            }
        }

        

        
    }

    public override void OnTriggerStay2D(EnemyStateManager enemy, Collider2D collision)
    {
        if (collision.gameObject.tag == "ReachDown" && enemy.e.inputScript.attacked)
        {
            Debug.Log("girdi");
            if (enemy.attackDirection == -1 && enemy.e.inputScript.rightSide)
            {

                //enemy.e.gameOverScript.GameOverF();
                enemy.SwitchState(enemy.DieState);
            }
            else if (enemy.attackVector.x == 1 && enemy.e.inputScript.leftSide)
            {
                //enemy.e.gameOverScript.GameOverF();
                enemy.SwitchState(enemy.DieState);

            }
        }
    }
}
