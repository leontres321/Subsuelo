public interface  IEnemyState
{
    void Enter();
    void Execute();
    void FixedExecute();
    void Exit();
    string GetName();
}
