using UnityEngine;

public class GameSettingScript : MonoBehaviour 
{
    [SerializeField]
    GameState _gameState;
    
    [SerializeField]
    GameMode _gameMode;
    
    [SerializeField]
    AiMode _aiOneMode;
    
    [SerializeField]
    AiMode _aiTwoMode;

    [SerializeField]
    Orientation _playerOneOrientation;

    [SerializeField]
    FirstPlayer _firstPlayerToPlay;

    [SerializeField]
    int _boardSize;


    public GameState GameState
    {
        get { return _gameState; }
        set { _gameState = value; }
    }

    public GameMode GameMode
    {
        get { return _gameMode; }
        set { _gameMode = value; }
    }

    public AiMode AiTwoMode
    {
        get { return _aiTwoMode; }
        set { _aiTwoMode = value; }
    }

    public AiMode AiOneMode
    {
        get { return _aiOneMode; }
        set { _aiOneMode = value; }
    }


	// Use this for initialization
	void Start () 
    {
        _gameState = GameState.MainMenu;
	}

    public void SetGameState(GameState gameState)
    {
        _gameState = gameState;
    }

    public void SetGameMode(GameMode gameMode)
    {
        _gameMode = gameMode;
    }

    public void SetAiOneMode(AiMode aiMode)
    {
        _aiOneMode = aiMode;
    }

    public void SetAiTwoMode(AiMode aiMode)
    {
        _aiTwoMode = aiMode;
    }

    public Orientation PlayerOneOrientation
    {
        get { return _playerOneOrientation; }
        set { _playerOneOrientation = value; }
    }

    public FirstPlayer FirstPlayerToPlay
    {
        get { return _firstPlayerToPlay; }
        set { _firstPlayerToPlay = value; }
    }

    public int BoardSize
    {
        get { return _boardSize; }
        set { _boardSize = value; }
    }
}
