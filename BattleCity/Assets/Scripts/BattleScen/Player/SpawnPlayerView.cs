using Photon.Pun;
using UnityEngine;

public class SpawnPlayerView : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private AudioSourceView _audioSourceView;

    private Vector2Int _spawnPointPlayer1 = new Vector2Int(5,1);
    private Vector2Int _spawnPointPlayer2 = new Vector2Int(9, 1);

    public GameObject Player;
    public Vector2Int SpawnPointPlayer1 => _spawnPointPlayer1;
    public Vector2Int SpawnPointPlayer2 => _spawnPointPlayer2;
    public AudioSourceView AudioSourceView => _audioSourceView;
    public SOPlayerData SOPlayerData;

    private GameObject _player2;
    public void Spawn(int point, GreedView greed)
    {
        Vector2Int pointSpawn = point==1 ? _spawnPointPlayer1 : _spawnPointPlayer2;
        if (SOPlayerData.OnePlayer)
        {
            pointSpawn = _spawnPointPlayer1;
        }
        else
        { 
            if(SOPlayerData.StartPos1)
            { pointSpawn = _spawnPointPlayer1; }
            else 
            { pointSpawn = _spawnPointPlayer2; }
        }
        Vector3 spawnPos = new Vector3
            (
            greed.LineViews[pointSpawn.y - 1].CellViews[pointSpawn.x-1].transform.position.x,
            greed.LineViews[pointSpawn.y - 1].transform.position.y,
            0
            );
        if(SOPlayerData.OnePlayer)
        {
            Player = Instantiate(_playerObject, spawnPos, Quaternion.identity);
        }
        else 
        {
            string path = $"Prefab/Player/{_playerObject.name}";
            Player = PhotonNetwork.Instantiate(path, spawnPos, Quaternion.identity);
        }
        Player.GetComponent<TanckObjectView>().PosOnGreed = new Vector2Int(pointSpawn.x - 1, pointSpawn.y - 1);
        Player.GetComponent<TanckObjectView>().Sprite[0].SetActive(true);
    }

}
