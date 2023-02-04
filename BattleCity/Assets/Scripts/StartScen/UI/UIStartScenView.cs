using UnityEngine;
using UnityEngine.UI;

public class UIStartScenView : MonoBehaviour
{
    [SerializeField] private Button _buttonOnePlayer;
    [SerializeField] private Button _buttonTwoPlayer; 
    [SerializeField] private Button _buttonSettins;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private GameObject _panelRegOrLogin;
    [SerializeField] private GameObject _panelSetting;
    [SerializeField] private SOPlayerData _sOPlayerData;

    private UIStartScenController _uIStartScenController;

    public Button       ButtonOnePlayer =>_buttonOnePlayer;
    public Button       ButtonTwoPlayer =>_buttonTwoPlayer;
    public Button       ButtonSettings  =>_buttonSettins;
    public Button       ButtonExit      =>_buttonExit;
    public GameObject   PanelRegOrLogin =>_panelRegOrLogin;
    public GameObject   PanelSetting    =>_panelSetting;
    public SOPlayerData SOPlayerData    =>_sOPlayerData;

    private void Awake()
    {
        _uIStartScenController = new UIStartScenController(this);
    }
    private void Update() => _uIStartScenController.Update();
}
