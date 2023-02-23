using DG.Tweening;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : IFixedExecute
{
    private int _point = 1;
    private GreedView _greedView;
    private SpawnPlayerView _spawnPlayerView;
    private GameObject _player;

    private TanckObjectView _playerView;
    private BotController _botController;
    private ETypObject _playerObjectType = ETypObject.Player;
    private UIBattleView _uIBattleView;
    private UIBattleController _uIBattleController;
    private JoysticView _joysticView;
    private PhotonView _photonView;

    public PlayerController(GreedView greedView, SpawnPlayerView spawnPlayerView, UIBattleView uIBattleView, UIBattleController uIBattleController, JoysticView joysticView)
    {
        _greedView = greedView;
        _spawnPlayerView = spawnPlayerView;
        _uIBattleView = uIBattleView;
        _uIBattleController = uIBattleController;
        _joysticView = joysticView;
        SpawnPlayer();
        _botController = new BotController(_playerObjectType, _greedView, _player, _playerView.Sprite, _playerView.Speed, _playerView.CentrSpawnView, _playerView.TimePauseShoot, _playerView.SpawnShell, _spawnPlayerView.AudioSourceView);
        _playerView.TransleteDamage += GetDamage;
        _uIBattleController.TransleteFire += Fire;
    }


    public void FixedExecute()
    {
        if (_player)
        {
            if (!_uIBattleView.SOPlayerData.OnePlayer && !_photonView.IsMine) return;
            if (Input.GetKey(KeyCode.W) || _joysticView.InputVector.y > 0.1) { _botController.Orientation(EVectorMove.Up); }
            if (Input.GetKey(KeyCode.S) || _joysticView.InputVector.y < -0.1) { _botController.Orientation(EVectorMove.Down); }
            if (Input.GetKey(KeyCode.A) || _joysticView.InputVector.x < -0.1) { _botController.Orientation(EVectorMove.Left); }
            if (Input.GetKey(KeyCode.D) || _joysticView.InputVector.x > 0.1) { _botController.Orientation(EVectorMove.Right); }
            if (Input.GetKey(KeyCode.Space))
            {
                _botController.Fire();
            }
        }
        if (_spawnPlayerView.SOPlayerData.EStatusLevel == EStatusLevel.LevelEnd) { _playerView.gameObject.SetActive(false); }
        if(_spawnPlayerView.SOPlayerData.EStatusLevel == EStatusLevel.Default)
            _botController.Execute();
        if (_spawnPlayerView.SOPlayerData.EStatusLevel == EStatusLevel.GameOver)
            _playerView.gameObject.SetActive(false);
    }
    private void Fire()
    {
        _botController.Fire();
    }

    private void SpawnPlayer()
    {
        _spawnPlayerView.Spawn(_point, _greedView);
        _playerView = _spawnPlayerView.Player.GetComponent<TanckObjectView>();
        _player = _spawnPlayerView.Player;
        _playerView.HP = _spawnPlayerView.SOPlayerData.Live;
        _photonView= _player.gameObject.GetComponent<PhotonView>();
    }

    
    
    private void GetDamage(object value)
    {
        DestroyPlayerObject();
    }
    private void DestroyPlayerObject()
    {
        _playerView.HP--;
        _spawnPlayerView.SOPlayerData.Live = _playerView.HP;
        _spawnPlayerView.AudioSourceView.AudioDestroyPlayer.Play();
        if (_playerView.HP < 1)
        {
            _playerView.gameObject.SetActive(false);
            _spawnPlayerView.SOPlayerData.EStatusLevel = EStatusLevel.GameOver;
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
            _botController.DestroyObject(_playerObjectType);
            _playerView.Sprite[0].SetActive(true);
        }
    }

}
