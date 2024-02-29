using System.Collections;
using TMPro;
using UnityEngine;

public class AffectionSkillUI : MonoBehaviour
{
  
    [SerializeField]
    private GameObject feedPrefab;
    
    private GameObject complimentPanel;
    private GameObject skillButtonGroup;

    private ChickenController chickenControll;

    private const string DEFAULT_COOLTIME_MESSAGE = " 뒤에 \n사용이 가능합니다.";



    void Awake()
    {
        skillButtonGroup = transform.Find("SkillButtonGroup").gameObject;
        complimentPanel = transform.Find("Compliment").gameObject;
        chickenControll = FindAnyObjectByType<ChickenController>();
    }


    public void CreateFeed()
    {
        if (!CoolTimeController.CheckCoolTime(Constract.FEED_COOLTIME_KEY,Constract.Instance.feed_cooltime_seconds))
        {
            OpenCoolTimeAlert(CoolTimeController.GetRemainedCoolTime(Constract.FEED_COOLTIME_KEY, Constract.Instance.feed_cooltime_seconds) + DEFAULT_COOLTIME_MESSAGE);
            return;
        }
        chickenControll.DestroyHungryChat();
        Instantiate(feedPrefab, chickenControll.transform.position + new Vector3(-2f, 0, 0) , Quaternion.identity);
        gameObject.SetActive(false);
    }
   
    public void OpenComplimentPanel()
    {
        if (!CoolTimeController.CheckCoolTime(Constract.COMPLIMENT_COOLTIME_KEY, Constract.Instance.compliment_cooltime_seconds))
        {
            OpenCoolTimeAlert(CoolTimeController.GetRemainedCoolTime(Constract.COMPLIMENT_COOLTIME_KEY, Constract.Instance.compliment_cooltime_seconds) + DEFAULT_COOLTIME_MESSAGE);
            return;
        }

        skillButtonGroup.SetActive(false);
        complimentPanel.SetActive(true);
    }

    public void CloseComplimentPanel()
    {
        ClearCompliment();
        gameObject.SetActive(false);
    }

    public void SendCompliment()
    {
        ClearCompliment();
        GameManager.Instance.AddAffectionScore(Constract.Instance.compliment_score);
        chickenControll.affectionPrtcl.Play();

        CoolTimeController.SaveCoolTime(Constract.COMPLIMENT_COOLTIME_KEY);
        StartCoroutine(ComplimentAnimation());
    }

    private void ClearCompliment()
    {
        complimentPanel.transform.Find("ComplimentInput").GetComponent<TMP_InputField>().text = "";
        complimentPanel.SetActive(false);

        skillButtonGroup.SetActive(true);
    }
    private IEnumerator ComplimentAnimation()
    {
        chickenControll.ChangeAnimation(ChickenAnimation.RUN);
        yield return new WaitForSeconds(2f);
        chickenControll.ChangeAnimation(ChickenAnimation.IDLE);
        if (chickenControll.IsLevelUP)
        {
            chickenControll.LevelUP();
        }
        gameObject.SetActive(false);
    }

    private void OpenCoolTimeAlert(string message)
    {
        Alert.Show(message);
        gameObject.SetActive(false);
    }

}
