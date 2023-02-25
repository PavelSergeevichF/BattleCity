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
    {
        _uISettingView.SOPlayerData.UserName = "";
        _uISettingView.SOPlayerData.Password = "";
        Exit();
        _uISettingView.UIStartScenView.PanelRegOrLogin.SetActive(true);
    }
    private void Exit()
    {
        _uISettingView.PanelSetting.SetActive(false);
    }
    private void SetVol()
    {
        if(_uISettingView.SOPlayerData.SoundVolume != _uISettingView.SoundSlider.value)
        {
            _uISettingView.SOPlayerData.SoundVolume = _uISettingView.SoundSlider.value;
            _uISettingView.AudioMixer.SetFloat("Sound", _uISettingView.SOPlayerData.SoundVolume);
        }
        if (_uISettingView.SOPlayerData.MusicVolume != _uISettingView.MusicSlider.value)
        {
            _uISettingView.SOPlayerData.MusicVolume = _uISettingView.MusicSlider.value;
            _uISettingView.AudioMixer.SetFloat("Music", _uISettingView.SOPlayerData.MusicVolume);
        }
        
    }
}
