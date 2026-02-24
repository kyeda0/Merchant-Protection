using UnityEngine;

public class PlayingGameState : IState
{
    private GameManager _gameManager;


    public PlayingGameState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void Enter()
    {
        _gameManager.PlayningState();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
