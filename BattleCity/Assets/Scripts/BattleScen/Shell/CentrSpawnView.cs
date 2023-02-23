using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrSpawnView : MonoBehaviour
{
    [SerializeField] private GameObject _spawnShellPrefab;
    private GameObject _shell;

    
    public void Spawn(int _shellOrientationZ, ETypObject eTypObject, FireController fireController)
    {
        _shell = Instantiate(_spawnShellPrefab, this.transform.position, Quaternion.Euler(0, 0, _shellOrientationZ));
        _shell.GetComponent<ShellView>().ETypObject = eTypObject;
        _shell.GetComponent<ShellView>().FireController = fireController;
    }
}
