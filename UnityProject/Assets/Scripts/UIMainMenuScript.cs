using UnityEngine;
using System.Collections;

public class UIMainMenuScript : MonoBehaviour
{
    [SerializeField]
    GameSettingScript _gameSettingScript;

    [SerializeField]
    BoardManagerScript _boardManagerScript;

    [SerializeField]
    UIOptionsScript _uiOptionScript;

    [SerializeField]
    GameObject _uiRoot;

    [SerializeField]
    GameObject _boardRoot;

    public void launchPlayerVersusAi()
    {
        _gameSettingScript.GameState = GameState.Game;
        _gameSettingScript.GameMode = GameMode.PlayerVersusAi;
        _boardManagerScript.BeginGame();
        _uiRoot.SetActive(false);
    }

    public void launchPlayerVersusPlayer()
    {
        _gameSettingScript.GameState = GameState.Game;
        _gameSettingScript.GameMode = GameMode.PlayerVersurPlayer;
        _boardManagerScript.BeginGame();
        _uiRoot.SetActive(false);
    }

    public void launchAiVersusAi()
    {
        _gameSettingScript.GameState = GameState.Game;
        _gameSettingScript.GameMode = GameMode.AiVersusAi;
        _boardManagerScript.BeginGame();
        _uiRoot.SetActive(false);
    }

    public void Options()
    {
        _uiRoot.SetActive(false);
        _uiOptionScript.UiRoot.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ActiveMainMenu()
    {
        _uiRoot.SetActive(true);
    }
}
