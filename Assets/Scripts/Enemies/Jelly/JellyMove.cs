using UnityEngine;

public class JellyMove : EnemyState, IEnemyState
{
    readonly float _Velocidad = 10.0f; 
    int _direccion;

    public JellyMove(Rigidbody2D rb, EnemyStateMachine sm, string name) : base(rb, sm, name) { }

    public void Enter()
    {
        _direccion = 1;
    }

    public void Execute()
    {
        _direccion = sm.facingRight ? -1 : 1; //Pesima solucion ya que esta invertido esto
        rb.AddForce(_direccion * _Velocidad * Vector2.right);
    }

    public void Exit()
    {
    }

    public void FixedExecute()
    {
        Debug.Log("fixed");
    }
}
