using UnityEngine;
[CreateAssetMenu(fileName = "Constract", menuName = "Scriptable/Constract", order = 1)]
public class Constract : ScriptableObject
{
    public const string PATH = "Assets/Scriptable/Constract.asset";

    public string defaultAffectionText = "애정도";
    public const string AFFECTION_SCORE_KEY = "Affection";

}