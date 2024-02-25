using UnityEngine;
[CreateAssetMenu(fileName = "Constract", menuName = "Scriptable/Constract", order = 1)]
public class Constract : ScriptableObject
{
    private static Constract instance;
    public static Constract Instance
    {
        get
        {
            if (instance == null)
            {
                instance = CreateInstance<Constract>();
            }
            return instance;
        }
    }
    public const string PATH = "Assets/Scriptable/Constract.asset";
    public const string INTRO_SCENE_NAME = "IntroScene";
    public const string MAIN_SCENE_NAME = "MainScene";

    public const string AFFECTION_SCORE_KEY = "Affection";

    public int level_white = 1000;
    public int level_yellow = 2000;
    public int level_green = 4000;
    public int level_blue = 8000;
    public int level_purple = 16000;
    public int level_red = 32000;
    public int level_black = 64000;

    public int feed_add_score = 50;
    public int feed_subtract_score = 1000;
    public int feed_cooltime_seconds = 14400;

    public int stroking_add_score = 10;
    public int stroking_subtract_score = 50;
    public int stroking_cooltime_seconds = 1800;

    public int compliment_score = 100;
    public int compliment_cooltime_seconds = 14400;

    void Awake()
    {
        if (instance == null)
        {
            instance = CreateInstance<Constract>();
        }
        else
        {
            Destroy(this);
        }
    }
}