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

    private const string MAIN_SCENE_NAME = "MainScene";
    private bool isOpenMenu = false;
    private bool isOpenExitAlert = false;

    private GameObject menuGroup;

    void Awake()
    {
        menuGroup = GameObject.Find("Canvas").transform.Find("Menu").transform.Find("MenuGroup").gameObject;  
    }
    public void StartGame()
    {
        SceneManager.LoadScene(MAIN_SCENE_NAME);
    }

    public void ToggleMenu()
    {
        isOpenMenu = !isOpenMenu;
        menuGroup.SetActive(isOpenMenu);
    }

    public void ToggleSound(bool isTurnOnSound) { }
    public void OpenGameExitAlert() { }
    public void GoIntroScene() { }

    public void ToggleInfomation(bool isOpen) { }
}
