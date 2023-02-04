using UnityEngine;

[CreateAssetMenu(fileName = "SOPlayerData", menuName = "SOPlayer/SOPlayerData", order = 1)]
public class SOPlayerData : ScriptableObject
{
    public int Live;
    public int Level;
    public int Score;

    public float MusicVolume;
    public float SoundVolume;

    public bool AceptLicensi = false;

    public string UserName;
    public string Passvord;
}
