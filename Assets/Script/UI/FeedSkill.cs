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
        GameManager.Instance.AddAffectionScore(Constract.Instance.feed_add_score);
    }

    public void FeedAnimationEndEvent()
    {
        chickenControll.ChangeAnimation(ChickenAnimation.IDLE);
        CoolTimeController.SaveCoolTime(Constract.FEED_COOLTIME_KEY);
        Destroy(gameObject);
    }

 
}
