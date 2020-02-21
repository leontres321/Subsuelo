using UnityEngine;

public class JellyHurt : EnemyState, IEnemyState
{
    public JellyHurt(Rigidbody2D rb, EnemyStateMachine sm, string name) : base(rb, sm, name)
    {
    }

    public void Enter()
    {
        sm.ChangeAnimation("Hurt");
        sm.MakeSound("Hurt");
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
