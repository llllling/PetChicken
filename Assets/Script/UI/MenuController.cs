using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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
        //  UIManager.Instance.isTurnOnSound = !UIManager.Instance.isTurnOnSound;
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
