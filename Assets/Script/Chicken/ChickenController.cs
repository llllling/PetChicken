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
    /// 닭의 색상 변화 여부(레벨 업/감소 체크)
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
    /// 애정도에 따른 닭의 몸 색 바꾸는 함수
    /// </summary>
    public void ChangeChickenColor()
    {
        chickenColor = ChickenColor.ChickenColorByAffection(GameManager.Instance.AffectionScore);
        ChangeChickenBodyColor(chickenColor);
    }
    /// <summary>
    /// 레벨 업하면서 닭의 몸 색 변화, 변신 파티클 실행
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
    /// 애완닭의 몸통색을 레벨에 맞게 변환시키는 함수로 레벨 1이상이면 이전 레벨과 다음 레벨 사이의 중간색으로 몸통색을 변환 시키는 함수
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
