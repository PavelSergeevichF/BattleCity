using UnityEngine;
using UnityEngine.UI;

public class UIStartScenView : MonoBehaviour
{
    [SerializeField] private InputField _loginInputField;
    [SerializeField] private InputField _parolInputField;
    [SerializeField] private InputField _parol2InputField;
    [SerializeField] private InputField _mailInputField;
    [SerializeField] private Text _infoText;
    [SerializeField] private Button _buttonOnePlayer;
    [SerializeField] private Button _buttonTwoPlayer; 
    [SerializeField] private Button _buttonSettins;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private Button _buttonRegExitGame;
    [SerializeField] private Button _buttonSelectReg;
    [SerializeField] private Button _buttonRegNext;
    [SerializeField] private GameObject _panelPassword2;
    [SerializeField] private GameObject _panelEmail;
    [SerializeField] private GameObject _panelRegOrLogin;
    [SerializeField] private GameObject _panelSetting;
    [SerializeField] private SOPlayerData _sOPlayerData;
    [SerializeField] private SOGameData _sOGameData;
    [SerializeField] private Login _login;

    private UIStartScenController _uIStartScenController;

    public InputField LoginInputField => _loginInputField;
    public InputField ParolInputField => _parolInputField;
    public InputField Parol2InputFiel => _parol2InputField;
    public InputField MailInputField  => _mailInputField;
    public Text InfoText => _infoText;

    public Button       ButtonOnePlayer =>_buttonOnePlayer;
    public Button       ButtonTwoPlayer =>_buttonTwoPlayer;
    public Button       ButtonSettings  =>_buttonSettins;
    public Button       ButtonExit      =>_buttonExit;
    public Button       ButtonRegExitGame => _buttonRegExitGame;
    public Button       ButtonSelectReg => _buttonSelectReg;
    public Button       ButtonRegNext   =>_buttonRegNext;
    public GameObject   PanelRegOrLogin =>_panelRegOrLogin;
    public GameObject   PanelSetting    => _panelSetting;
    public GameObject   PanelEmail      => _panelEmail;
    public GameObject   PanelPassword2 => _panelPassword2;

    public GameObject   PanelleBlocked;
    public SOPlayerData SOPlayerData    =>_sOPlayerData;
    public SOGameData SOGameData => _sOGameData;
    public Login Login => _login;

    private void Awake()
    {
        _uIStartScenController = new UIStartScenController(this);
        SOPlayerData.UserName = PlayerPrefs.GetString("Name");
        SOPlayerData.Password = PlayerPrefs.GetString("Password");
    }
    private void Update() => _uIStartScenController.Update();
}
