using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManagerScript : MonoBehaviour 
{
    [SerializeField]
    GameSettingScript _gameSettingScript;

    [SerializeField]
    UIGameScript _uiGameScript;

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

    bool _horizontalPlayerTurn;

    bool _isGamePaused;

    string _playerOneName;

    string _playerTwoName;


    public bool IsGamePaused
    {
        get { return _isGamePaused; }
        set { _isGamePaused = value; }
    }

    public string PlayerOneName
    {
        get { return _playerOneName; }
        set { _playerOneName = value; }
    }

    public string PlayerTwoName
    {
        get { return _playerTwoName; }
        set { _playerTwoName = value; }
    }

	// Update is called once per frame
	void Update () 
    {
        if (_gameSettingScript.GameState == GameState.Game)
        {
            GameLoop();
            CheckInput();
        }
	}

    void GameLoop()
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
    }

    public void CreateBoard()
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
        _uiGameScript.UiRoot.SetActive(true);
    }

    public void DestroyBoard()
    {
        if (_squares != null)
        {
            foreach (Square square in _squares)
                Destroy(square.SquareGameObject);
            _squares = null;
        }
    }

    public void LaunchGame()
    {
        _gameSettingScript.GameState = GameState.Game;

        DestroyBoard();
        CreateBoard();

        _isGamePaused = false;

        if (_gameSettingScript.PlayerOneOrientation == Orientation.Vertical)
        {
            _horizontalPlayerTurn = false;
            _uiGameScript.Horizontal.SetActive(false);
            _uiGameScript.Vertical.SetActive(true);
        }
        else
        {
            _horizontalPlayerTurn = true;
            _uiGameScript.Horizontal.SetActive(true);
            _uiGameScript.Vertical.SetActive(false);
        }

        _uiGameScript.SetPlayerText(_playerOneName);

        _boardRoot.SetActive(true);
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

                int indexSquare;
                Square nextSquare;
                if(int.TryParse(gameObjectHit.name, out indexSquare))
                {
                    int posY = indexSquare % _gameSettingScript.BoardSize;
                    int posX = indexSquare / _gameSettingScript.BoardSize;

                    if (_horizontalPlayerTurn)
                    {
                        if (posY < _gameSettingScript.BoardSize - 1)
                        {
                            nextSquare = _squares[(posX * _gameSettingScript.BoardSize) + posY + 1];

                            if (nextSquare.SquareGameObject.layer == _layerEmpty)
                            {
                                nextSquare.SquareGameObject.GetComponent<Renderer>().material = _horizontalMaterial;
                                nextSquare.SquareGameObject.layer = _layerHorizontal;

                                _horizontalPlayerTurn = !_horizontalPlayerTurn;

                                if (_uiGameScript.PlayerTurnText.text == _playerOneName)
                                    _uiGameScript.SetPlayerText(_playerTwoName);
                                else
                                    _uiGameScript.SetPlayerText(_playerOneName);

                                _uiGameScript.SwitchPlayerOrientation();
                            }
                            else
                            {
                                gameObjectHit.GetComponent<Renderer>().material = _emptyMaterial;
                                gameObjectHit.layer = _layerEmpty;
                            }
                        }
                        else
                        {
                            gameObjectHit.GetComponent<Renderer>().material = _emptyMaterial;
                            gameObjectHit.layer = _layerEmpty;
                        }
                    }
                    else
                    {
                        if(posX < _gameSettingScript.BoardSize - 1)
                        {
                            nextSquare = _squares[((posX + 1) * _gameSettingScript.BoardSize) + posY];

                            if (nextSquare.SquareGameObject.layer == _layerEmpty)
                            {
                                nextSquare.SquareGameObject.GetComponent<Renderer>().material = _verticalMaterial;
                                nextSquare.SquareGameObject.layer = _layerVertical;

                                _horizontalPlayerTurn = !_horizontalPlayerTurn;

                                if (_uiGameScript.PlayerTurnText.text == _playerOneName)
                                    _uiGameScript.SetPlayerText(_playerTwoName);
                                else
                                    _uiGameScript.SetPlayerText(_playerOneName);

                                _uiGameScript.SwitchPlayerOrientation();
                            }
                            else
                            {
                                gameObjectHit.GetComponent<Renderer>().material = _emptyMaterial;
                                gameObjectHit.layer = _layerEmpty;
                            }
                        }
                        else
                        {
                            gameObjectHit.GetComponent<Renderer>().material = _emptyMaterial;
                            gameObjectHit.layer = _layerEmpty;
                        }
                    }
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

        if (_isGamePaused)
            _gameSettingScript.GameState = GameState.Pause;
        else
            _gameSettingScript.GameState = GameState.Game;
    }

    public void ResetBoard()
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

    public void ResetGameSettings()
    {
        _uiGameScript.SetPlayerText(_playerOneName);

        if (_gameSettingScript.PlayerOneOrientation == Orientation.Vertical)
        {
            _horizontalPlayerTurn = false;
            _uiGameScript.Horizontal.SetActive(false);
            _uiGameScript.Vertical.SetActive(true);
        }
        else
        {
            _horizontalPlayerTurn = true;
            _uiGameScript.Horizontal.SetActive(true);
            _uiGameScript.Vertical.SetActive(false);
        }
    }
}
