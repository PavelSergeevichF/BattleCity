using DG.Tweening;
using UnityEngine;

public class GameControllerView : MonoBehaviour
{
    [SerializeField] private GreedView _greedView;
    [SerializeField] private UIBattleView _uIBattleView;
    [SerializeField] private SpawnPlayerView _spawnPlayerView;
    [SerializeField] private SpawnEnemyView _spawnEnemyView;
    [SerializeField] private SOPlayerData _sOPlayerData;

    private Controllers _controllers;

    public GreedView GreedView => _greedView;
    public UIBattleView UIBattleView =>_uIBattleView;
    public SpawnPlayerView SpawnPlayerView => _spawnPlayerView;
    public SpawnEnemyView SpawnEnemyView => _spawnEnemyView;
    public SOPlayerData SOPlayerData => _sOPlayerData;

    private void Awake()
    {
        _controllers = new Controllers();
        new GameInit(_controllers, this);

        _controllers.Awake();

    }

    private void Start()
    {
        _controllers.Init();
    }

    private void Update()
    {
        _controllers.Execute();
    }

    private void FixedUpdate()
    {
        _controllers.FixedExecute();
    }

    private void LateUpdate()
    {
        _controllers.LateExecute();
    }

    private void OnDestroy()
    {
        _controllers.Cleanup();
        DOTween.KillAll();
    }
    public void OnDestroyBetwenLevels()
    {
        _controllers.Cleanup();
        DOTween.KillAll();
    }
}
