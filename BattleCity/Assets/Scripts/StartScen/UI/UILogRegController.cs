using Photon.Pun;
using Photon.Realtime;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class UILogRegController
{
    private string _name;
    private string _tempPassword="";
    private string _password="";
    private string _email;
    private bool _inputName = false;
    private bool _inputPassword = false;
    private bool _inputPassword2 = false;
    private bool _inputEmail = false;
    private bool _isOpenNext = false;
    private bool _isReg = true;

    private UIStartScenView _uIStartScenView;

    public UILogRegController(UIStartScenView uIStartScenView)
    {
        _uIStartScenView = uIStartScenView;

        _uIStartScenView.ButtonRegNext.onClick.AddListener(NextButtonDown);
        _uIStartScenView.ButtonSelectReg.onClick.AddListener(SelectRegOrLog);
        _uIStartScenView.LoginInputField.onEndEdit.AddListener(delegate { GetName(_uIStartScenView.LoginInputField); });
        _uIStartScenView.ParolInputField.onEndEdit.AddListener(delegate { GetPassword(_uIStartScenView.ParolInputField); });
        _uIStartScenView.Parol2InputFiel.onEndEdit.AddListener(delegate { GetPassword2(_uIStartScenView.Parol2InputFiel); });
        _uIStartScenView.MailInputField.onEndEdit.AddListener(delegate { GetEmail(_uIStartScenView.MailInputField); });

        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = _uIStartScenView.SOGameData.PlayFabTitle;
        }
    }
    internal void Update()
    {
        CheckInputData();
        if (_isOpenNext)
        {
            _uIStartScenView.PanelleBlocked.SetActive(false);
        }
    }

    private void GetName(InputField input)
    {
        string name = input.text;
        if (name.Length < 3)
        {
            _uIStartScenView.InfoText.text = "Имя слишком короткое";
            _inputName = false;
        }
        else
        {
            _name = name;
            _uIStartScenView.InfoText.text = $"Имя {name}";
            _inputName = true;
        }
        //--------------------------------------------------------------------Добавить проверку на занятость имени
    }

    private void GetPassword(InputField input)
    {
        string password = input.text;
        if (password.Length < 6)
        {
            _uIStartScenView.InfoText.text = "Пароль слишком короткий";
            _inputPassword = false;
        }
        else
        {
            if (_isReg)
            {
                _tempPassword = password;
                _password = "";
            }
            else 
            {
                _password = password;
            }
            
            _uIStartScenView.InfoText.text = "Пароль ОК";
            _inputPassword=true;
        }
        //--------------------------------------------------------------------Добавить проверку на сложность пароля
    }

    private void GetPassword2(InputField input)
    {
        string password = input.text;
        if(_tempPassword.Length < 6)
        {
            _uIStartScenView.InfoText.text = "Первое поле пароля не заполнино";
        }
        else 
        {
            if (password != _tempPassword)
            {
                _uIStartScenView.InfoText.text = "Пароли не совпадают";
                _inputPassword2 = false;
            }
            else
            {
                _password = password;
                _uIStartScenView.InfoText.text = "Проверка пароля ОК";
                _inputPassword2 = true;
            }
        }
    }

    private void GetEmail(InputField input)
    {
        string email = input.text;
        if (email.Length < 5)
        {
            _uIStartScenView.InfoText.text = "Первое поле пароля не заполнино";
        }
        else
        {
            _email= email;
            _uIStartScenView.InfoText.text = "Ввод почты ОК";
            _inputEmail= true;
        }
        //--------------------------------------------------------------------Добавить проверку на правильность ввода почты @ .
    }
    private void CheckInputData()
    {
        if (_isReg) { _isOpenNext = _inputName && _inputPassword && _inputPassword2 && _inputEmail ? true : false; }
        else  {  _isOpenNext = _inputName && _inputPassword ? true : false; }
    }       
    private void SelectRegOrLog() 
    { 
        if(_isReg)
        {
            _isReg = false;
            _uIStartScenView.PanelPassword2.SetActive(false);
            _uIStartScenView.PanelEmail.SetActive(false);
            _uIStartScenView.ButtonSelectReg.GetComponentInChildren<Text>().text = "Регистрация";
        }
        else 
        {
            _isReg = true;
            _isOpenNext = false;
            _uIStartScenView.PanelPassword2.SetActive(true);
            _uIStartScenView.PanelEmail.SetActive(true);
            _uIStartScenView.ButtonSelectReg.GetComponentInChildren<Text>().text = "Войти";
        }
    }
    private void NextButtonDown()
    {
        _uIStartScenView.SOPlayerData.UserName = _name;
        _uIStartScenView.SOPlayerData.Password= _password;
        string errorStr = "";
        var request = new LoginWithCustomIDRequest
        {
            CustomId = _name,
            CreateAccount = _isReg
        };
        PlayFabClientAPI.LoginWithCustomID(request,
            result =>
            {
                Debug.Log(result.PlayFabId);
                _uIStartScenView.SOGameData.PlayFabId = result.PlayFabId;
                _uIStartScenView.Login.PhotonSetup();
                _uIStartScenView.PanelRegOrLogin.SetActive(false);
            },
            error => LogError(error));
    }

    private void LogError(PlayFab.PlayFabError error)
    {
        Debug.Log(error);
        _uIStartScenView.InfoText.text = error.ToString();
    }
}
