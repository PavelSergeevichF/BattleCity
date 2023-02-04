using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISettingView : MonoBehaviour
{
    [SerializeField] private Button _buttonExitLogin;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private GameObject _panelSetting;
    [SerializeField] private SOPlayerData _sOPlayerData;
    [SerializeField] private AudioMixer _audioMixer;

    private UISettingController _uISettingController;

    public Button ButtonExitLogin => _buttonExitLogin;
    public Button ButtonExit => _buttonExit;
    public Slider SoundSlider => _soundSlider;
    public Slider MusicSlider => _musicSlider;
    public GameObject PanelSetting => _panelSetting;
    public SOPlayerData SOPlayerData => _sOPlayerData;
    public AudioMixer AudioMixer=> _audioMixer;


    private void Awake()
    {
        _uISettingController = new UISettingController(this);
    }

    private void Update() =>  _uISettingController.Update();
}
