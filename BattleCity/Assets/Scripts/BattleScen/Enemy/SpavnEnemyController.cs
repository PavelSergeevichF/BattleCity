using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpavnEnemyController : IFixedExecute
{
    private GreedView _greedView;
    private SpawnEnemyView _spawnEnemyView;
    private UIBattleView _uIBattleView;
    private SOPlayerData _sOPlayerData;
    private int _ticSpawn;
    private int _countEnemy = 0;
    private int _numEnemy = 0;

    private EnemyObjectView _enemyObjectView;
    private List<EnemyController> _enemyControllers = new List<EnemyController>();

    public SpavnEnemyController(GreedView greedView, SpawnEnemyView spawnEnemyView, UIBattleView uIBattleView)
    {
        _greedView = greedView;
        _spawnEnemyView = spawnEnemyView;
        _uIBattleView = uIBattleView;
        SpawnPull();
        ActivEnemy();
        _ticSpawn = _spawnEnemyView.Time;
        _sOPlayerData = uIBattleView.SOPlayerData;
        _sOPlayerData.EStatusLevel = EStatusLevel.Default;
        for (int i=0; i<4; i++)
        {
            _sOPlayerData.DestroyEnemyOnType[i] = 0;
        }
        _sOPlayerData.DeadEnemy = 0;
    }

    public void FixedExecute()
    {
        _ticSpawn--;
        if (_ticSpawn < 1)
        {
            _ticSpawn = _spawnEnemyView.Time;
            if (_countEnemy< _spawnEnemyView.MaxPull && _numEnemy< _spawnEnemyView.MaxSpavnTogether)
            {
                ActivEnemy();
            }
        }

        foreach (var exe in _enemyControllers)
        {
            if (exe.IsActiv)
            {
                exe.Execute();
            }
        }
        if (_sOPlayerData.EStatusLevel == EStatusLevel.LevelEnd || _sOPlayerData.EStatusLevel == EStatusLevel.GameOver)
        {
            foreach (var enemyController in _enemyControllers)
            {
                _countEnemy = _spawnEnemyView.MaxPull;
                enemyController.EnemyObjectView.gameObject.SetActive(false);
            }
        }
    }
    private void ActivEnemy()
    {
        _numEnemy++;
        _enemyControllers[_countEnemy].EnemyObjectView.gameObject.SetActive(true);
        _enemyControllers[_countEnemy].IsActiv = true;
        _countEnemy++;
    }
    private void SpawnPull()
    {
        for(int i=0; i<20; i++)
        {
            SpawnEnemy();
            _enemyControllers[i].EnemyObjectView.gameObject.SetActive(false);
            _enemyControllers[i].IsActiv = false;
        }
    }
    private void SpawnEnemy()
    {
        GameObject _enemy;
        _spawnEnemyView.SetOrder();
        _spawnEnemyView.Spawn(_greedView, out _enemy);
        _enemyObjectView = _enemy.GetComponent<EnemyObjectView>();
        EnemyController enemyController = new EnemyController(_greedView, _enemy, _enemyObjectView,  _spawnEnemyView.AudioSourceView, _enemyControllers.Count);
        _enemyControllers.Add(enemyController);
        enemyController.TransleteDead += GetDead;
    }
    private void GetDead(int value)
    {
        _uIBattleView.EnemyNum[value].SetActive(false);
        _numEnemy--;
        _sOPlayerData.DeadEnemy++;
        if(_sOPlayerData.DeadEnemy == _spawnEnemyView.MaxPull)
        {
            _sOPlayerData.EStatusLevel = EStatusLevel.LevelEnd;
        }
        switch (_enemyControllers[value].EnemyObjectView.EEnemyType)
        {
            case EEnemyType.Type1: _sOPlayerData.DestroyEnemyOnType[0]++; break;
            case EEnemyType.Type2: _sOPlayerData.DestroyEnemyOnType[1]++; break;    
            case EEnemyType.Type3: _sOPlayerData.DestroyEnemyOnType[2]++; break; 
            case EEnemyType.Type4: _sOPlayerData.DestroyEnemyOnType[3]++; break;
        };
        _enemyControllers[value].IsActiv = false;
        _enemyControllers[value].EnemyObjectView.gameObject.SetActive(false);
        _spawnEnemyView.AudioSourceView.AudioDestroyEnemy.Play();
    }
}
