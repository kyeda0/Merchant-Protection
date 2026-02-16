using UnityEngine;

public class CameraForPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float zOffset ;
    private void LateUpdate()
    {
        CameraMovePlayer();
    }

    private void CameraMovePlayer()
    {
        Vector3 targetPos = new Vector3(player.transform.position.x,player.transform.position.y,zOffset);
        transform.position = Vector3.Lerp(transform.position,targetPos,smoothSpeed * Time.deltaTime);
    }
}
