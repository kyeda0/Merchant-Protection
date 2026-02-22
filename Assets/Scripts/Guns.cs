using System.Collections;
using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public  class Guns : MonoBehaviour
{
    [SerializeField] private GunAsset  gunAsset;
    [SerializeField] private Tracer tracerPrefab;
    [SerializeField] private CameraForPlayer  cameraForPlayer;
    private  int currentMagazine;
    private float currentRateTime;
    private bool isReloading;
    
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = gunAsset.spriteGun;
        cameraForPlayer = GameObject.FindWithTag("MainCamera").GetComponent<CameraForPlayer>();
        currentMagazine = gunAsset.maxMagazine;
        currentRateTime = gunAsset.maxRateTime;
    }

    private void Update()
    {
        currentRateTime -= Time.deltaTime;

        if(Input.GetMouseButton(0) && currentRateTime <= 0)
        {
            AttackGun();
            currentRateTime = gunAsset.maxRateTime;
        }

        if(currentMagazine <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadTime());
        }
    }

    private void AttackGun()
    {
        if(isReloading)
            return;
        if (currentMagazine <= 0)  
            return;

        currentMagazine--;
        RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.up,gunAsset.distant);
        Vector3 start = transform.position;
        Vector3 end;
        if (hit.collider != null)
        {
            end = hit.point;
            Human enemyHealth = hit.collider.GetComponent<Human>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(gunAsset.damageGun);
            }
        }
        else 
        {
            end = transform.position + transform.up * gunAsset.distant;
        }

        Instantiate(tracerPrefab).GetComponent<Tracer>().Init(start,end);
        cameraForPlayer.Shake(0.1f,gunAsset.shakePower);
    }   


    private IEnumerator ReloadTime()
    {
        isReloading = true;
        Debug.Log("Перезарежаюсь");
        yield return new WaitForSeconds(gunAsset.rechargeTime);
        currentMagazine = gunAsset.maxMagazine;
        isReloading = false;

    }
}
