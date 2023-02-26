using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController
{
    private bool _isCanFire = false;
    private int _timePauseShoot;
    private int _setTimePauseShoot;
    private int _shellOrientationZ = 0;
    private ETypObject _eTypObject;
    private AudioSourceView _audioSourceView;
    private CentrSpawnView _centrSpawnView;
    private GameObject _spawnShell;
    GameObject _player;

    public bool _isLife = true;

    public FireController(int setTimePauseShoot, ETypObject eTypObject, AudioSourceView audioSourceView, CentrSpawnView centrSpawnView, GameObject spawnShell, GameObject player)
    {
        _setTimePauseShoot = setTimePauseShoot;
        _eTypObject = eTypObject;
        _audioSourceView = audioSourceView;
        _centrSpawnView = centrSpawnView;
        _spawnShell = spawnShell;
        _player = player;
    }

    public void Execute()
    {
        if (!_isCanFire)
        {
            if (_timePauseShoot < 1)
            {
                _isCanFire = true;
                _timePauseShoot = _setTimePauseShoot;
            }
            else
            {
                _timePauseShoot--;
            }
        }
        if (_eTypObject == ETypObject.Enemy) Fire();
    }
    public void Fire()
    {
        if (_isCanFire && _player.GetComponent<TanckObjectView>().SOPlayerData.EStatusLevel == EStatusLevel.Default)
        {
            _isCanFire = false;
            SpawnShell();
            if (_eTypObject == ETypObject.Player)
            {
                _audioSourceView.AudioShoot.Play();
            }
        }
    }
    private void SpawnShell()
    {
        _centrSpawnView.Spawn(_shellOrientationZ, _eTypObject, this);
    }
    public void ResetTime()
    {
        _isCanFire = true;
        _timePauseShoot = _setTimePauseShoot;
    }
    public void Orientation(EVectorMove orientation)
    {
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
    }
}
