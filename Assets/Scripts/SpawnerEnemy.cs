using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnerEnemy : MonoBehaviour
{
    public StateMachine stateMachine {get; private set;}
    public StartSpawnEnemyState startSpawnEnemyState {get; private set;}
    public StopSpawnEnemyState stopSpawnEnemyState {get; private set;}


    [SerializeField] private List<Enemy> enemyList = new List<Enemy>();
    [SerializeField] private float rateSpawnEnemy;
    private Vector3[] enemyPosForSpawm = new Vector3[4]{new Vector3(50f,0f,0f),new Vector3(-50f,0f,0f),new Vector3(0f,30f,0f),new Vector3(0f,-30f,0f)};
    private Enemy lastEnemySpawned;

    public int maxEnemySpawn;


    private void Awake()
    {
        stateMachine = new StateMachine();
        startSpawnEnemyState = new StartSpawnEnemyState(this);
        stopSpawnEnemyState = new StopSpawnEnemyState(this);
    }

    private void Start()
    {
        stateMachine.Initialize(startSpawnEnemyState);
    }
    private void Update()
    {
        stateMachine.Update();
    }

    public void StartSpawnEnemy()
    {
        InvokeRepeating(nameof(SpawnEnemy),1f,rateSpawnEnemy);
    }

    public void StopSpawnEnemy()
    {
        CancelInvoke(nameof(SpawnEnemy));
    }
    private void SpawnEnemy()
    {
        if(maxEnemySpawn <=0)
            return;
        var randomEnemyIndex = GetEnemy();
        var randomEnemy = Instantiate(randomEnemyIndex);
        var randomPosEnemy = enemyPosForSpawm[Random.Range(0,enemyPosForSpawm.Length)];
        randomEnemy.transform.position = randomPosEnemy;
        lastEnemySpawned = randomEnemyIndex;
        maxEnemySpawn--;
    }

    public Enemy GetEnemy()
    {
        Enemy enemy;
        do
        {
            enemy = enemyList[Random.Range(0,enemyList.Count)];
        }
        while(enemy == lastEnemySpawned);

        return enemy;
    }


}
