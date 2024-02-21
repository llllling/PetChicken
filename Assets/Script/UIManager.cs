using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    const string MAIN_SCENE_NAME = "MainScene";
    public void StartGame()
    {
        SceneManager.LoadScene(MAIN_SCENE_NAME);
    }
}
