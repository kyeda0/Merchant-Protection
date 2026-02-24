using UnityEngine;

public class ChaseStateEnemy : IState
{
    private Enemy _enemy;

    public ChaseStateEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Вошел в chase");
    }

    public void Exit()
    {
        Debug.Log("Вышел из chase");
    }

    public void FixedUpdate()
    {
        _enemy.MovemenLogic();
    }

    public void Update()
    {
        _enemy.SearchTarget();
        _enemy.RotationLogic();
        if(_enemy.target == null)
        {
            _enemy.stateMachine.ChangeState(_enemy.idleStateEnemy);
        }
    }
}
