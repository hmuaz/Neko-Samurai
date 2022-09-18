using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void Enter(EnemyStateManager enemy);

    public abstract void Update(EnemyStateManager enemy);

    public abstract void OnTriggerEnter2D(EnemyStateManager enemy, Collider2D collision);

    public abstract void OnTriggerStay2D(EnemyStateManager enemy, Collider2D collision);
}
