using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Image soundButtonImage;
    [SerializeField]
    private Sprite soundOnImage;
    [SerializeField]
    private Sprite soundOffImage;
    [SerializeField]
    private GameObject gameEndAlert;

    private GameObject menuGroup;
    private bool isOpenMenu = false;
    void Awake()
    {
        menuGroup = transform.Find("MenuGroup").gameObject;
    }

    void Start()
    {
        soundButtonImage.sprite = GameManager.Instance.isTurnOnSound ? soundOnImage : soundOffImage;
    }

    public void ToggleMenu()
    {
        GameManager.Instance.PlayButtonSound();

        isOpenMenu = !isOpenMenu;
        menuGroup.SetActive(isOpenMenu);
    }

    public void ToggleSound()
    {
        GameManager.Instance.PlayButtonSound();
        
        bool isTurnOnSound = !GameManager.Instance.isTurnOnSound;
        GameManager.Instance.isTurnOnSound = isTurnOnSound;
 
        if(isTurnOnSound)
        {
            GameManager.Instance.audioSource.mute = false;
            soundButtonImage.sprite = soundOnImage;
        } else
        {
            GameManager.Instance.audioSource.mute = true;
            soundButtonImage.sprite = soundOffImage;
        }
    }

    public void StartGame()
    {
        GameManager.Instance.PlayButtonSound();

        StartCoroutine(GameManager.Instance.LoadMainScene());

    }

    public void OpenGameExitAlert()
    {
        GameManager.Instance.PlayButtonSound();

        GameObject endObj = Instantiate(gameEndAlert, FindAnyObjectByType<Canvas>().transform);
        endObj.name = "GameEnd";

    }
    public void GoIntroScene()
    {
        GameManager.Instance.PlayButtonSound();

        SceneManager.LoadScene(Constract.INTRO_SCENE_NAME);
    }

    public void OpenGameDescription() {
        GameManager.Instance.PlayButtonSound();

        transform.parent.Find("GameDescription").gameObject.SetActive(true);
    }

   
}
