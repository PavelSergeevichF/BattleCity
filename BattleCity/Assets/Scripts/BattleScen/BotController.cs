using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController
{
    private GreedView _greedView;
    private GameObject _player;
    private List<GameObject> _sprite;
    private float _speed;
    private bool _isCanFire = false;
    private int _timePauseShoot;
    private int _setTimePauseShoot;

    private int _shellOrientationZ = 0;
    private CentrSpawnView _centrSpawnView;
    private MoveController _moveController;
    private GameObject _spawnShell;

    public BotController(GreedView greedView, GameObject player, List<GameObject> sprite, float speed, CentrSpawnView centrSpawnView, int timePauseShoot, GameObject spawnShell)
    {
        _greedView = greedView;
        _player = player;
        _sprite = sprite;
        _speed = speed;
        _centrSpawnView = centrSpawnView;
        _timePauseShoot = _setTimePauseShoot = timePauseShoot;
        _spawnShell = spawnShell;
        _moveController = new MoveController(_greedView, _player, _sprite, _speed);
        _moveController.TransleteVectorMove += Orientation;
    }


    public void Execute(ETypObject eTypObject)
    {
        _moveController.Execute(eTypObject);
        if (!_isCanFire)
        {
            if (_timePauseShoot < 1)
            {
                _isCanFire = true;
                _timePauseShoot = eTypObject == ETypObject.Player ? _setTimePauseShoot : _setTimePauseShoot;
            }
            else
            {
                _timePauseShoot--;
            }
        }
        if (eTypObject == ETypObject.Enemy) Fire();
    }
    public void Fire() 
    {
        if (_isCanFire)
        {
            _isCanFire = false;
            SpawnShell();
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
