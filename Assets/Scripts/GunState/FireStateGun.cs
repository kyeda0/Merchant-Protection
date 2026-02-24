using UnityEngine;

public class FireStateGun : IState
{
    private Guns _gun;

    public FireStateGun(Guns gun)
    {
        _gun = gun;
    }
    public void Enter()
    {
        _gun.AttackGun();
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        if(_gun.isReloading || _gun.currentMagazine <= 0 || _gun.currentRateTime > 0)
            _gun.stateMachine.ChangeState(_gun.idleStateGun);

        _gun.CheckReload();
    }
}
