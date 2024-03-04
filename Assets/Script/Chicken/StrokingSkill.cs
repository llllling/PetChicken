using UnityEngine;

/// <summary>
/// 닭을 드래그 2번 이상 했을 경우 쓰담쓰담 스킬 발동해서 애정도 올리는 컴포넌트
/// </summary>
public class StrokingSkill : MonoBehaviour
{

    private ChickenController chickenControll;
    private readonly float dragCheckOffset = 15f;
    private int dragCount = 0;
    private Vector3 staratDragPos = Vector3.zero;
    /// <summary>
    /// 쓰담쓰담 안하는 경우 지정된 쿨다운 시간마다 점수 감소 여부 체크를 위한 프로퍼티
    /// </summary>
    private bool IsSubstractAffection => CooldownManager.IsCooldownElapsed(Constract.STROKING_COOLTIME_KEY, Constract.Instance.no_stroking_cooldown_seconds) && !IsInvoking(nameof(SubstractAffectionScore));

    void Awake()
    {
        chickenControll = GetComponent<ChickenController>();
    }

    void Update()
    {
        if (IsSubstractAffection)
        {
            InvokeRepeating(nameof(SubstractAffectionScore), 0f, Constract.Instance.no_stroking_cooldown_seconds);
        }
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            OnDragStart(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            OnDragMove(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnDragEnd();
        }
#endif

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnDragStart(touch.position);
                    break;

                case TouchPhase.Moved:
                    OnDragMove(touch.position);
                    break;

                case TouchPhase.Ended:
                    OnDragEnd();
                    break;
            }
        }
#endif

    }

    private void OnDragStart(Vector3 inputPosition)
    {
        if (!Utility.IsTouchTarget(inputPosition, gameObject)) return;

        staratDragPos = inputPosition;
    }

    private void OnDragMove(Vector3 inputPosition)
    {
        
        if (!Utility.IsTouchTarget(inputPosition, gameObject)) return;
       
        float dragDistance = Vector3.Distance(staratDragPos, inputPosition);
        if (dragDistance > dragCheckOffset) {
            staratDragPos = inputPosition;
            dragCount++;
        }

    }

    private void OnDragEnd()
    {
        if (dragCount >= 2)
        {
            ExecStrokingSkill();
        }
        dragCount = 0;
        staratDragPos = Vector3.zero;
    }

    private void ExecStrokingSkill()
    {
        CancelSubstractAffctnScore();

        chickenControll.ChangeAnimation(ChickenAnimation.TURN_HEAD);
        chickenControll.affectionPrtcl.Play();
    
        GameManager.Instance.AddAffectionScore(Constract.Instance.stroking_add_score);
        CooldownManager .SaveCooldown(Constract.STROKING_COOLTIME_KEY);

    }

    private void SubstractAffectionScore()
    {
        GameManager.Instance.SubtractAffectionScore(Constract.Instance.stroking_subtract_score);
        if (chickenControll.IsTransformation)
        {
            chickenControll.ChangeChickenColor();
        }
    }

    private void CancelSubstractAffctnScore()
    {
        if (IsInvoking(nameof(SubstractAffectionScore)))
        {
            CancelInvoke(nameof(SubstractAffectionScore));
        }

    }
}