using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrSpawnView : MonoBehaviour
{
    [SerializeField] private GameObject _spawnShellPrefab;
    private GameObject _shell;

    
    public void Spawn(int _shellOrientationZ)
    {
        _shell = Instantiate(_spawnShellPrefab, this.transform.position, Quaternion.Euler(0, 0, _shellOrientationZ));
    }
}
