using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private Transform gunPos;
    private void Start()
    {
        Instantiate(gun,gunPos);
    }

}
