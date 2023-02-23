using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using ExitGames.Client.Photon;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIStartScenController
{
    private bool _checkName=true;
    private bool _panelRegOrLogin=false;
    private UIStartScenView _uIStartScenView;
    private UILogRegController _uILogRegController;

    public UIStartScenController(UIStartScenView uIStartScenView)
    {
        _uIStartScenView = uIStartScenView;
        _uIStartScenView.ButtonOnePlayer.onClick.AddListener(StartOnePlayerGame);
        _uIStartScenView.ButtonTwoPlayer.onClick.AddListener(StartTwoPlayerGame);
        _uIStartScenView.ButtonSettings.onClick.AddListener(OpenSettingGame);
        _uIStartScenView.ButtonExit.onClick.AddListener(ExitGame);
        _uIStartScenView.ButtonRegExitGame.onClick.AddListener(ExitGame);
        _uIStartScenView.PanelRegOrLogin.SetActive(false);
        _uILogRegController = new UILogRegController(_uIStartScenView);
    }
    public void CheckName()
    {
        if (_uIStartScenView.SOPlayerData.UserName.Length < 3)
        {
            _uIStartScenView.PanelRegOrLogin.SetActive(true);
            _panelRegOrLogin = true;
        }
        else
        {
            _uIStartScenView.PanelRegOrLogin.SetActive(false);
        }
        _checkName = false;
    }

    internal void Update()
    {
        _uILogRegController.Update();
        if (_checkName)
        {
            CheckName();
        }
    }
    private void StartOnePlayerGame()
    {
        _uIStartScenView.SOPlayerData.OnePlayer = true;
        SceneManager.LoadSceneAsync(2);
    }
    private void StartTwoPlayerGame()
    {
        _uIStartScenView.SOPlayerData.OnePlayer = false;
        _uIStartScenView.Login.Connect();
    }
    private void ExitGame() 
    {
        Application.Quit();
    }
    private void OpenSettingGame()
    {
        _uIStartScenView.PanelSetting.SetActive(true);
    }
    
}
