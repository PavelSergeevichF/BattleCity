using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellView : MonoBehaviour
{
    [SerializeField] private int _speed=400;
    [SerializeField] private GameObject _targetObject;
    [SerializeField] private float _timeDestroy = 20f;

    private ShellController _shellController;

    public int Speed => _speed;
    public ETypObject ETypObject;
    public GameObject TargetObject => _targetObject;
    void Start()
    {
        _shellController = new ShellController(this);
        Destroy(gameObject, _timeDestroy);
    }

    void Update() => _shellController.Execute();
}
