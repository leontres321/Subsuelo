using UnityEngine;

public class EnemyState 
{
    string name;

    protected EnemyStateMachine sm;
    protected Rigidbody2D rb;

    public EnemyState(Rigidbody2D rb, EnemyStateMachine sm, string name)
    {
        this.rb = rb;
        this.sm = sm;
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
  
}
