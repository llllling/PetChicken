using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<UIManager>();

                if (instance == null)
                {
                    GameObject managerObject = new("UIManager");
                    instance = managerObject.AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }
    [HideInInspector]
    public bool isTurnOnSound = true;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(Constract.MAIN_SCENE_NAME);
    }

}
