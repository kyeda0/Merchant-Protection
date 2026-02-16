using UnityEngine;

[CreateAssetMenu(fileName = "GunScriptObject", menuName = "Scriptable Objects/GunScriptObject")]
public class GunScriptObject : ScriptableObject
{
    [SerializeField] private Guns guns;
}
