using UnityEngine;
using System.Collections;

public class Square 
{
    bool _isEmpty;

    GameObject _squareGameObject;

    public Square(GameObject gameObject, bool isEmpty)
    {
        _isEmpty = isEmpty;
        _squareGameObject = gameObject;
    }

    public bool IsEmpty
    {
        get { return _isEmpty; }
        set { _isEmpty = value; }
    }

    public GameObject SquareGameObject
    {
        get { return _squareGameObject; }
        set { _squareGameObject = value; }
    }
}
