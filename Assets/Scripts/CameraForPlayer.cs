using System.Collections;
using UnityEngine;

public class CameraForPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float zOffset ;
    [SerializeField] private float MaxOffset;
    [SerializeField] private float shakePower;
    [SerializeField] private float shakeDuraion;
    private Vector3 shakeOffset;
    private void LateUpdate()
    {
        CameraMovePlayer();
        CameraShake();
    }

    public void Shake(float duration , float power)
    {
        shakePower = power;
        shakeDuraion = duration;
    }

    private void CameraMovePlayer()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 direction = (mousePos - player.position).normalized;

        Vector3 offset = direction * Mathf.Min(Vector2.Distance(player.transform.position,mousePos),MaxOffset);
        Vector3 targetPos = player.position + offset;
        targetPos.z = zOffset;
        transform.position = Vector3.Lerp(transform.position,targetPos, smoothSpeed * Time.deltaTime);
    }

    private void CameraShake()
    {
        if(shakeDuraion > 0)
        {
            shakeDuraion -= Time.deltaTime;
            shakeOffset = Random.insideUnitCircle * shakePower;
            transform.position += shakeOffset;
        }
    }

}
