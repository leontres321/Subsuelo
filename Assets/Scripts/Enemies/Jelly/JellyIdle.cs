using UnityEngine;

public class JellyIdle : EnemyState, IEnemyState
{
    public JellyIdle(Rigidbody2D rb, EnemyStateMachine sm, string name) : base(rb, sm, name)
    {
    }

    public void Enter()
    {
        sm.ChangeAnimation("Idle");
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        
    }

    public void FixedExecute()
    {
        
    }

}
