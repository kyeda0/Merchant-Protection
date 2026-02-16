using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Human
{

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    public override void MovemenLogic()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? maxSpeed : speed;
        var vectorVertical = GetInput("Vertical");
        var vectorHorizontal = GetInput("Horizontal");
        var position = (vectorVertical * Vector2.up) + (vectorHorizontal * Vector2.right);
        var newPos = rigidbody2D.position + position.normalized * currentSpeed * Time.fixedDeltaTime;
        rigidbody2D.MovePosition(newPos);
    }

    public override void RotationLogic()
    {
        
    }

 

    private float GetInput(string vectorName)
    {
        return Input.GetAxis(vectorName);
    }
}
