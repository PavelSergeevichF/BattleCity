using UnityEngine;
using UnityEngine.Networking;

[CreateAssetMenu(fileName = "SOPlayerData", menuName = "SOPlayer/SOPlayerData", order = 1)]
public class SOPlayerData : ScriptableObject
{
    public int Live;
    public int Level;
    public int Score;
    public int RecordScore;

    public float MusicVolume;
    public float SoundVolume;

    public string UserName;
    public string Password;

    public int[] DestroyEnemyOnType = new int[4];
    public int DeadEnemy;

    public EStatusLevel EStatusLevel = EStatusLevel.Default;
    public bool OnePlayer = true;
    public bool StartPos1 = true;
}
