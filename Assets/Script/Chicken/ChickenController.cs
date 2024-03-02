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
    
    private GameObject affectionSkillButton;
    private GameObject complimentSkill;

    [SerializeField]
    private GameObject hungryPrefab;
    private GameObject hungryChat;

    private ParticleSystem transformationPrtcl;

    private Collider collider;

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

    public Vector3 Size => collider.bounds.size;

    void Awake()
    {
        animationController = GetComponent<ChickenAnimatorController>();
        collider = GetComponent<Collider>();
        
        affectionPrtcl = transform.Find("AffectionParticle").gameObject.GetComponent<ParticleSystem>();
        transformationPrtcl = transform.Find("TransformParticle").gameObject.GetComponent<ParticleSystem>();

        Transform canvas = FindAnyObjectByType<Canvas>().transform;
        affectionSkillButton = canvas.Find("AffectionSkillButtons").gameObject;
        complimentSkill = canvas.Find("Compliment").gameObject;
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

            Debug.Log(IsCreateHungryChat);
            CreateHungryChat();
        }

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0) && IsChickenTouch(Input.mousePosition))
        {
            ShowAffectionSkill();
        }

#endif

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && IsChickenTouch(touch.position))
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
    private bool IsChickenTouch(Vector3 touchPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.collider.gameObject == gameObject;
        }
        return false;
    }
    private void ShowAffectionSkill()
    {
        if (complimentSkill.activeSelf || affectionSkillButton.activeSelf) return;
        affectionSkillButton.SetActive(true);
    }



    /// <summary>
    /// 애완닭의 몸통색을 레벨에 맞게 변환시키는 함수로 레벨 1이상이면 이전 레벨과 다음 레벨 사이의 중간색으로 몸통색을 변환 시키는 함수
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
        hungryChat = Instantiate(hungryPrefab, transform.position, Quaternion.identity, FindAnyObjectByType<Canvas>().transform);
    }
    public void DestroyHungryChat()
    {
        isShowHungryChat = false;
        Destroy(hungryChat);
    }
}
