using UnityEngine;
[CreateAssetMenu(fileName = "Constract", menuName = "Scriptable/Constract", order = 1)]
public class Constract : ScriptableObject
{
    public const string PATH = "Assets/Scriptable/Constract.asset";

    public static string defaultAffectionText = "애정도";
    public const string AFFECTION_SCORE_KEY = "Affection";

    public static int level_white = 1000;
    public static int level_yellow = 2000;
    public static int level_green = 4000;
    public static int level_blue = 8000;
    public static int level_purple = 16000;
    public static int level_red = 32000;
    public static int level_black = 64000;

}