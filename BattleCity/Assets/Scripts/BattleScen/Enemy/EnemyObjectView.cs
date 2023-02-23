
using UnityEngine;

public class EnemyObjectView : TanckObjectView
{ 
    [SerializeField] private EEnemyType _eEnemyType;
    [SerializeField] private int _score = 1;
    public EEnemyType EEnemyType => _eEnemyType;
    public int Score => _score;

    public UIBattleView UIBattleView;
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
