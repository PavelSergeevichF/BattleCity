using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIStartScenController
{
    private UIStartScenView _uIStartScenView;

    public UIStartScenController(UIStartScenView uIStartScenView)
    {
        _uIStartScenView = uIStartScenView;
        _uIStartScenView.ButtonOnePlayer.onClick.AddListener(StartOnePlayerGame);
        _uIStartScenView.ButtonTwoPlayer.onClick.AddListener(StartTwoPlayerGame);
        _uIStartScenView.ButtonSettings.onClick.AddListener(OpenSettingGame);
        _uIStartScenView.ButtonExit.onClick.AddListener(ExitGame);
        _uIStartScenView.PanelRegOrLogin.SetActive(false);
    }
    public void CheckName()
    {
        if (_uIStartScenView.SOPlayerData.UserName.Length < 3)
        {
            _uIStartScenView.PanelRegOrLogin.SetActive(true);
        }
        else
        {
            _uIStartScenView.PanelRegOrLogin.SetActive(false);
        }
    }

    internal void Update()
    {
        CheckName();
    }
    private void StartOnePlayerGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
    private void StartTwoPlayerGame()
    { }
    private void ExitGame() 
    {
        Application.Quit();
    }
    private void OpenSettingGame()
    {
        _uIStartScenView.PanelSetting.SetActive(true);
    }
}
