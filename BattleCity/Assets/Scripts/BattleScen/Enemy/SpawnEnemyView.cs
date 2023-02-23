using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyView : MonoBehaviour
{
    [SerializeField] private List<GameObject> _playerObjects;
    [SerializeField] private int _maxSpavnTogether = 5;
    [SerializeField] private int[] _numTyp = new int[4] {7,7,4,2 };
    [SerializeField] private int _time = 300;
    [SerializeField] private UIBattleView _uIBattleView;
    [SerializeField] private AudioSourceView _audioSourceView;

    private Vector2Int _spawnPoint1 = new Vector2Int(1, 14);
    private Vector2Int _spawnPoint2 = new Vector2Int(7, 14);
    private Vector2Int _spawnPoint3 = new Vector2Int(13, 14);
    private List<int> _typs = new List<int>();
    private const int _maxPull = 20;
    public int MaxPull => _maxPull;
    public int MaxSpavnTogether => _maxSpavnTogether;
    public int Time => _time;

    public Vector2Int SpawnPoint1 => _spawnPoint1;
    public Vector2Int SpawnPoint2 => _spawnPoint2;
    public Vector2Int SpawnPoint3 => _spawnPoint3;
    public UIBattleView UIBattleView => _uIBattleView;
    public AudioSourceView AudioSourceView => _audioSourceView;

    private GameObject _player2;
    public void SetOrder()
    {
        int sizePull = 0;
        List<int> typeNum = new List<int>();
        foreach (var num in _numTyp)
        {
            typeNum.Add(num);
            sizePull += num;
        }
        if (sizePull < MaxPull)
        {
            _numTyp[0] += MaxPull - sizePull;
        }
        int t = 0;
        foreach (int num in _numTyp)
        {
            for (int i = 0; i < num; i++)
            {
                _typs.Add(t);
            }
            t++;
        }
    }
    public void Spawn(GreedView greed, out GameObject Enemy)
    {
        Vector2Int pointSpawn=new Vector2Int();
        switch(Random.Range(0,2))
        { 
            case 0:
                pointSpawn = _spawnPoint1;
                break;
            case 1:
                pointSpawn = _spawnPoint2;
                break;
            case 2:
                pointSpawn = _spawnPoint3;
                break;
        };
        Vector3 spawnPos = new Vector3
            (
            greed.LineViews[pointSpawn.y - 1].CellViews[pointSpawn.x - 1].transform.position.x,
            greed.LineViews[pointSpawn.y - 1].transform.position.y,
            0
            );
        int numPull = Random.Range(0, _typs.Count - 1);
        Enemy = Instantiate(_playerObjects[_typs[numPull]], spawnPos, Quaternion.identity);
        Enemy.GetComponent<TanckObjectView>().PosOnGreed = new Vector2Int(pointSpawn.x - 1, pointSpawn.y - 1);
        Enemy.GetComponent<TanckObjectView>().Sprite[2].SetActive(true);
        Enemy.GetComponent<EnemyObjectView>().UIBattleView = _uIBattleView;
        _typs.Remove(numPull);
    }
}