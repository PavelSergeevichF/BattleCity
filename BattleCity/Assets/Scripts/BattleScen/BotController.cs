using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController
{
    private float _speed;
    private bool _isMove;
    private GameObject _player;
    private List<GameObject> _sprite;
    private ETypObject _eTypObject;
    private GreedView _greedView;
    private MoveController _moveController;
    private FireController _fireController;
    private AudioSourceView _audioSourceView;

    public BotController(ETypObject eTypObject, GreedView greedView, GameObject player, List<GameObject> sprite, float speed, CentrSpawnView centrSpawnView, int timePauseShoot, GameObject spawnShell, AudioSourceView audioSourceView)
    {
        _eTypObject = eTypObject;
        _greedView = greedView;
        _player = player;
        _sprite = sprite;
        _speed = speed;
        _audioSourceView = audioSourceView;
        _moveController = new MoveController(_greedView, _player, _sprite, _speed);
        _fireController = new FireController(timePauseShoot, _eTypObject, _audioSourceView, centrSpawnView, spawnShell, player);
        _moveController.TransleteVectorMove += Orientation;
    }


    public void Execute()
    {
        _moveController.Execute(_eTypObject, ref _isMove);
        _fireController.Execute();
        if (_eTypObject != ETypObject.Enemy)
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
    
    public void Fire() => _fireController.Fire();
    public void Orientation(EVectorMove orientation)
    {
        _moveController.MoveObjectV2(orientation);
        _fireController.Orientation(orientation);
    }
    public void ClearSprite()
    {
        _moveController.ClearSprite();
    }
    public void DestroyObject(ETypObject eTypObject)
    {
        if (eTypObject == ETypObject.Enemy)
        {
        }
        else 
        {
            _moveController.ResetTarget();
        }
    }
}