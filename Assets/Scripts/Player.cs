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
        var newPos = rigidbody2D.position + position * currentSpeed * Time.fixedDeltaTime;
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
}
