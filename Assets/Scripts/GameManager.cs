using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private Player playerOriginal;
    [SerializeField] private CameraForPlayer cameraForPlayer;
    private Player playerClone;
    public StateMachine stateMachine{get; private set;}
    public StartGameState startGameState{get; private set;}
    public PlayingGameState playingGameState{get; private set;}
    public PauseGameState pauseGameState{get; private set;}

    private void Awake()
    {
        stateMachine = new StateMachine();   
        startGameState = new StartGameState(this);
        playingGameState = new PlayingGameState(this);
        pauseGameState = new PauseGameState(this);
    }

    private void Start()
    {
        stateMachine.Initialize(startGameState);
    }

    private void Update()
    {
        stateMachine.Update();
    }
    public void StartState()
    {
        playerClone = Instantiate(playerOriginal);
        cameraForPlayer.player = playerClone.transform;
        Instantiate(gun,playerClone.transform.GetChild(0).GetComponent<Transform>().transform);
    }

    public void PlayningState()
    {
        
    }
    
    public void PauseState()
    {
        
    }

}
