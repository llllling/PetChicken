using UnityEngine;

public class HungryChat : MonoBehaviour
{
    private ChickenController chickenControll;
    private RectTransform rectTransform;

    /// <summary>
    /// ���㾲�� ���ϴ� ��� ������ ��ٿ� �ð����� ���� ���� ���� üũ�� ���� ������Ƽ
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

            Debug.Log("����� ��ٿ� ����ȭ");
            chickenControll.ChangeChickenColor();
        }
    }
}
