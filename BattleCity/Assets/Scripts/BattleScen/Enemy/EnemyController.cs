using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : IExecute
{
    private GreedView _greedView;
    private SpawnEnemyView _spawnEnemyView;
    private GameObject _enemy;
    private int _ticSpawn;
    private EnemyObjectView _enemyObjectView;
    private List<MoveController> _moveControllers = new List<MoveController>();
    private List<BotController> _botControllers = new List<BotController>();

    public EnemyController(GreedView greedView, SpawnEnemyView spawnEnemyView)
    {
        _greedView = greedView;
        _spawnEnemyView = spawnEnemyView;
        SpawnEnemy();
        _ticSpawn=_spawnEnemyView.Time;
        _enemyObjectView.TransleteDamage += GetDamage;
    }

    public void Execute()
    {
        _ticSpawn--;
        if(_ticSpawn<1)
        {
            _ticSpawn = _spawnEnemyView.Time;
            SpawnEnemy();
        }
        
        foreach (var exe in _botControllers)
        {
            exe.Execute(ETypObject.Enemy);
        }
    }

    private void SpawnEnemy()
    {
        _spawnEnemyView.SetOrder();
        _spawnEnemyView.Spawn(_greedView, out _enemy);
        _enemyObjectView = _enemy.GetComponent<EnemyObjectView>();
        BotController botController = new BotController(_greedView, _enemy, _enemyObjectView.Sprite, _enemyObjectView.Speed, _enemyObjectView.CentrSpawnView, _enemyObjectView.TimePauseShoot, _enemyObjectView.SpawnShell);
        _botControllers.Add(botController);
    }
    private void GetDamage(object value)
    {
        if (_enemyObjectView.ETypObject == ETypObject.Enemy)
        {
            DestroyPlayerObject();
        }

    }
    private void DestroyPlayerObject()
    {
        _enemyObjectView.Live--;
        if (_enemyObjectView.Live < 1)
        {
            //добавить гаймовер
        }
    }
}
