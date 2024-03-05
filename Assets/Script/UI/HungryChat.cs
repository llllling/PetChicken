using System.Collections;
using UnityEngine;

public class HungryChat : MonoBehaviour
{
    private ChickenController chickenControll;
    private RectTransform rectTransform;
    private bool isRepeatingSubstract = true;
   
    void Awake()
    {
        chickenControll = FindAnyObjectByType<ChickenController>();
        rectTransform = GetComponent<RectTransform>();

    }
    void Start()
    {
        InitForSubstractScore();
    }

    void Update()
    {
        Transform chickenTransform = chickenControll.transform;
        Vector3 newPos = chickenTransform.position + transform.up * 0.6f + transform.right * 0.35f;
        transform.position = Camera.main.WorldToScreenPoint(newPos);
        ResizeUI();
    }

    void OnDestroy()
    {
        isRepeatingSubstract = false;
    }
    private void ResizeUI()
    {
        if (rectTransform == null) return;
        float x = chickenControll.Size.x * 1000;
        rectTransform.sizeDelta = new Vector2(x, x * 0.5f);

    }

    private void SubstractAffectionScore(int score)
    {
        GameManager.Instance.SubtractAffectionScore(score);
        if (chickenControll.IsTransformation)
        {

            chickenControll.ChangeChickenColor();
        }

    }

    private void InitForSubstractScore()
    {
        int feedCoolTime = CooldownManager.GetDiffSecondsFromCurrentTime(Constract.FEED_COOLTIME_KEY);
        int numberOfSubstract = feedCoolTime / Constract.Instance.hungry_cooldown_seconds;
        int totalSubScore = Constract.Instance.feed_subtract_score * numberOfSubstract;
        Debug.Log("feedCoolTime  = " + feedCoolTime + " totabl = " + totalSubScore + " ¸î¹ø »©¾ß´ï : " + numberOfSubstract);
        SubstractAffectionScore(totalSubScore);

        StartCoroutine(RepeatingForSubstract());
    }
    private IEnumerator RepeatingForSubstract()
    {
        yield return new WaitForSeconds(Constract.Instance.hungry_cooldown_seconds);

        while (isRepeatingSubstract)
        {
            SubstractAffectionScore(Constract.Instance.feed_subtract_score);

            yield return new WaitForSeconds(Constract.Instance.hungry_cooldown_seconds);
        }
       
    }
}
