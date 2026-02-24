using UnityEngine;

public class DeadStateEnemy : IState
{

    private Enemy _enemy;

    public DeadStateEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Умер");
        _enemy.Kill();
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }
}
