using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController
{
    private float _speed;
    private bool _isCanFire = false;
    private bool _isMove;
    private int _timePauseShoot;
    private int _setTimePauseShoot;
    private int _shellOrientationZ = 0;
    private GameObject _spawnShell;
    private GameObject _player;
    private List<GameObject> _sprite;
    private ETypObject _eTypObject;
    private GreedView _greedView;
    private CentrSpawnView _centrSpawnView;
    private MoveController _moveController;
    private AudioSourceView _audioSourceView;

    public BotController(ETypObject eTypObject, GreedView greedView, GameObject player, List<GameObject> sprite, float speed, CentrSpawnView centrSpawnView, int timePauseShoot, GameObject spawnShell, AudioSourceView audioSourceView)
    {
        _eTypObject = eTypObject;
        _greedView = greedView;
        _player = player;
        _sprite = sprite;
        _speed = speed;
        _centrSpawnView = centrSpawnView;
        _timePauseShoot = _setTimePauseShoot = timePauseShoot;
        _spawnShell = spawnShell;
        _audioSourceView = audioSourceView;
        _moveController = new MoveController(_greedView, _player, _sprite, _speed);
        _moveController.TransleteVectorMove += Orientation;
    }


    public void Execute()
    {
        _moveController.Execute(_eTypObject, ref _isMove);
        if (!_isCanFire)
        {
            if (_timePauseShoot < 1)
            {
                _isCanFire = true;
                _timePauseShoot =  _setTimePauseShoot;
            }
            else
            {
                _timePauseShoot--;
            }
        }
        if (_eTypObject == ETypObject.Enemy) Fire();
        else 
        {
            if (
                !_audioSourceView.AudioStart.isPlaying &&
                !_audioSourceView.AudioEngineGo.isPlaying &&
                !_audioSourceView.AudioEngineStop.isPlaying 
                )
            {
                if (_isMove)
                {
                    _audioSourceView.AudioEngineStop.Stop();
                    _audioSourceView.AudioEngineGo.Play();
                }
                else
                {
                    _audioSourceView.AudioEngineStop.Play();
                    _audioSourceView.AudioEngineGo.Stop();
                }
            }
        }
    }
    public void Fire() 
    {
        if (_isCanFire)
        {
            _isCanFire = false;
            SpawnShell();
            if(_eTypObject == ETypObject.Player)
            {
                _audioSourceView.AudioShoot.Play();
            }
        }
    }
    private void SpawnShell()
    {
        _centrSpawnView.Spawn(_shellOrientationZ);
    }
    public void Orientation(EVectorMove orientation)
    {
        _moveController.MoveObject(orientation);
        switch (orientation)
        {
            case EVectorMove.Up:
                _shellOrientationZ = 0;
                break;
            case EVectorMove.Down:
                _shellOrientationZ = 180;
                break;
            case EVectorMove.Left:
                _shellOrientationZ = 90;
                break;
            case EVectorMove.Right:
                _shellOrientationZ = -90;
                break;
        };
        _spawnShell.transform.rotation = Quaternion.Euler(0, 0, _shellOrientationZ);
    }
    public void ClearSprite()
    {
        _moveController.ClearSprite();
    }
}
