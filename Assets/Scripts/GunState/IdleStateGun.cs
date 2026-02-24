using UnityEngine;

public class IdleStateGun : IState
{
    private Guns _gun;

    public IdleStateGun(Guns gun)
    {
        _gun = gun;
    }
    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        _gun.currentRateTime -= Time.deltaTime;

        if(Input.GetMouseButton(0) &&  _gun.currentRateTime <= 0)
        {
            _gun.stateMachine.ChangeState(_gun.fireStateGun);
            _gun.currentRateTime = _gun.gunAsset.maxRateTime;
        }
        _gun.CheckReload();
    }
}
