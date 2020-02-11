using UnityEngine;

public class JellyIdle : EnemyState, IEnemyState
{
    public JellyIdle(Rigidbody2D rb, AudioClip sound, EnemyStateMachine sm, string name) : base(rb, sound ,sm, name)
    {
    }

    public void Enter()
    {
        sm.ChangeAnimation("Idle");
        Debug.Log("Jalea en Idle");
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
