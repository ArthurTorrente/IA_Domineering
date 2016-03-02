using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour 
{
    [SerializeField]
    int _boardWidth;

    [SerializeField]
    Camera _mainCamera;

    [SerializeField]
    GameObject _emptySquare;

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

    bool _horizontalPlayerTurn = true;

    int _nbSquareToogle = 0;

    List<Square> _squares;

	// Use this for initialization
	void Start () 
    {
        CreateBoard();
	}
	
	// Update is called once per frame
	void Update () 
    {
        PlayerMove();
	}

    void CreateBoard()
    {
        _squares = new List<Square>();

        GameObject gameObject;
        Vector3 position = Vector3.zero;
        Quaternion rotation = Quaternion.identity;

        for (int i = 0; i < _boardWidth; ++i)
        {
            for(int j = 0; j < _boardWidth; ++j)
            {
                position.Set(j, 0.0f, i);
                
                gameObject = Instantiate(_emptySquare, position, rotation) as GameObject;
                gameObject.name = ((i * _boardWidth) + j).ToString();

                _squares.Add(new Square(gameObject, true));
            }
        }

        gameObject = _squares[(_boardWidth * _boardWidth) - 1].SquareGameObject;

        _mainCamera.transform.position = new Vector3(gameObject.transform.position.x / 2, 100.0f, gameObject.transform.position.z / 2);
        _mainCamera.orthographicSize = (_boardWidth / 2) + 1;
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
}
