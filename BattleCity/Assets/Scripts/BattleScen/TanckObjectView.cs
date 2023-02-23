using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanckObjectView : MonoBehaviour
{
    [SerializeField] private BumperView _bumper;
    [SerializeField] private GameObject _spawnShell;
    [SerializeField] private GameObject _centrSpawn;
    [SerializeField] private int _damage = 1;
    [SerializeField] private int _timePauseShoot = 60;
    [SerializeField] private ETypObject _eTypObject;
    [SerializeField] private CentrSpawnView _centrSpawnView;
    [SerializeField] private SOPlayerData _sOPlayerData;

    public Vector2Int PosOnGreed;
    public List<GameObject> Sprite;
    public EVectorMove EVectorMove;
    public float Speed=1;
    public delegate void GetDamageDelegate(object value);
    public event GetDamageDelegate TransleteDamage;

    public GameObject SpawnShell => _spawnShell;
    public GameObject CentrSpawn => _centrSpawn;
    public BumperView Bumper => _bumper;
    public GameObject TanckObject;
    public int HP=1;
    public int Damage => _damage;
    public int TimePauseShoot => _timePauseShoot;

    public ETypObject ETypObject => _eTypObject;
    public CentrSpawnView CentrSpawnView =>_centrSpawnView;
    public SOPlayerData SOPlayerData => _sOPlayerData;
    public void GetDamage()
    {
        TransleteDamage?.Invoke(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==13)
        {
            if(collision.gameObject.GetComponent<ShellView>().ETypObject!= _eTypObject)
            {
                GetDamage();
            }
            Destroy(collision.gameObject);
        }
    }
}
