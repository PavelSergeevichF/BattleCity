using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanckObjectView : MonoBehaviour
{
    [SerializeField] private GameObject _bumperUp;
    [SerializeField] private GameObject _bumperRight;
    [SerializeField] private GameObject _bumperDown;
    [SerializeField] private GameObject _bumperLeft;
    [SerializeField] private GameObject _spawnShell;
    [SerializeField] private GameObject _centrSpawn;
    [SerializeField] private int _hp=10;
    [SerializeField] private int _damage = 1;
    [SerializeField] private int _timePauseShoot = 60;
    [SerializeField] private ETypObject _eTypObject;
    [SerializeField] private CentrSpawnView _centrSpawnView;

    public int Live = 1;

    public Vector2Int PosOnGreed;
    public List<GameObject> Sprite;
    public EVectorMove EVectorMove;
    public float Speed=1;
    public delegate void GetDamageDelegate(object value);
    public event GetDamageDelegate TransleteDamage;

    public GameObject BumperUp =>_bumperUp;
    public GameObject BumperRight => _bumperRight;
    public GameObject BumperDown => _bumperDown;
    public GameObject BumperLeft => _bumperLeft;
    public GameObject SpawnShell => _spawnShell;
    public GameObject CentrSpawn => _centrSpawn;
    public GameObject TanckObject;
    public int HP => _hp;
    public int Damage => _damage;
    public int TimePauseShoot => _timePauseShoot;

    public ETypObject ETypObject => _eTypObject;
    public CentrSpawnView CentrSpawnView =>_centrSpawnView;
    public void GetDamage()
    {
        TransleteDamage?.Invoke(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }
}
