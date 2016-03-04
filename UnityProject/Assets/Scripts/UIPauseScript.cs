using UnityEngine;
using System.Collections;

public class UIPauseScript : MonoBehaviour 
{
    [SerializeField]
    BoardManagerScript _boardManagerScript;

    [SerializeField]
    UIMainMenuScript _uiMainMenuScript;

    [SerializeField]
    UIGameScript _uiGameScript;

    [SerializeField]
    GameObject _uiRoot;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void SetPause(bool value)
    {
        _uiRoot.SetActive(value);
    }

    public void UnsetPause()
    {
        _boardManagerScript.PauseGame();
    }

    public void ResetGame()
    {
        _boardManagerScript.ResetGame();
        _boardManagerScript.PauseGame();
    }

    public void ReturnToMenu()
    {
        _boardManagerScript.ResetGame();
        _uiRoot.SetActive(false);
        _uiMainMenuScript.ActiveMainMenu();
    }
}
