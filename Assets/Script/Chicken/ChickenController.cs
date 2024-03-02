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
    public ParticleSystem affectionPrtcl;

    private ParticleSystem transformationPrtcl;

    [SerializeField]
    private GameObject hungryPrefab;
    private GameObject hungryChat;

    private bool isShowHungryChat = false;
    public bool IsShowHungryChat => isShowHungryChat;
    private bool IsCreateHungryChat => CoolTimeController.HasPassedCoolTime(Constract.FEED_COOLTIME_KEY, Constract.Instance.hungry_cooltime_seconds, false) && !isShowHungryChat;

    public ChickenAnimation CurrentAnimation
    {
        get;
        private set;
    } = ChickenAnimation.IDLE;

    public bool IsLevelUP
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
        animationController = GetComponent<ChickenAnimatorController>();
        collider = GetComponent<Collider>();
        
        affectionPrtcl = transform.Find("AffectionParticle").gameObject.GetComponent<ParticleSystem>();
        transformationPrtcl = transform.Find("TransformParticle").gameObject.GetComponent<ParticleSystem>();
    }
    void Start()
    {
        CurrentAnimation = ChickenAnimation.IDLE;

        chickenColor = ChickenColor.ChickenColorByAffection(GameManager.Instance.AffectionScore);
        ChangeChickenBodyColor(chickenColor);
    }

    void Update()
    {
        if (IsCreateHungryChat)
        {
            isShowHungryChat = true;
            CreateHungryChat();
        }

    }
    public void ChangeAnimation(ChickenAnimation animation)
    {
        CurrentAnimation = animation;
        animationController.OnAnimation(animation);
    }


    public void LevelUP()
    {
        StartCoroutine(Transformation());
    }

    private IEnumerator Transformation()
    {
        ChickenColors chickenColor = ChickenColor.ChickenColorByAffection(GameManager.Instance.AffectionScore);
        ParticleSystem.MainModule main = transformationPrtcl.main;
        main.startColor = new ParticleSystem.MinMaxGradient(ChickenColor.ColorByChickenColors(chickenColor));
        transformationPrtcl.Play();

        yield return new WaitForSeconds(main.duration);
 
        ChangeChickenBodyColor(chickenColor);
    }


    /// <summary>
    /// �ֿϴ��� ������� ������ �°� ��ȯ��Ű�� �Լ��� ���� 1�̻��̸� ���� ������ ���� ���� ������ �߰������� ������� ��ȯ ��Ű�� �Լ�
    /// </summary>
    public void ChangeChickenBodyColor(ChickenColors chickenColor)
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

    private void CreateHungryChat()
    {
        Debug.Log("������");
        hungryChat = Instantiate(hungryPrefab, FindAnyObjectByType<Canvas>().transform);
        hungryChat.name = "HungryChat";
        GameManager.Instance.SubtractAffectionScore(Constract.Instance.feed_subtract_score);
    }
    public void DestroyHungryChat()
    {
        Destroy(hungryChat);
    }
}
