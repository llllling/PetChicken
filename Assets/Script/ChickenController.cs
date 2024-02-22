using System;
using UnityEngine;

public enum ChickenStatus
{
    IDLE,
    WALK,
    RUN,
    EAT,
    HUNGRY,
    TURN_HEAD
}

public class ChickenController : MonoBehaviour
{
    public Renderer modelRenderer;
    [HideInInspector]
    public static ChickenStatus status;
    private ChickenColors chickenColor;

    private ParticleSystem particle;
    private ParticleSystem.MainModule particleMain;

    public int affectionScore; //지워

    private GameObject affectionSkill;
    private ARCameraController cameraController;
    void Start()
    {
        status = ChickenStatus.IDLE;

        particle = transform.Find("Transformation").gameObject.GetComponent<ParticleSystem>();
        particleMain = particle.main;

        chickenColor = ChickenColor.ChickenColorByAffection(GameManager.Instance.AffectionScore);
        ChangeChickenBodyColor(chickenColor);

        affectionSkill = FindAnyObjectByType<Canvas>().transform.Find("AffectionSkills").gameObject;
        cameraController = FindAnyObjectByType<ARCameraController>();
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            OnTouch();
        }

#endif

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                OnTouch();
            }
        }
#endif
    }

    void OnValidate()
    {
        GameManager.Instance.affectionScore = affectionScore;
        Transformation();
        ChangeChickenBodyColor(chickenColor);
    }

    private void OnTouch()
    {
        cameraController.EatMode(transform.position);
        affectionSkill.SetActive(true);
    }

    private void Transformation()
    {

        chickenColor = ChickenColor.ChickenColorByAffection(GameManager.Instance.AffectionScore);
        particleMain.startColor = new ParticleSystem.MinMaxGradient(ChickenColor.ColorByChickenColors(chickenColor));
        particle.Play();

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
