using TMPro;
using UnityEngine;

public class AffectionUI : MonoBehaviour
{
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
}
