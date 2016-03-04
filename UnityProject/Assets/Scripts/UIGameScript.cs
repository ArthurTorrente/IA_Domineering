using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGameScript : MonoBehaviour
{
    [SerializeField]
    UIPauseScript _uiPauseScript;

    [SerializeField]
    GameObject _uiRoot;

    [SerializeField]
    GameObject _playerTurn;
    
    [SerializeField]
    Text _playerTurnText;

    [SerializeField]
    GameObject _horizontal;

    [SerializeField]
    GameObject _vertical;

    public GameObject UiRoot
    {
        get { return _uiRoot; }
        set { _uiRoot = value; }
    }

    public Text PlayerTurnText
    {
        get { return _playerTurnText; }
        set { _playerTurnText = value; }
    }

    public GameObject Horizontal
    {
        get { return _horizontal; }
        set { _horizontal = value; }
    }

    public GameObject Vertical
    {
        get { return _vertical; }
        set { _vertical = value; }
    }

    public void SwitchPlayerOrientation()
    {
        _horizontal.SetActive(!_horizontal.activeInHierarchy);
        _vertical.SetActive(!_vertical.activeInHierarchy);
    }

    public void SetPlayerText(string playerText)
    {
        _playerTurnText.text = playerText;
    }
}
