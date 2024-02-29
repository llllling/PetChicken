using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private AffectionUI affectionUI;
    
    [HideInInspector]
    private int affectionScore;
    public int AffectionScore => affectionScore;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            constract = AssetDatabase.LoadAssetAtPath<Constract>(Constract.PATH);
            affectionScore = PlayerPrefs.HasKey(Constract.AFFECTION_SCORE_KEY) ? PlayerPrefs.GetInt(Constract.AFFECTION_SCORE_KEY) : 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        StartCoroutine(LoadMainScene());

    }
    IEnumerator LoadMainScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Constract.MAIN_SCENE_NAME);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        affectionUI = GetComponent<AffectionUI>();
    }


    public void AddAffectionScore(int score)
    {
        affectionScore += score;
        SaveAffectionScore(affectionScore);
    }

    public void SubtractAffectionScore(int score)
    {
        affectionScore -= score;
        SaveAffectionScore(affectionScore);
    }
    public void ResetAffectionScore()
    {
        PlayerPrefs.DeleteKey(Constract.AFFECTION_SCORE_KEY);
        SaveAffectionScore(0);
    }

    private void SaveAffectionScore(int affectionScore)
    {
        PlayerPrefs.SetInt(Constract.AFFECTION_SCORE_KEY, affectionScore);
        affectionUI.ChangeText();
    }


}
