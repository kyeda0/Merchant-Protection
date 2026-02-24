using UnityEngine;

public class StartSpawnEnemyState : IState
{
    private SpawnerEnemy _spawnerEnemy;

    public StartSpawnEnemyState(SpawnerEnemy spawnerEnemy)
    {
        _spawnerEnemy = spawnerEnemy;
    }
    public void Enter()
    {
        Debug.Log("Начал спавнить врагов");
        _spawnerEnemy.StartSpawnEnemy();
    }

    public void Exit()
    {

    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        if(_spawnerEnemy.maxEnemySpawn <= 0)
        {
            _spawnerEnemy.stateMachine.ChangeState(_spawnerEnemy.stopSpawnEnemyState);
            Debug.Log("Закончились враги");
        }
    }
}
