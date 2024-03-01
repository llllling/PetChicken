using UnityEngine;

public class AffectionSkillButtons : MonoBehaviour
{

    [SerializeField]
    private GameObject feedPrefab;
    [SerializeField]
    private GameObject complimentPanel;

    private ChickenController chickenControll;

    private const string DEFAULT_COOLTIME_MESSAGE = " 뒤에 \n사용이 가능합니다.";



    void Awake()
    {
        chickenControll = FindAnyObjectByType<ChickenController>();
    }


    public void CreateFeed()
    {
        if (!CoolTimeController.CheckCoolTime(Constract.FEED_COOLTIME_KEY, Constract.Instance.feed_cooltime_seconds))
        {
            OpenCoolTimeAlert(CoolTimeController.GetRemainedCoolTime(Constract.FEED_COOLTIME_KEY, Constract.Instance.feed_cooltime_seconds) + DEFAULT_COOLTIME_MESSAGE);
            return;
        }
        if (chickenControll.IsShowHungryChat)
        {
            chickenControll.DestroyHungryChat();
        }
        Instantiate(feedPrefab, chickenControll.transform.position + new Vector3(-2f, 0, 0), Quaternion.identity);

        gameObject.SetActive(false);
    }

    public void OpenComplimentPanel()
    {
        if (!CoolTimeController.CheckCoolTime(Constract.COMPLIMENT_COOLTIME_KEY, Constract.Instance.compliment_cooltime_seconds))
        {
            OpenCoolTimeAlert(CoolTimeController.GetRemainedCoolTime(Constract.COMPLIMENT_COOLTIME_KEY, Constract.Instance.compliment_cooltime_seconds) + DEFAULT_COOLTIME_MESSAGE);
            return;
        }

        complimentPanel.SetActive(true);

        gameObject.SetActive(false);
    }

    private void OpenCoolTimeAlert(string message)
    {
        Alert.Show(message);

        gameObject.SetActive(false);
    }

}
