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

    public void ToggleMenu()
    {
        isOpenMenu = !isOpenMenu;
        menuGroup.SetActive(isOpenMenu);
    }

    public void ToggleSound()
    {
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
    public void OpenGameExitAlert()
    {
        GameObject endObj = Instantiate(gameEndAlert, FindAnyObjectByType<Canvas>().transform);
        endObj.name = "GameEnd";
    }
    public void GoIntroScene()
    {
        SceneManager.LoadScene(Constract.INTRO_SCENE_NAME);
    }

    public void OpenGameDescription() {
     transform.parent.Find("GameDescription").gameObject.SetActive(true);
    }

   
}
