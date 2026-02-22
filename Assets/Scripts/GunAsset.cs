using UnityEngine;

[CreateAssetMenu(fileName = "GunAsset", menuName = "Scriptable Objects/GunAsset")]
public class GunAsset : ScriptableObject
{   
    public Sprite spriteGun;
    public float damageGun;
    public float maxRateTime;
    public int maxMagazine;
    public float distant;
    public float rechargeTime;
    public float shakePower;

}
