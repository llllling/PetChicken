using TMPro;
using UnityEngine;

public class AffectionUI : MonoBehaviour
{
    [SerializeField]
    private GameObject affectionSkillAlert;
    private TMP_Text tmpText;
    void Start()
    {
        tmpText = transform.Find("Text").GetComponent<TMP_Text>();
        tmpText.text = GameManager.Instance.AffectionScore.ToString();
    }

    public void ChangeText()
    {
        tmpText.text = GameManager.Instance.AffectionScore.ToString();
    }

    public void OpenAffectionSkillAlert()
    {
        GameManager.Instance.PlayButtonSound();

        if (affectionSkillAlert.activeSelf) return;
        affectionSkillAlert.SetActive(true);
    }

}
