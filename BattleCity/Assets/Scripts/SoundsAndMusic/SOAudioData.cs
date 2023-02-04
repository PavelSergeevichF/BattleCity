using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOAudioData", menuName = "SOAudio/SOAudioData", order = 1)]
public class SOAudioData : ScriptableObject
{
    public AudioSource AudioStart;
    public AudioSource AudioEngineStop;
    public AudioSource AudioEngineGo;
    public AudioSource AudioShoot;
    public AudioSource AudioDamage;
    public AudioSource AudioArmor;
    public AudioSource AudioDestroyPlayer;
    public AudioSource AudioDestroyEnemy;
    public AudioSource AudioGameOver;
    public AudioSource AudioBonus;
    public AudioSource AudioCount;
    public AudioSource AudioGetBonus1;
    public AudioSource AudioGetBonus2;
    public AudioSource AudioGetBonus3; 
    public AudioSource AudioGetBonus4;
}
