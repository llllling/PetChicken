using System.Collections;
using TMPro;
using UnityEngine;

public class AffectionSkillUI : MonoBehaviour
{
    [SerializeField]
    private GameObject alertPrefab;
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
        if (Constract.Instance.feed_cooltime_seconds <= 0)
        {
            OpenCoolTimeAlert("");
            return;
        }

        Instantiate(feedPrefab, chickenControll.transform.position + new Vector3(-2f, 0, 0) , Quaternion.identity);
        gameObject.SetActive(false);
    }
   
    public void OpenComplimentPanel()
    {
        if (Constract.Instance.compliment_cooltime_seconds <= 0)
        {
            OpenCoolTimeAlert("");
            return;
        }

        skillButtonGroup.SetActive(false);
        complimentPanel.SetActive(true);
    }

    public void CloseComplimentPanel()
    {
        complimentPanel.transform.Find("ComplimentInput").GetComponent<TMP_InputField>().text = "";
        complimentPanel.SetActive(false);
       
        skillButtonGroup.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SendCompliment()
    {
        GameManager.Instance.AddAffectionScore(Constract.Instance.compliment_score);
        chickenControll.affectionPrtcl.Play();
        StartCoroutine(ComplimentAnimation());
    }
    private IEnumerator ComplimentAnimation()
    {
        chickenControll.ChangeAnimation(ChickenAnimation.RUN);
        yield return new WaitForSeconds(2f);
        chickenControll.ChangeAnimation(ChickenAnimation.IDLE);
        CloseComplimentPanel();
    }

    private void OpenCoolTimeAlert(string message)
    {
        alertPrefab.transform.Find("Text").GetComponent<TMP_Text>().text = message;
        Instantiate(alertPrefab);
    }
}
