using System;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public Renderer modelRenderer;
    [HideInInspector]
    public ChickenAnimation CurrentAnimation {
        get;
        private set;
    } = ChickenAnimation.IDLE;
    private ChickenColors chickenColor;
    [HideInInspector]
    public ChickenAnimatorController animationController;
    [HideInInspector]
    public ParticleSystem affectionPrtcl;
    private ParticleSystem transformationPrtcl;
    private GameObject affectionSkill;

    void Awake()
    {
        animationController = GetComponent<ChickenAnimatorController>();
        affectionPrtcl = transform.Find("AffectionParticle").gameObject.GetComponent<ParticleSystem>();
        transformationPrtcl = transform.Find("TransformParticle").gameObject.GetComponent<ParticleSystem>();
        affectionSkill = FindAnyObjectByType<Canvas>().transform.Find("AffectionSkills").gameObject;
    }
    void Start()
    {
        CurrentAnimation = ChickenAnimation.IDLE;

        chickenColor = ChickenColor.ChickenColorByAffection(GameManager.Instance.AffectionScore);
        ChangeChickenBodyColor(chickenColor);
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            ShowAffectionSkill();
        }

#endif

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                ShowAffectionSkill();
            }
        }
#endif
    }
    public void ChangeAnimation(ChickenAnimation animation)
    {
        CurrentAnimation = animation;
        animationController.OnAnimation(animation);
    }

    private void ShowAffectionSkill()
    {
        affectionSkill.SetActive(true);
    }

    private void Transformation()
    {

        chickenColor = ChickenColor.ChickenColorByAffection(GameManager.Instance.AffectionScore);
        ParticleSystem.MainModule main = transformationPrtcl.main;
        //  main.startColor = new ParticleSystem.MinMaxGradient(ChickenColor.ColorByChickenColors(chickenColor));
        Debug.Log("transformationPrtcl :" + transformationPrtcl);
        transformationPrtcl.Play();

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
}
