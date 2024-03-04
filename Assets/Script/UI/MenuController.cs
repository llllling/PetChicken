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

            soundButtonImage.sprite = soundOnImage;
        } else
        {

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
        UnityEngine.XR.XRDevice.DisableAutoXRCameraTracking(Camera.main, true);
        UnityEngine.XR.XRSettings.enabled = false;

        SceneManager.LoadScene(Constract.INTRO_SCENE_NAME);
    }

    public void ToggleInfomation(bool isOpen) { }
}
