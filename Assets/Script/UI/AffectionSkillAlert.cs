using UnityEngine;

public class AffectionSkillAlert : MonoBehaviour
{

    [SerializeField]
    private GameObject feedPrefab;
    [SerializeField]
    private GameObject complimentAlert;

    private ChickenController chickenControll;

    private const string DEFAULT_COOLTIME_MESSAGE = " �ڿ� \n����� �����մϴ�.";



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

        Instantiate(feedPrefab, chickenControll.transform.position, Quaternion.identity, chickenControll.transform);
        
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
