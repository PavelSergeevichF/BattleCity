using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    private int _idEnemy;
    private EnemyObjectView _enemyObjectView;
    private BotController _botController;
    private AudioSourceView _audioSourceView;
    public delegate void IsDeadDelegate(int value);
    public event IsDeadDelegate TransleteDead;

    public EnemyObjectView EnemyObjectView => _enemyObjectView;

    public int ID => _idEnemy;
    public bool IsActiv;

    public EnemyController(GreedView greedView, GameObject enemy, EnemyObjectView enemyObjectView, AudioSourceView audioSourceView, int idEnemy)
    {
        _enemyObjectView = enemyObjectView;
        _audioSourceView = audioSourceView;
        _idEnemy = idEnemy;
        _botController = new BotController(ETypObject.Enemy, greedView, enemy, _enemyObjectView.Sprite, _enemyObjectView.Speed, _enemyObjectView.CentrSpawnView, _enemyObjectView.TimePauseShoot, _enemyObjectView.SpawnShell, audioSourceView);
        _enemyObjectView.TransleteDamage += GetDamage;
    }

    public void Execute()
    {
        _botController.Execute();
    }


    private void GetDamage(object value)
    {
        _enemyObjectView.HP--;
        if (_enemyObjectView.HP < 1)
        {
            GetDead();
        }
        else 
        {
            _audioSourceView.AudioDamage.Play();
        }
    }
    public void GetDead()
    {
        TransleteDead?.Invoke(ID);
    }
}
