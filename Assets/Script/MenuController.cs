using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private bool isOpenMenu = false;
    private bool isOpenExitAlert = false;

    private GameObject menuGroup;
    void Start()
    {
        menuGroup = GameObject.Find("Canvas").transform.Find("Menu").transform.Find("MenuGroup").gameObject;
    }

    public void ToggleMenu()
    {
        isOpenMenu = !isOpenMenu;
        menuGroup.SetActive(isOpenMenu);
    }

    public void ToggleSound()
    {
        UIManager.Instance.isTurnOnSound = !UIManager.Instance.isTurnOnSound;
    }
    public void OpenGameExitAlert() { }
    public void GoIntroScene() {
        SceneManager.LoadScene(Constract.INTRO_SCENE_NAME);
    }

    public void ToggleInfomation(bool isOpen) { }
}
