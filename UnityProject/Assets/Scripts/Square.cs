using UnityEngine;

public class Square 
{
    GameObject _squareGameObject;

    public Square(GameObject gameObject)
    {
        _squareGameObject = gameObject;
    }

    public GameObject SquareGameObject
    {
        get { return _squareGameObject; }
        set { _squareGameObject = value; }
    }
}
