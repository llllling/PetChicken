using UnityEngine;

public class AffectionSkillUI : MonoBehaviour
{
    [SerializeField]
    private GameObject feedPrefab;
    private GameObject complimentPanel;
    private GameObject skillButtonGroup;

    private ChickenController chickenControll;

    void Awake()
    {
        skillButtonGroup = transform.Find("SkillButtonGroup").gameObject;
        complimentPanel = transform.Find("Compliment").gameObject;
        chickenControll = FindAnyObjectByType<ChickenController>();
    }

    public void CreateFeed()
    {
        Instantiate(feedPrefab, chickenControll.transform.position + new Vector3(-2f, 0, 0) , Quaternion.identity);
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
