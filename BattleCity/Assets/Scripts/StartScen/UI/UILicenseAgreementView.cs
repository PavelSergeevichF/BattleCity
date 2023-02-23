using UnityEngine;
using UnityEngine.UI;

public class UILicenseAgreementView : MonoBehaviour
{
    [SerializeField] private bool _reset=false;
    [SerializeField] private Toggle _toggleAgreement;
    [SerializeField] private Button _buttonNext;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private Text _textLicense;
    [SerializeField] private GameObject _panelleAgreement;
    [SerializeField] private GameObject _panelleBlocked;
    [SerializeField] private SOPlayerData _sOPlayerData;

    private string _textForLicense;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("_bool")!=1)
        {
            _panelleAgreement.SetActive(true);
            _panelleBlocked.SetActive(true);
        }
        _buttonNext.onClick.AddListener(ClosePanel);
        _buttonExit.onClick.AddListener(ExitGame);
        _toggleAgreement.isOn = false;
    }

    private void Update()
    {
        if (_reset)
        {
            PlayerPrefs.SetInt("_bool", 0);
            _reset = false;
        }
        if(_toggleAgreement.isOn)
        {
            _panelleBlocked.SetActive(false);
            PlayerPrefs.SetInt("_bool", 1);
        }
    }
    private void ClosePanel()
    {
        _panelleAgreement.SetActive(false);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
