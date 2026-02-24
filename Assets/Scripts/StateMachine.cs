using UnityEngine;

public class StateMachine
{
    private IState currentState;

    public void Initialize(IState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(IState changeCurrentState)
    {
        currentState.Exit();
        currentState = changeCurrentState;
        currentState.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }

    public void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }
}
