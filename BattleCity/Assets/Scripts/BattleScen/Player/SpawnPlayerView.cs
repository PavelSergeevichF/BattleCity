using UnityEngine;

public class SpawnPlayerView : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;

    private Vector2Int _spawnPointPlayer1 = new Vector2Int(5,1);
    private Vector2Int _spawnPointPlayer2 = new Vector2Int(9, 1);

    public GameObject Player;
    public Vector2Int SpawnPointPlayer1 => _spawnPointPlayer1;
    public Vector2Int SpawnPointPlayer2 => _spawnPointPlayer2;

    private GameObject _player2;
    public void Spawn(int point, GreedView greed)
    {
        Vector2Int pointSpawn = point==1 ? _spawnPointPlayer1 : _spawnPointPlayer2;
        Vector3 spawnPos = new Vector3
            (
            greed.LineViews[pointSpawn.y - 1].CellViews[pointSpawn.x-1].transform.position.x,
            greed.LineViews[pointSpawn.y - 1].transform.position.y,
            0
            );
        Player = Instantiate(_playerObject, spawnPos, Quaternion.identity);
        Player.GetComponent<TanckObjectView>().PosOnGreed = new Vector2Int(pointSpawn.x - 1, pointSpawn.y - 1);
        Player.GetComponent<TanckObjectView>().Sprite[0].SetActive(true);
    }

}
