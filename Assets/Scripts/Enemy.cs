using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Enemy : Human
{

    [SerializeField] private EnemyData enemyConfig;
    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    private bool isSlowingDown;

    private void Start()
    {
        health = enemyConfig.maxHealth;
        GetComponent<SpriteRenderer>().sprite = enemyConfig.spriteEnemy;
        rigidbody2D = GetComponent<Rigidbody2D>();
        speed = enemyConfig.maxSpeed;
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        if(isSlowingDown == false && health > 0)
            StartCoroutine(SlowingDown());
    }

    public override void Kill()
    {
        Destroy(gameObject);
    }
    private void Update()
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

}
