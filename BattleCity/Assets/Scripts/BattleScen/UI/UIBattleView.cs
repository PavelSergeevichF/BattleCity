using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIBattleView : MonoBehaviourPunCallbacks
{ 
    [SerializeField] private int _pause;
    public List<GameObject> EnemyNum;
    [SerializeField] private Text _live;
    [SerializeField] private Text _level;
    [SerializeField] private Text _score;

    [SerializeField] private Button _levelEndNext;
    [SerializeField] private Button _gameEndNext;
    [SerializeField] private GameObject _levelEnd;
    [SerializeField] private GameObject _gameEnd;
    [SerializeField] private GameObject _battleField;
    [SerializeField] private AudioSourceView _audioSourceView;
    [SerializeField] private UIButtonFireView _uIButtonFireView; 
    [SerializeField] private SOPlayerData _sOPlayerData;


    public int Pause => _pause;
    public AudioSourceView AudioSourceView => _audioSourceView;


    public Text Live => _live;
    public Text Level =>_level;
    public Text Score =>_score;
    public List<Text> ScoreType;
    public SOPlayerData SOPlayerData => _sOPlayerData;
    public GameObject LevelEnd => _levelEnd;
    public GameObject GameEnd => _gameEnd;
    public GameObject BttleField => _battleField;
    public Button LevelEndNext => _levelEndNext;
    public Button GameEndNext => _gameEndNext;
    public Button FireButton;
    public UIBattleController UIBattleController;
    public UIButtonFireView UIButtonFireView=> _uIButtonFireView;

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadSceneAsync(1);
    }

}
