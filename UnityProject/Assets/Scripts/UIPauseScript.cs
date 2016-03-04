using UnityEngine;
using System.Collections;

public class UIPauseScript : MonoBehaviour 
{
    [SerializeField]
    GameSettingScript _gameSettingScript;

    [SerializeField]
    BoardManagerScript _boardManagerScript;

    [SerializeField]
    UIMainMenuScript _uiMainMenuScript;

    [SerializeField]
    UIGameScript _uiGameScript;

    [SerializeField]
    GameObject _uiRoot;


    public void SetPause(bool value)
    {       
        _uiRoot.SetActive(value);
        _uiGameScript.UiRoot.SetActive(!value);
    }

    public void UnsetPause()
    {
        _boardManagerScript.PauseGame();
    }

    public void ResetGame()
    {
        _boardManagerScript.ResetBoard();
        _boardManagerScript.ResetGameSettings();
        _boardManagerScript.PauseGame();
    }

    public void ReturnToMenu()
    {
        _boardManagerScript.ResetBoard();
        _uiRoot.SetActive(false);
        _uiMainMenuScript.ActiveMainMenu();
        _gameSettingScript.GameState = GameState.MainMenu;
    }
}
