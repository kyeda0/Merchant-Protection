using UnityEngine;

public class IdleStateEnemy : IState
{
    private Enemy _enemy;


    public  IdleStateEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Вошел в idle");
    }

    public void Exit()
    {
        Debug.Log("Вышел из idle");
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        _enemy.SearchTarget();
        if(_enemy.target != null)
        {
            _enemy.stateMachine.ChangeState(_enemy.chaseStateEnemy);
        }
    }
}
