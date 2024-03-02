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

    void Update()
    {
        Transform chickenTransform = chickenControll.transform;
        Vector3 newPos = chickenTransform.position + transform.up * 0.6f + transform.right * 0.35f;
        transform.position = Camera.main.WorldToScreenPoint(newPos);
        ResizeUI();
    }

    void ResizeUI()
    {
        if (rectTransform == null) return;
        float x = chickenControll.Size.x * 1000;
        rectTransform.sizeDelta = new Vector2(x, x * 0.5f);

    }
}
