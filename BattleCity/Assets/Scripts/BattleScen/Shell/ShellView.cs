using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellView : MonoBehaviour
{
    [SerializeField] private int _speed=400;
    [SerializeField] private GameObject _targetObject;
    [SerializeField] private float _timeDestroy = 20f;
    [SerializeField] private AudioSourceView _audioSourceView;
    [SerializeField] private SOPlayerData _sOPlayerData;

    private ShellController _shellController;

    public AudioSourceView AudioSourceView=> _audioSourceView;
    public int Speed => _speed;
    public ETypObject ETypObject;
    public GameObject TargetObject => _targetObject;
    public SOPlayerData SOPlayerData => _sOPlayerData;

    public FireController FireController;
    void Start()
    {
        _shellController = new ShellController(this);
        Destroy(gameObject, _timeDestroy);
    }
    private void FixedUpdate() => _shellController.Execute();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 13)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.layer == 10)
        {
            _sOPlayerData.EStatusLevel = EStatusLevel.GameOver;
        }
    }
    public void Destroy()
    {
        _audioSourceView.AudioArmor.Play();
        if(ETypObject == ETypObject.Player)
        {
            FireController.ResetTime();
        }
        Destroy(this.gameObject);
    }

}
