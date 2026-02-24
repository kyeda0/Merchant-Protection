using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Enemy : Human
{
    public StateMachine stateMachine {get; private set;}
    public  IdleStateEnemy idleStateEnemy {get; private set;}
    public ChaseStateEnemy chaseStateEnemy {get; private set;}
    public DeadStateEnemy deadStateEnemy {get; private set;}
    public AttackEnemyState attackEnemyState{get; private set;}
    public Transform target{get; private set;}
    
    private bool isSlowingDown;
    private event Action<int> OnDead;
    [SerializeField] private EnemyData enemyConfig;
    [SerializeField] private float speed;

    private void Awake()
    {
        stateMachine = new StateMachine();
        idleStateEnemy = new IdleStateEnemy(this);
        chaseStateEnemy = new ChaseStateEnemy(this);
        deadStateEnemy = new DeadStateEnemy(this);
        attackEnemyState = new AttackEnemyState(this);
    }
    protected override void Start()
    {
        health = enemyConfig.maxHealth;
        GetComponent<SpriteRenderer>().sprite = enemyConfig.spriteEnemy;
        speed = enemyConfig.maxSpeed;
        base.Start();
        stateMachine.Initialize(idleStateEnemy);
    }

    private void Update()
    {
        stateMachine.Update();
    }
    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }
    public void SearchTarget()
    {
        if (target == null)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position,
                                                 enemyConfig.rangeVision,
                                                 enemyConfig.layerMask);

            if (hit != null)
            {
                target = hit.transform;
            }  
        }

        else
        {
            float distance = Vector2.Distance(transform.position, target.position);
                
            if (distance > enemyConfig.rangeVision)
                target = null;
        }
    }
    public override void MovemenLogic()
    {
        if(target == null)
         return;
        
        Vector2 direction = (target.position - transform.position).normalized;
        Vector2 newPosition = rigidbody2D.position + direction * speed * Time.fixedDeltaTime;

        rigidbody2D.MovePosition(newPosition);
    }


    public override void RotationLogic()
    {
        if(target == null)
            return;
        
        Vector2 direction = target.position - transform.position;
        var targetRotation = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg - 90f;
        rigidbody2D.rotation = targetRotation;
    }

    private IEnumerator SlowingDown()
    {
        speed =  enemyConfig.minSpeed;
        isSlowingDown = true;
        yield return new WaitForSeconds(0.5f);
        speed = enemyConfig.maxSpeed;
        isSlowingDown = false;
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        if(isSlowingDown == false && health > 0)
            StartCoroutine(SlowingDown());

        if(health <= 0 )
        {
            stateMachine.ChangeState(deadStateEnemy);
        }
    }

    public override void Kill()
    {
        OnDead?.Invoke(enemyConfig.rewardForPlayer);
        Destroy(gameObject);
    }

}
