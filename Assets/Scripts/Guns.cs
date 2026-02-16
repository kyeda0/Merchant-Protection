using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public  class Guns : MonoBehaviour
{
    [SerializeField] private float rechargeTime;
    [SerializeField] private Sprite spriteGun;
    [SerializeField] private float damageGun;
   [SerializeField] private float rateTime;
    [SerializeField] private float maxRateTime;
    [SerializeField] private int maxMagazine;
    private int currentMagazine;
    
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spriteGun;
        currentMagazine = maxMagazine;
        rateTime = maxRateTime;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(test());
        }
    
    }

    private void Reloaded()
    {
        
    }
    private void AttackGun()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.forward);
        currentMagazine -= 1;
        Debug.Log(currentMagazine);
        if (hit && currentMagazine > 0)
        {
            Human enemyHealth = hit.collider.gameObject.GetComponent<Human>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageGun);
            }
        }
        else if (currentMagazine <= 0)
        {
            Reloaded();
        }
    }

    private IEnumerator test()
    {
        bool isClick = true;
        while(isClick)
        {
            if(rateTime <= 0)
            {
                AttackGun();
                isClick = false;
                rateTime = maxRateTime;
            }
            else
            {
                rateTime -= Time.deltaTime;
            }
        }
        yield return null;
    }
}
