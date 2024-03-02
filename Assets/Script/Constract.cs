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

    public int level_white;
    public int level_yellow;
    public int level_green;
    public int level_blue;
    public int level_purple;
    public int level_red;
    public int level_black;

    public int feed_add_score;
    public int feed_subtract_score;
    public int feed_cooldown_seconds;
    public const string FEED_COOLTIME_KEY = "FEEDCOOLTIME";

    public int stroking_add_score;
    public int stroking_subtract_score;
    public int no_stroking_cooldown_seconds;
    public const string STROKING_COOLTIME_KEY = "STROKINGCOOLTIME";


    public int compliment_score;
    public int compliment_cooldown_seconds;
    public const string COMPLIMENT_COOLTIME_KEY = "COMPLIMENTCOOLTIME";

    public int hungry_cooldown_seconds;

    void Awake()
    {
        level_white = 0;  //바꿔
        level_yellow = 100;  //바꿔
        level_green = 3000;
        level_blue = 7000;
        level_purple = 16000;
        level_red = 32000;
        level_black = 64000;

        feed_add_score = 50;
        feed_subtract_score = 1000;
        feed_cooldown_seconds = 3; //바꿔
        hungry_cooldown_seconds = 10; //43200; //12시간

        stroking_add_score = 10;
        stroking_subtract_score = 50;
        no_stroking_cooldown_seconds = 5;  //바꿔

        compliment_score = 100;
        compliment_cooldown_seconds = 3;  //바꿔

    }

}