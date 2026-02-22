using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Human : MonoBehaviour,IHuman
{
    protected Rigidbody2D rigidbody2D;
    public float health;
    private  void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
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
        if(health <= 0)
        {
            Kill();
        }
    }

    public virtual void Kill()
    {
    
    }
}
