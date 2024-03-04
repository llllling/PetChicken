using UnityEngine;

public class HungryChat : MonoBehaviour
{
    private ChickenController chickenControll;
    private RectTransform rectTransform;

   
    void Awake()
    {
        chickenControll = FindAnyObjectByType<ChickenController>();
        rectTransform = GetComponent<RectTransform>();

    }
    void Start()
    {
        InvokeRepeating(nameof(SubstractAffectionScore), 0f, Constract.Instance.hungry_cooldown_seconds);
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
        if (IsInvoking(nameof(SubstractAffectionScore)))
        {
            CancelInvoke(nameof(SubstractAffectionScore));
        }
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

            chickenControll.ChangeChickenColor();
        }

    }
}
