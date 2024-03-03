using UnityEngine;

public class HungryChat : MonoBehaviour
{
    private ChickenController chickenControll;
    private RectTransform rectTransform;

    /// <summary>
    /// 쓰담쓰담 안하는 경우 지정된 쿨다운 시간마다 점수 감소 여부 체크를 위한 프로퍼티
    /// </summary>
    private bool IsSubstractAffection => CooldownManager.IsCooldownMultipleElapsed(Constract.FEED_COOLTIME_KEY, Constract.Instance.hungry_cooldown_seconds);
    void Awake()
    {
        chickenControll = FindAnyObjectByType<ChickenController>();
        rectTransform = GetComponent<RectTransform>();

    }

    void Update()
    {
        if (IsSubstractAffection)
        {
            SubstractAffectionScore();
        }
        Transform chickenTransform = chickenControll.transform;
        Vector3 newPos = chickenTransform.position + transform.up * 0.6f + transform.right * 0.35f;
        transform.position = Camera.main.WorldToScreenPoint(newPos);
        ResizeUI();
    }

    private void ResizeUI()
    {
        if (rectTransform == null) return;
        float x = chickenControll.Size.x * 1000;
        rectTransform.sizeDelta = new Vector2(x, x * 0.5f);

    }

    private void SubstractAffectionScore()
    {
        GameManager.Instance.SubtractAffectionScore(Constract.Instance.feed_subtract_score);
        if (chickenControll.IsTransformation)
        {

            Debug.Log("배고프 쿨다운 색상변화");
            chickenControll.ChangeChickenColor();
        }
    }
}
