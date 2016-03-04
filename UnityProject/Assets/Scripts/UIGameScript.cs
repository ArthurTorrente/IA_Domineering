using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIGameScript : MonoBehaviour
{
    [SerializeField]
    BoardManagerScript _boardManagerScript;

    [SerializeField]
    UIPauseScript _uiPauseScript;

    [SerializeField]
    GameObject _playerTurn;

    [SerializeField]
    GameObject _horizontal;

    [SerializeField]
    GameObject _vertical;

    public void SwitchPlayerOrientation()
    {
        _horizontal.SetActive(!_horizontal.activeInHierarchy);
        _vertical.SetActive(!_vertical.activeInHierarchy);
    }
}
