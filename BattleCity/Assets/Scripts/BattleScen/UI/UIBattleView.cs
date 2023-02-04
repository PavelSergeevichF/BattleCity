using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattleView : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyNum;
    [SerializeField] private Text _live;
    [SerializeField] private Text _level;
    [SerializeField] private Text _score;

    [SerializeField] private SOPlayerData _sOPlayerData;

    public List<GameObject> EnemyNum =>_enemyNum;
    public Text Live => _live;
    public Text Level =>_level;
    public Text Score =>_score;
    public SOPlayerData SOPlayerData => _sOPlayerData;
}
