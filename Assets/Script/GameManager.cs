using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>();

                if (instance == null)
                {
                    GameObject managerObject = new("GameManager");
                    instance = managerObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    [HideInInspector]
    public Constract constract;

    [SerializeField]
    private TMP_Text affectionScoreTxt;

    [HideInInspector]
    public int affectionScore; //private로 나중에변경
    public int AffectionScore => affectionScore;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            constract = AssetDatabase.LoadAssetAtPath<Constract>(Constract.PATH);
            LoadAffectionScore();
            SetAffectionScoreTxt();
        }
        else
        {
            Destroy(gameObject);
        }


    }
    public void AddAffectionScore(int score)
    {
        affectionScore += score;
        SaveAffectionScore(affectionScore);
        SetAffectionScoreTxt();
    }

    public void SubtractAffectionScore(int score)
    {
        affectionScore -= score;
        SaveAffectionScore(affectionScore);
        SetAffectionScoreTxt();
    }

    private void SetAffectionScoreTxt()
    {
        affectionScoreTxt.text = affectionScore.ToString();
    }
    public void LoadAffectionScore()
    {
        affectionScore = PlayerPrefs.GetInt(Constract.AFFECTION_SCORE_KEY);
        SetAffectionScoreTxt();
    }
    private void SaveAffectionScore(int affectionScore)
    {
        PlayerPrefs.SetInt(Constract.AFFECTION_SCORE_KEY, affectionScore);
    }

    private void ResetAffectionScore()
    {
        SaveAffectionScore(0);
    }
}
