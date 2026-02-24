using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public  class Guns : MonoBehaviour
{
    public StateMachine stateMachine{ get; private set;}
    public IdleStateGun idleStateGun{get; private set;}
    public FireStateGun fireStateGun{get; private set;}
    public RechargeStateGun rechargeStateGun{get; private set;}

    public GunAsset  gunAsset;
    [SerializeField] private Tracer tracerPrefab;
    [SerializeField] private CameraForPlayer  cameraForPlayer;
    public  int currentMagazine {get; private set;}
    public  float currentRateTime;
    public bool isReloading {get; private set;}

    private event Action onFire;

    private void Awake()
    {
        stateMachine = new StateMachine();
        idleStateGun = new IdleStateGun(this);
        fireStateGun = new FireStateGun(this);
        rechargeStateGun = new RechargeStateGun(this);
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = gunAsset.spriteGun;
        cameraForPlayer = GameObject.FindWithTag("MainCamera").GetComponent<CameraForPlayer>();
        currentMagazine = gunAsset.maxMagazine;
        currentRateTime = gunAsset.maxRateTime;
        stateMachine.Initialize(idleStateGun);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void AttackGun()
    {
        currentMagazine--;
        RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.up,gunAsset.distant);
        Vector3 end;
        if (hit.collider != null)
        {
            end = hit.point;
            Human enemyHealth = hit.collider.GetComponent<Human>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(Random.Range(gunAsset.minDamageGun,gunAsset.maxDamageGun));
            }
        }
        else 
        {
            end = transform.position + transform.up * gunAsset.distant;
        }
        Tracer tracer = Instantiate(tracerPrefab);
        tracer.GetComponent<Tracer>().Init(transform.position,end);
        cameraForPlayer.Shake(0.1f,gunAsset.shakePower);
    }   

    public void CheckReload()
    {
        if(isReloading == false && (currentMagazine <= 0 || Input.GetKeyDown(KeyCode.R)))
        {
            stateMachine.ChangeState(rechargeStateGun);
        }
    }


    public IEnumerator ReloadTime()
    {
        isReloading = true;
        Debug.Log("Перезаряжаюсь");
        yield return new WaitForSeconds(gunAsset.rechargeTime);
        currentMagazine = gunAsset.maxMagazine;
        isReloading = false;
        stateMachine.ChangeState(idleStateGun);
    }
}
