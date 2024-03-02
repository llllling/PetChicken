using UnityEngine;

public class AffectionSkillButtons : MonoBehaviour
{

    [SerializeField]
    private GameObject feedPrefab;
    [SerializeField]
    private GameObject complimentAlert;

    private ChickenController chickenControll;

    private const string DEFAULT_COOLTIME_MESSAGE = " 뒤에 \n사용이 가능합니다.";



    void Awake()
    {
        chickenControll = FindAnyObjectByType<ChickenController>();
    }


    public void CreateFeed()
    {
        if (!CoolTimeController.HasPassedCoolTime(Constract.FEED_COOLTIME_KEY, Constract.Instance.feed_cooltime_seconds))
        {
            OpenCoolTimeAlert(CoolTimeController.GetRemainedCoolTime(Constract.FEED_COOLTIME_KEY, Constract.Instance.feed_cooltime_seconds) + DEFAULT_COOLTIME_MESSAGE);
            return;
        }
        if (chickenControll.IsShowHungryChat)
        {
            chickenControll.DestroyHungryChat();
        }
        GameObject feed = Instantiate(feedPrefab, chickenControll.transform.position + transform.forward * 0.2f, Quaternion.identity, chickenControll.transform);
        feed.transform.localPosition += chickenControll.transform.forward * 0.2f;
        gameObject.SetActive(false);
    }

    public void OpenComplimentAlert()
    {
        if (!CoolTimeController.HasPassedCoolTime(Constract.COMPLIMENT_COOLTIME_KEY, Constract.Instance.compliment_cooltime_seconds))
        {
            OpenCoolTimeAlert(CoolTimeController.GetRemainedCoolTime(Constract.COMPLIMENT_COOLTIME_KEY, Constract.Instance.compliment_cooltime_seconds) + DEFAULT_COOLTIME_MESSAGE);
            return;
        }

        complimentAlert.SetActive(true);

        gameObject.SetActive(false);
    }

    private void OpenCoolTimeAlert(string message)
    {
        Alert.Show(message);

        gameObject.SetActive(false);
    }

}
