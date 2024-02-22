using UnityEngine;

public class AffectionSkillController : MonoBehaviour
{
    private GameObject complimentPanel;
    private GameObject skillButtonGroup;

    void Start()
    {
        skillButtonGroup = transform.Find("SkillButtonGroup").gameObject;
        complimentPanel = transform.Find("Compliment").gameObject;  
    }

    void OnEnable()
    {
        skillButtonGroup.SetActive(true);
    }
    public void Feed()
    {
        GameManager.Instance.AddAffectionScore(Constract.feed_add_score);
    }

    public void OpenComplimentPanel()
    {
        skillButtonGroup.SetActive(false);
        complimentPanel.SetActive(true);
    }

    public void CloseComplimentPanel()
    {
        complimentPanel.SetActive(false);
    }

    public void SendCompliment()
    {
        GameManager.Instance.AddAffectionScore(Constract.compliment_score);
        CloseComplimentPanel();
    }

}
