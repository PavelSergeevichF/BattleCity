
using UnityEngine;

public class EnemyObjectView : TanckObjectView
{ 
    [SerializeField] private EEnemyType _eEnemyType;
    [SerializeField] private int _score = 1;
    public EEnemyType EEnemyType => _eEnemyType;
    private int Score => _score;
}
