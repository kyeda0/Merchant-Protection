using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Human
{

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private int coins;
    private float vectorVertical;
    private float vectorHorizontal;

    protected override void Start()
    {
        health = maxHealth;
        base.Start();
    }

    private void Update()
    {
        vectorVertical = GetInput("Vertical");
        vectorHorizontal = GetInput("Horizontal");
    }
    public override void MovemenLogic()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? maxSpeed : speed;
        var position = (vectorVertical * Vector2.up) + (vectorHorizontal * Vector2.right);
        var newPos = rigidbody2D.position + position.normalized * currentSpeed * Time.fixedDeltaTime;
        rigidbody2D.MovePosition(newPos);
    }

    public override void RotationLogic()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var diretion = mousePos - rigidbody2D.position;
        var targetRotation = Mathf.Atan2(diretion.y,diretion.x) * Mathf.Rad2Deg - 90f;
        rigidbody2D.rotation = targetRotation;
    }

 

    private float GetInput(string vectorName)
    {
        return Input.GetAxis(vectorName);
    }

    public void ChangeCoins(int rewardForPlayer)
    {
        coins += rewardForPlayer;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }
}
