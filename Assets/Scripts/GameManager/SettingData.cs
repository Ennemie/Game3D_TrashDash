using UnityEngine;

[CreateAssetMenu(fileName = "SettingData", menuName = "Scriptable Objects/SettingData")]
public class SettingData : ScriptableObject
{
    public bool gameStart;
    public bool gameEnd;
    public float volume;
    public int fishBoneCount;
}
