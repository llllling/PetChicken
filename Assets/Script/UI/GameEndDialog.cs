using UnityEngine;
using UnityEngine.UI;

public class GameEndDialog : MonoBehaviour
{
    public GameObject confirmDialog; 
    public Button confirmButton; 
    public Button cancelButton;
    void Start()
    {
        confirmButton.onClick.AddListener(OnConfirmClicked);

        cancelButton.onClick.AddListener(OnCancelClicked);
    }
    void OnDestroy()
    {
        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
    }
    void OnConfirmClicked()
    {
        GameManager.Instance.GameEnd();
        confirmDialog.SetActive(false);
    }

    void OnCancelClicked()
    {
        confirmDialog.SetActive(false);
    }
}
