using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIScenLoading : MonoBehaviour
{
    [SerializeField] private Image _imageLoad;
    [SerializeField] private Text  _textLoad;
    [SerializeField] private bool _StartOrLoad;
    [SerializeField] private SOPlayerData _sOPlayerData;

    private void Awake()
    {
        _sOPlayerData.Live = 2;
        StartCoroutine(AsyncLoad());
    }


    private IEnumerator AsyncLoad() 
    {
        AsyncOperation operation;
        if (_StartOrLoad)
        {
            operation = SceneManager.LoadSceneAsync(1);
        }
        else 
        {
            _textLoad.text = "Загрузка " + _sOPlayerData.Level;
            operation = SceneManager.LoadSceneAsync(_sOPlayerData.Level+2);
        }
        while(!operation.isDone)
        {
            _imageLoad.fillAmount = operation.progress;
            yield return null;
        }
    }
}
