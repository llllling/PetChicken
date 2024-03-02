using UnityEngine;

/// <summary>
/// 치킨을 드래그 2번 이상 했을 경우 쓰담쓰담 스킬 발동해서 애정도 올리는 컴포넌트
/// </summary>
public class StrokingSkill : MonoBehaviour
{
    private ChickenController chickenControll;
    private readonly float dragCheckOffset = 15f;
    private int dragCount = 0;
    private Vector3 staratDragPos = Vector3.zero;

    private bool IsNoStroking => CoolTimeController.HasPassedCoolTime(Constract.STROKING_COOLTIME_KEY, Constract.Instance.no_stroking_cooltime_seconds, false);

    void Awake()
    {
        chickenControll = GetComponent<ChickenController>();
    }

    void Update()
    {
        if (IsNoStroking)
        {
            NoStroking();
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
        chickenControll.ChangeAnimation(ChickenAnimation.TURN_HEAD);
        chickenControll.affectionPrtcl.Play();
        GameManager.Instance.AddAffectionScore(Constract.Instance.stroking_add_score);
        CoolTimeController.SaveCoolTime(Constract.STROKING_COOLTIME_KEY);
    }

    private void NoStroking()
    {
        GameManager.Instance.SubtractAffectionScore(Constract.Instance.stroking_subtract_score);
    }
}