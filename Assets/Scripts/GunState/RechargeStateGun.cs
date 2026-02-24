
public class RechargeStateGun : IState
{
    private Guns _gun;


    public RechargeStateGun(Guns gun)
    {
        _gun = gun;
    }
    public void Enter()
    {
        _gun.StartCoroutine(_gun.ReloadTime());
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }
}
