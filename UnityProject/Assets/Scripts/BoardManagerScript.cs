using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManagerScript : MonoBehaviour 
{
    [SerializeField]
    GameSettingScript _gameSettingScript;

    [SerializeField]
    UIPauseScript _uiPauseScript;

    [SerializeField]
    Camera _mainCamera;

    [SerializeField]
    GameObject _boardRoot;

    [SerializeField]
    GameObject _emptySquare;

    [SerializeField]
    Material _emptyMaterial;
    [SerializeField]
    Material _horizontalMaterial;
    [SerializeField]
    Material _verticalMaterial;

    [SerializeField]
    int _layerEmpty;
    [SerializeField]
    int _layerHorizontal;
    [SerializeField]
    int _layerVertical;

    List<Square> _squares;

    int _nbSquareToogle = 0;

    bool _horizontalPlayerTurn;

    bool _isGamePaused = false;

    public bool IsGamePaused
    {
        get { return _isGamePaused; }
        set { _isGamePaused = value; }
    }

	// Use this for initialization
	void Start () 
    {
        if (_gameSettingScript.PlayerOneOrientation == Orientation.Vertical)
            _horizontalPlayerTurn = false;
        else
            _horizontalPlayerTurn = true;

        CreateBoard();
	}

    void Awake()
    {
       
    }
	
	// Update is called once per frame
	void Update () 
    {
        switch (_gameSettingScript.GameMode)
        {
            case GameMode.PlayerVersusAi:
                OnePlayer();
                break;

            case GameMode.PlayerVersurPlayer:
                TwoPlayers();
                break;

            case GameMode.AiVersusAi:
                AiVersusAi();
                break;

            default:
                break;
        }

        CheckInput();
	}

    void CreateBoard()
    {
        _squares = new List<Square>();

        GameObject gameObject;
        Vector3 position = Vector3.zero;
        Quaternion rotation = Quaternion.identity;

        for (int i = 0; i < _gameSettingScript.BoardSize; ++i)
        {
            for (int j = 0; j < _gameSettingScript.BoardSize; ++j)
            {
                position.Set(j, 0.0f, i);
                
                gameObject = Instantiate(_emptySquare, position, rotation) as GameObject;
                gameObject.name = ((i * _gameSettingScript.BoardSize) + j).ToString();

                gameObject.transform.parent = _boardRoot.transform;

                _squares.Add(new Square(gameObject));
            }
        }

        gameObject = _squares[(_gameSettingScript.BoardSize * _gameSettingScript.BoardSize) - 1].SquareGameObject;

        _mainCamera.transform.position = new Vector3(gameObject.transform.position.x / 2, 100.0f, gameObject.transform.position.z / 2);
        _mainCamera.orthographicSize = (_gameSettingScript.BoardSize / 2) + 1;

        _boardRoot.SetActive(false);
    }

    void DestroyBoard()
    {

    }

    void PlayerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, 1 << _layerEmpty))
            {
                GameObject gameObjectHit = hit.collider.gameObject;

                SetEmptySquare(gameObjectHit);

                ++_nbSquareToogle;

                if(_nbSquareToogle >= 2)
                {
                    _nbSquareToogle = 0;
                    _horizontalPlayerTurn = !_horizontalPlayerTurn;
                }
            }
        }
    }

    void SetEmptySquare(GameObject gameObjectHit)
    {
        if (_horizontalPlayerTurn)
        {
            gameObjectHit.GetComponent<Renderer>().material = _horizontalMaterial;
            gameObjectHit.layer = _layerHorizontal;
        }
        else
        {
            gameObjectHit.GetComponent<Renderer>().material = _verticalMaterial;
            gameObjectHit.layer = _layerVertical;
        }
    }

    void OnePlayer()
    {
        PlayerMove();
    }

    void TwoPlayers()
    {
        PlayerMove();
        PlayerMove();
    }

    void AiVersusAi()
    {

    }

    public void BeginGame()
    {
        _boardRoot.SetActive(true);
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameSettingScript.GameState == GameState.Game || _gameSettingScript.GameState == GameState.Pause)
            {
                _boardRoot.SetActive(_isGamePaused);

                _isGamePaused = !_isGamePaused;
                
                _uiPauseScript.SetPause(_isGamePaused);
            }
        }
    }

    public void PauseGame()
    {
        _boardRoot.SetActive(_isGamePaused);
        _isGamePaused = !_isGamePaused;
        _uiPauseScript.SetPause(_isGamePaused);
    }

    public void ResetGame()
    {
        foreach(Square square in _squares)
        {
            if(square.SquareGameObject.layer != _layerEmpty)
            {
                square.SquareGameObject.layer = _layerEmpty;
                square.SquareGameObject.GetComponent<Renderer>().material = _emptyMaterial;
            }
        }
    }
}
