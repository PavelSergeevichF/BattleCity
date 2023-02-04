using DG.Tweening;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : IExecute
{
    private int _point = 1;
    private GreedView _greedView;
    private SpawnPlayerView _spawnPlayerView;
    private GameObject _player;

    private TanckObjectView _playerView;
    private BotController _botController;

    public PlayerController(GreedView greedView, SpawnPlayerView spawnPlayerView)
    {
        _greedView = greedView;
        _spawnPlayerView = spawnPlayerView;
        SpawnPlayer();
        _botController = new BotController(_greedView, _player, _playerView.Sprite, _playerView.Speed, _playerView.CentrSpawnView, _playerView.TimePauseShoot, _playerView.SpawnShell);
        _playerView.TransleteDamage += GetDamage;
    }

    public void Execute()
    {
        if (Input.GetKey(KeyCode.W)) { _botController.Orientation(EVectorMove.Up);}
        if (Input.GetKey(KeyCode.S)) { _botController.Orientation(EVectorMove.Down);}
        if (Input.GetKey(KeyCode.A)) { _botController.Orientation(EVectorMove.Left);}
        if (Input.GetKey(KeyCode.D)) { _botController.Orientation(EVectorMove.Right);}
        if (Input.GetKey(KeyCode.Space)) 
        {
            _botController.Fire();
        }
        
        _botController.Execute(ETypObject.Player);
    }

    private void SpawnPlayer()
    {
        _spawnPlayerView.Spawn(_point, _greedView);
        _playerView = _spawnPlayerView.Player.GetComponent<TanckObjectView>();
        _player = _spawnPlayerView.Player;
    }

    
    
    private void GetDamage(object value)
    {
        if(_playerView.ETypObject== ETypObject.Player)
        {
            DestroyPlayerObject();
        }
        
    }
    private void DestroyPlayerObject()
    {
        _playerView.Live--;
        if (_playerView.Live < 1)
        { 
            //добавить гаймовер
        }
        else 
        {
            Vector2Int pointSpawn = _point == 1 ? _spawnPlayerView.SpawnPointPlayer1 : _spawnPlayerView.SpawnPointPlayer2;
            Vector3 spawnPos = new Vector3
                (
                _greedView.LineViews[pointSpawn.y - 1].CellViews[pointSpawn.x - 1].transform.position.x,
                _greedView.LineViews[pointSpawn.y - 1].transform.position.y,
                0
                );
            _player.transform.position = spawnPos;
            _botController.ClearSprite();
            _playerView.Sprite[0].SetActive(true);
        }
    }
}
