using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIBattleController : IExecute
{
    private bool _playGameOvwr = false;
    private bool _finishWorkeStageEnd= false;
    private int _pause;
    private int _checkLine = 4;
    private int[] _scoreType=new int[4];
    private int _score = 0;
    private UIBattleView _uIBattleView;
    private SOPlayerData _sOPlayerData;
    private EStatusLevel _eStatusLevel= EStatusLevel.Default;


    public delegate void GetFireDelegate();
    public event GetFireDelegate TransleteFire;


    public UIBattleController(UIBattleView uIBattleView, SOPlayerData sOPlayerData)
    {
        _uIBattleView = uIBattleView;
        uIBattleView.UIBattleController = this;
        _sOPlayerData = sOPlayerData;
        _uIBattleView.Level.text = _sOPlayerData.Level.ToString();
        _pause = _uIBattleView.Pause;
        _uIBattleView.LevelEndNext.onClick.AddListener(ButtonNextInScorWindow);
        _uIBattleView.GameEndNext.onClick.AddListener(ButtonNextInGameOverWindow);
        _uIBattleView.FireButton.onClick.AddListener(ButtonFire);
        //_uIBattleView.UIButtonFireView.FireButton.GetComponent<UIButtonFireView>().onPressedOverSeconds.AddListener(ButtonFire);
        foreach (var text in _uIBattleView.ScoreType)
        {
            text.text = "0";
        }
        _uIBattleView.Score.text = "0";
        _sOPlayerData.EStatusLevel = EStatusLevel.Default;
    }

    public void Execute()
    {
        if(_eStatusLevel!= _sOPlayerData.EStatusLevel)
        {
            _eStatusLevel= _sOPlayerData.EStatusLevel;
            switch (_sOPlayerData.EStatusLevel)
            {
                case EStatusLevel.Default: GetDataLive(); break;
                case EStatusLevel.LevelEnd: StageEnd(); break;
                case EStatusLevel.GameOver: GameOver(); break;
            };
        }
        if(_finishWorkeStageEnd)
        {
            WorkeStageEnd();
        }
    }
    private void GetDataLive()
    {
        _uIBattleView.Live.text = _sOPlayerData.Live.ToString();
    }
    public void GameOver()
    {
        StageEnd();
        _finishWorkeStageEnd = true;
        if (_sOPlayerData.RecordScore < _sOPlayerData.Score)
        {
            _sOPlayerData.RecordScore= _sOPlayerData.Score;
        }
    }
    public void StageEnd()
    {
        _finishWorkeStageEnd = true;
        for(int i =0; i<4; i++)
        {
            _score += _sOPlayerData.DestroyEnemyOnType[i]*(i+1)*10;
        }
        _sOPlayerData.Score = _score;
        SelectWindow(EStatusLevel.LevelEnd);
    }
    private void WorkeStageEnd()
    {

        if(_pause==0)
        {
            _pause = _uIBattleView.Pause;
            if (_sOPlayerData.DeadEnemy == 0)
            {
                if (_checkLine == 0)
                {
                    _finishWorkeStageEnd = false;
                }
                else 
                {
                    _uIBattleView.Score.text = _score.ToString();
                    _checkLine--;
                    _uIBattleView.AudioSourceView.AudioCount.Play();
                }
            }
            else 
            {
                _sOPlayerData.DeadEnemy--;
                if (_sOPlayerData.DestroyEnemyOnType[0]>0)
                {
                    MatheScore(0,1);
                }
                else 
                {
                    if (_sOPlayerData.DestroyEnemyOnType[1] > 0)
                    {
                        MatheScore(1, 2);
                    }
                    else 
                    {
                        if (_sOPlayerData.DestroyEnemyOnType[2] > 0)
                        {
                            MatheScore(2, 3);
                        }
                        else
                        {
                            if (_sOPlayerData.DestroyEnemyOnType[3] > 0)
                            {
                                MatheScore(3, 4);
                            }
                            else 
                            {
                                _uIBattleView.Score.text = _score.ToString();
                            }
                        }
                    }
                }

            }
        }
        _pause--;
    }
    private void MatheScore(int type, int coof)
    {
        _scoreType[type] += 10* coof;
        _sOPlayerData.DestroyEnemyOnType[type]--;
        _uIBattleView.ScoreType[type].text = _scoreType[type].ToString();
        _uIBattleView.AudioSourceView.AudioCount.Play();
    }
    private void WorkeGameOver()
    {
        if(!_playGameOvwr)
        {
            _playGameOvwr= true;
            SelectWindow(EStatusLevel.GameOver);
            _uIBattleView.AudioSourceView.AudioGameOver.Play();
        }
    }
    private void ButtonNextInScorWindow()
    {
        if (_sOPlayerData.EStatusLevel == EStatusLevel.GameOver)
        {
            WorkeGameOver();
        }
        else 
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
    private void ButtonNextInGameOverWindow()
    {
        if(_sOPlayerData.OnePlayer)
        {
            SceneManager.LoadSceneAsync(1);
        }
        else 
        {
            _uIBattleView.Leave();
        }
    }
    private void ButtonFire()
    {
        TransleteFire?.Invoke();
    }
    
    private void SelectWindow(EStatusLevel eStatusLevel)
    {
        _uIBattleView.BttleField.SetActive(false);
        _uIBattleView.LevelEnd.SetActive(false);
        _uIBattleView.GameEnd.SetActive(false);
        switch(eStatusLevel)
        {
            case EStatusLevel.Default: _uIBattleView.BttleField.SetActive(true); break;
            case EStatusLevel.LevelEnd: _uIBattleView.LevelEnd.SetActive(true); break;
            case EStatusLevel.GameOver: _uIBattleView.GameEnd.SetActive(true); break;
        };
    }

    
}
