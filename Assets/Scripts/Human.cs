using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Human : MonoBehaviour,IHuman
{
    protected Rigidbody2D rigidbody2D;
    public float health;
    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
    }

    private void FixedUpdate() 
    {
        MovemenLogic();
        RotationLogic();
    }

    public virtual void MovemenLogic()
    {
        
    }


    public virtual void RotationLogic()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
    }

    public virtual void Kill()
    {
    
    }
}
