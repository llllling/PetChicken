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
        transform.localPosition += transform.forward * 0.22f;
        ExecFeedSkill();
    }

    private void ExecFeedSkill()
    {
        chickenControll.animationController.StartEatAniamtion();
        GameManager.Instance.AddAffectionScore(Constract.Instance.feed_add_score);
        CooldownManager .SaveCooldown(Constract.FEED_COOLTIME_KEY);

        if (chickenControll.IsShowHungryChat)
        {
            chickenControll.HideHungryChat();
        }
    }

    public void FeedAnimationEndEvent()
    {
        chickenControll.animationController.EndAnimation();
        Destroy(gameObject);
    }

 
}
