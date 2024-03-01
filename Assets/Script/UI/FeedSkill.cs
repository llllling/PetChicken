using UnityEngine;

public class FeedSkill : MonoBehaviour
{
    private ChickenController chickenControll;

    void Awake()
    {
        chickenControll = FindAnyObjectByType<ChickenController>();

    }
    void Start()
    {
        chickenControll.ChangeAnimation(ChickenAnimation.EAT);
        transform.position = chickenControll.transform.forward + Vector3.forward * 0.24f;
        GameManager.Instance.AddAffectionScore(Constract.Instance.feed_add_score);
    }

    public void FeedAnimationEndEvent()
    {
        CoolTimeController.SaveCoolTime(Constract.FEED_COOLTIME_KEY);
        Destroy(gameObject);
    }

 
}
