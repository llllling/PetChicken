using UnityEngine;

public class AffectionSkillController : MonoBehaviour
{
    public  GameObject feedPrefab;
    private GameObject complimentPanel;
    private GameObject skillButtonGroup;

    void Start()
    {
        skillButtonGroup = transform.Find("SkillButtonGroup").gameObject;
        complimentPanel = transform.Find("Compliment").gameObject;  
    }

    void OnEnable()
    {
        if (!skillButtonGroup.activeSelf)
        {
            skillButtonGroup.SetActive(true);
        }
    }
    public void CreateFeed()
    {
        Instantiate(feedPrefab, transform);
    }

    public void FeedAnimationEndEvent()
    {
        GameManager.Instance.AddAffectionScore(Constract.feed_add_score);
        Destroy(feedPrefab);
        gameObject.SetActive(false);
    }

    public void OpenComplimentPanel()
    {
        skillButtonGroup.SetActive(false);
        complimentPanel.SetActive(true);
    }

    public void CloseComplimentPanel()
    {
        complimentPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    public void SendCompliment()
    {
        GameManager.Instance.AddAffectionScore(Constract.compliment_score);
        CloseComplimentPanel();
    }

}
