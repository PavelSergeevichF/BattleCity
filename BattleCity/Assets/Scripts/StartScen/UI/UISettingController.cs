using System;
using UnityEngine;

public class UISettingController
{
    private UISettingView _uISettingView;

    public UISettingController(UISettingView uISettingView)
    {
        _uISettingView = uISettingView;
        _uISettingView.ButtonExit.onClick.AddListener(Exit);
        _uISettingView.ButtonExitLogin.onClick.AddListener(LogOutAccount);
    }

    internal void Update()
    {
        SetVol();
    }
    private void LogOutAccount()
    { }
    private void Exit()
    {
        _uISettingView.PanelSetting.SetActive(false);
    }
    private void SetVol()
    {
        _uISettingView.SOPlayerData.SoundVolume = _uISettingView.SoundSlider.value;
        _uISettingView.SOPlayerData.MusicVolume = _uISettingView.MusicSlider.value;
    }
}
