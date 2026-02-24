using UnityEngine;

public class StartGameState : IState
{
    private GameManager _gameManager;
    public StartGameState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Enter()
    {
        _gameManager.StartState();
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
