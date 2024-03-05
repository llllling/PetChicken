using UnityEngine;

public class AffectionSkillAlert : MonoBehaviour
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
        GameManager.Instance.PlayButtonSound();

        if (!CooldownManager .IsCooldownElapsed(Constract.FEED_COOLTIME_KEY, Constract.Instance.feed_cooldown_seconds))
        {
            OpenCooldownAlert(CooldownManager .GetRemainedCooldown(Constract.FEED_COOLTIME_KEY, Constract.Instance.feed_cooldown_seconds) + DEFAULT_COOLTIME_MESSAGE);
            return;
        }

        Instantiate(feedPrefab, chickenControll.transform.position, Quaternion.identity, chickenControll.transform);
        
        gameObject.SetActive(false);
    }

    public void OpenComplimentAlert()
    {
        GameManager.Instance.PlayButtonSound();

        if (!CooldownManager .IsCooldownElapsed(Constract.COMPLIMENT_COOLTIME_KEY, Constract.Instance.compliment_cooldown_seconds))
        {
            OpenCooldownAlert(CooldownManager .GetRemainedCooldown(Constract.COMPLIMENT_COOLTIME_KEY, Constract.Instance.compliment_cooldown_seconds) + DEFAULT_COOLTIME_MESSAGE);
            return;
        }

        complimentAlert.SetActive(true);

        gameObject.SetActive(false);
    }

    private void OpenCooldownAlert(string message)
    {
        Alert.Show(message);

        gameObject.SetActive(false);
    }

}
