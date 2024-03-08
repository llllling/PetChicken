using TMPro;
using UnityEngine;

public class AffectionUI : MonoBehaviour
{
    [SerializeField]
    private GameObject affectionSkillAlert;
    private TMP_Text affectionText;

    void Start()
    {
        affectionText = transform.Find("Text").GetComponent<TMP_Text>();
        affectionText.text = GameManager.Instance.AffectionScore.ToString();
    }

    public void ChangeText()
    {
        affectionText.text = GameManager.Instance.AffectionScore.ToString();
    }

    public void OpenAffectionSkillAlert()
    {
        GameManager.Instance.PlayButtonSound();

        if (!ARTrackedManager.IsCreateChicken)
        {
            Alert.Show("���� ȭ�鿡 �������� �ʾƼ� ����� �� �����ϴ�.");
            return;
        }

        if (affectionSkillAlert.activeSelf) return;
        affectionSkillAlert.SetActive(true);
    }

}
