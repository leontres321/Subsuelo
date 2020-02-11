using UnityEngine;

public class EnemyState 
{
    string name;

    protected EnemyStateMachine sm;
    protected AudioClip sonido;
    protected Rigidbody2D rb;

    public EnemyState(Rigidbody2D rb, AudioClip sonido, EnemyStateMachine sm, string name)
    {
        this.rb = rb;
        this.sm = sm;
        this.name = name;
        this.sonido = sonido;
    }

    public string GetName()
    {
        return name;
    }
  
}
