using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
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
    public AudioSource audioSource;
    [SerializeField]
    private AudioClip buttonClip;
    
    [HideInInspector]
    public Constract constract;
    public bool isTurnOnSound = true;
    
    private AffectionUI affectionUI;

    [HideInInspector]
    private int affectionScore;
    public int AffectionScore => affectionScore;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            constract = FindAnyObjectByType<Constract>();
            affectionScore = PlayerPrefs.HasKey(Constract.AFFECTION_SCORE_KEY) ? PlayerPrefs.GetInt(Constract.AFFECTION_SCORE_KEY) : 0;
            if (SceneManager.GetActiveScene().name == Constract.MAIN_SCENE_NAME)
            {
                InitMainScene();
            }

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        GameManager.Instance.PlayButtonSound();

        StartCoroutine(LoadMainScene());

    }
    IEnumerator LoadMainScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Constract.MAIN_SCENE_NAME);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        InitMainScene();
    }

    public void AddAffectionScore(int score)
    {
        affectionScore += score;
        SaveAffectionScore(affectionScore);
    }

    public void SubtractAffectionScore(int score)
    {
        affectionScore = Mathf.Max(affectionScore - score, 0);
        SaveAffectionScore(affectionScore);

    }
 
    public void ResetAffectionScore()
    {
        PlayerPrefs.DeleteKey(Constract.AFFECTION_SCORE_KEY);
        SaveAffectionScore(0);
    }

    public void GameEnd()
    {
        PlayButtonSound();

        Application.Quit();
    }
    
    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonClip);
    }
    private void InitMainScene()
    {
        affectionUI = FindAnyObjectByType<AffectionUI>();
    }
    private void SaveAffectionScore(int affectionScore)
    {
        PlayerPrefs.SetInt(Constract.AFFECTION_SCORE_KEY, affectionScore);
        affectionUI.ChangeText();
    }



}
