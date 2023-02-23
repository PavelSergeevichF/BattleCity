using UnityEngine;


[CreateAssetMenu(fileName = "SOGameData", menuName = "SOData/SOGameData", order = 1)]
public class SOGameData : ScriptableObject
{
    public string gameVersion = "1";
    public string PlayFabTitle = "3C46B";
    public string PlayFabId;
}
