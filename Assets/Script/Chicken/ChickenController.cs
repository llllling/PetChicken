using System;
using System.Collections;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public Renderer modelRenderer;
    public ChickenColors chickenColor;

    [HideInInspector]
    public ChickenAnimatorController animationController;
    [HideInInspector]
    public ChickenVoice voice;
    [HideInInspector]
    public ParticleSystem affectionPrtcl;

    private ParticleSystem transformationPrtcl;

    private GameObject hungryChat;

    private bool isShowHungryChat = false;
    public bool IsShowHungryChat => isShowHungryChat;
    private bool IsCreateHungryChat => CooldownManager.IsCooldownElapsed(Constract.FEED_COOLTIME_KEY, Constract.Instance.hungry_cooldown_seconds, false) && !isShowHungryChat;

    /// <summary>
    /// ���� ���� ��ȭ ����(���� ��/���� üũ)
    /// </summary>
    public bool IsTransformation
    {
        get
        {
            ChickenColors newColor = ChickenColor.ChickenColorByAffection(GameManager.Instance.AffectionScore);
            return chickenColor != newColor;
        }
    }

    private Collider collider;
    public Vector3 Size => collider.bounds.size;

    void Awake()
    {
        hungryChat = FindAnyObjectByType<Canvas>().transform.Find("HungryChat").gameObject;
    }
    void Start()
    {
        affectionPrtcl = transform.Find("AffectionParticle").gameObject.GetComponent<ParticleSystem>();
        transformationPrtcl = transform.Find("TransformParticle").gameObject.GetComponent<ParticleSystem>();
        animationController = GetComponent<ChickenAnimatorController>();
        collider = GetComponent<Collider>();
        voice = GetComponent<ChickenVoice>();
        ChangeChickenColor();
    }

    void Update()
    {
        if (IsCreateHungryChat)
        {
            isShowHungryChat = true;
            ShowHungryChat();
        }

    }

    /// <summary>
    /// �������� ���� ���� �� �� �ٲٴ� �Լ�
    /// </summary>
    public void ChangeChickenColor()
    {
        chickenColor = ChickenColor.ChickenColorByAffection(GameManager.Instance.AffectionScore);
        ChangeChickenBodyColor(chickenColor);
    }
    /// <summary>
    /// ���� ���ϸ鼭 ���� �� �� ��ȭ, ���� ��ƼŬ ����
    /// </summary>
    public void Transformation()
    {
        voice.PlayRepeating(ChickenVoiceType.TRANSFORM, 2, 0);
        StartCoroutine(TransformationCoroutine());
    }

    private IEnumerator TransformationCoroutine()
    {
        chickenColor = ChickenColor.ChickenColorByAffection(GameManager.Instance.AffectionScore);
        
        ParticleSystem.MainModule main = transformationPrtcl.main;
        main.startColor = new ParticleSystem.MinMaxGradient(ChickenColor.ColorByChickenColors(chickenColor));
        transformationPrtcl.Play();

        yield return new WaitForSeconds(main.duration);
 
        ChangeChickenBodyColor(chickenColor);
    }

    /// <summary>
    /// �ֿϴ��� ������� ������ �°� ��ȯ��Ű�� �Լ��� ���� 1�̻��̸� ���� ������ ���� ���� ������ �߰������� ������� ��ȯ ��Ű�� �Լ�
    /// </summary>
    private void ChangeChickenBodyColor(ChickenColors chickenColor)
    {
        Color endColor = ChickenColor.ColorByChickenColors(chickenColor);
        Color middleColor = endColor;

        bool isFirstLevel = chickenColor == 0;
        if (!isFirstLevel)
        {
            ChickenColors[] chickenColors = (ChickenColors[])Enum.GetValues(typeof(ChickenColors));
            ChickenColors prev = chickenColors[(int)chickenColor - 1];

            int minValue = ChickenColor.AffectionByChickenColor(prev);
            int maxValue = ChickenColor.AffectionByChickenColor(chickenColor);
            float t = Utility.CalculateRelativePosition(GameManager.Instance.AffectionScore, minValue, maxValue);
            middleColor = Color.Lerp(ChickenColor.ColorByChickenColors(prev), endColor, t);
        }

        Material newMaterial = new(modelRenderer.material)
        {
            color = middleColor
        };
        modelRenderer.material = newMaterial;
    }

    private void ShowHungryChat()
    {
        hungryChat.SetActive(true);
        hungryChat.transform.position = FindAnyObjectByType<Canvas>().transform.position;
       
    }
    public void HideHungryChat()
    {
        hungryChat.SetActive(false);
        isShowHungryChat = false;
    }
}
