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

    // Use this for initialization
    void Start()
    {
        _gameSettingScript.GameState = GameState.MainMenu;
    }

    public void launchPlayerVersusAi()
    {
        _gameSettingScript.GameMode = GameMode.PlayerVersusAi;
        _uiRoot.SetActive(false);

        if (_gameSettingScript.FirstPlayerToPlay == FirstPlayer.Player)
        {
            _boardManagerScript.PlayerOneName = "Player";
            _boardManagerScript.PlayerTwoName = "Ai";
        }
        else
        {
            _boardManagerScript.PlayerOneName = "Ai";
            _boardManagerScript.PlayerTwoName = "Player";
        }

        _boardManagerScript.LaunchGame();
    }

    public void launchPlayerVersusPlayer()
    {
        _gameSettingScript.GameMode = GameMode.PlayerVersurPlayer;
        _uiRoot.SetActive(false);

        _boardManagerScript.PlayerOneName = "Player 1";
        _boardManagerScript.PlayerTwoName = "Player 2";

        _boardManagerScript.LaunchGame();
    }

    public void launchAiVersusAi()
    {
        _gameSettingScript.GameMode = GameMode.AiVersusAi;
        _uiRoot.SetActive(false);

        _boardManagerScript.PlayerOneName = "Ai 1";
        _boardManagerScript.PlayerTwoName = "Ai 2";

        _boardManagerScript.LaunchGame();
    }

    public void Options()
    {
        _uiRoot.SetActive(false);
        _uiOptionScript.UiRoot.SetActive(true);
        _gameSettingScript.GameState = GameState.Options;
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
