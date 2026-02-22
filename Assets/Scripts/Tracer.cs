using UnityEngine;

public class Tracer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float lifeTime;


    public void Init(Vector3 startPos , Vector3 endPos)
    {
        lineRenderer.SetPosition(0,startPos);
        lineRenderer.SetPosition(1,endPos);
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = new Color(1,1,0,0);
        Destroy(gameObject,lifeTime);
    }
}
