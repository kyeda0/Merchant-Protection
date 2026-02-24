using UnityEngine;

public class StopSpawnEnemyState : IState
{
    private SpawnerEnemy _spawnerEnemy;

    public StopSpawnEnemyState(SpawnerEnemy spawnerEnemy)
    {
        _spawnerEnemy = spawnerEnemy;
    }
    public void Enter()
    {
        _spawnerEnemy.StopSpawnEnemy();
        Debug.Log("Остановил спавн");
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
