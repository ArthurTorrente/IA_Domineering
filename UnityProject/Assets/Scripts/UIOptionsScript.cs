using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIOptionsScript : MonoBehaviour
{
    [SerializeField]
    GameSettingScript _gameSettingScript;

    [SerializeField]
    UIMainMenuScript _uiMainMenuScript;

    [SerializeField]
    GameObject _uiRoot;

    [SerializeField]
    Dropdown _borderSizeDropdown;

    [SerializeField]
    Dropdown _orientationFirstPlaterDropdown;

    [SerializeField]
    Dropdown _firstPlayerDropdown;

    [SerializeField]
    Dropdown _AiOneDropdown;

    [SerializeField]
    Dropdown _AiTwoDropdown;

    public GameObject UiRoot
    {
        get { return _uiRoot; }
        set { _uiRoot = value; }
    }

	// Use this for initialization
	void Start () 
    {
        _orientationFirstPlaterDropdown.value = 0;
        _gameSettingScript.PlayerOneOrientation = (Orientation)_orientationFirstPlaterDropdown.value;

        _firstPlayerDropdown.value = 0;
        _gameSettingScript.FirstPlayerToPlay = (FirstPlayer)_firstPlayerDropdown.value;

        _AiOneDropdown.value = 0;
        _gameSettingScript.AiOneMode = (AiMode)_AiOneDropdown.value;

        _AiTwoDropdown.value = 0;
        _gameSettingScript.AiTwoMode = (AiMode)_AiTwoDropdown.value;

        _borderSizeDropdown.value = 3;
        int borderWidth;
        if (int.TryParse(_borderSizeDropdown.captionText.text, out borderWidth))
            _gameSettingScript.BoardSize = borderWidth;
        else
            _gameSettingScript.BoardSize = 8;
	}
	
    public void OnBoardSizeChange()
    {
        int borderWidth;
        if (int.TryParse(_borderSizeDropdown.captionText.text, out borderWidth))
            _gameSettingScript.BoardSize = borderWidth;
        else
            _gameSettingScript.BoardSize = 8;
    }

    public void OnFirstPlayerOrientationChange()
    {
        if (_orientationFirstPlaterDropdown.value == 0)
            _gameSettingScript.PlayerOneOrientation = Orientation.Horizontal;
        else if (_orientationFirstPlaterDropdown.value == 1)
            _gameSettingScript.PlayerOneOrientation = Orientation.Vertical;
    }

    public void OnFirstPlayerChange()
    {
        _gameSettingScript.FirstPlayerToPlay = (FirstPlayer)_firstPlayerDropdown.value;
    }

    public void OnAiOneChange()
    {
        _gameSettingScript.AiOneMode = (AiMode)_AiOneDropdown.value;
    }

    public void OnAiTwoChange()
    {
        _gameSettingScript.AiTwoMode = (AiMode)_AiTwoDropdown.value;
    }

    public void ReturnToMenu()
    {
        _uiRoot.SetActive(false);
        _uiMainMenuScript.ActiveMainMenu();
    }
}
