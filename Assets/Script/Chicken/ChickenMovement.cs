using TMPro;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 0.4f;
    [SerializeField]
    private float runSpeed = 0.8f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 최소 시간</summary>
    [SerializeField]
    private float randomPosMinTime = 5f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 최대 시간</summary>
    [SerializeField]
    private float randomPosMaxTime = 10f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 시간</summary>
    private float randomPosTime;
    private float lastTime;

    private float moveSpeed;
    private Vector3 targetPosition;
    private Vector3 initRotation;
    
    private ChickenController chickenControll;
    private ChickenAnimatorController chickenAnimator;

    private bool isMoveStatus = false;
    private bool IsUsingSkill => chickenControll.status != ChickenStatus.NONE;
    private bool IsArrideDestination => Vector3.Distance(targetPosition, transform.position) < 0.1f;
    private bool IsPassedTime => Time.time >= lastTime + randomPosTime;
    private Vector3 DirectionTowardTarget => (targetPosition - transform.position).normalized;


    void Awake()
    {
        chickenControll = GetComponent<ChickenController>();
        chickenAnimator = GetComponent<ChickenAnimatorController>();
    }
    void Start()
    {
        CreateRandomTime();
        targetPosition = transform.position;


        Vector3 direction = (Camera.main.transform.position - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction); //방향 벡터를 회전에 필요한 쿼터니언으로 변환
            transform.rotation = Quaternion.Euler(0f, rotation.eulerAngles.y, 0f);
        }
        initRotation = transform.rotation.eulerAngles;
    }

    // 일정 시간이 지나면 랜덤 위치로 이동한다.
    //도착하면 애니메이션 대기상태로 바꾸고 
    void Update()
    {
        if (IsUsingSkill)
        {
            if (isMoveStatus)
            {
                targetPosition = transform.position;
                isMoveStatus = false;
                SetInitRotation();
            }

            lastTime = Time.time;
            return;
        }
        
        if (IsArrideDestination)
        {
            if (IsPassedTime)
            {
                CreateRandomTime();
                ReSetRandomPosition();
            }
            if (isMoveStatus)
            {
                isMoveStatus = false;
                SetInitRotation();
                chickenAnimator.ChangeAnimation(ChickenAnimation.IDLE);
            }
        }
        else
        {

            if (!isMoveStatus)
            {
                isMoveStatus = true;
                chickenAnimator.MoveAnimation();
                moveSpeed = chickenAnimator.CurrentAnimation == ChickenAnimation.WALK ? walkSpeed : runSpeed;
                Rotate();
            }

            Move();
        }
    }

    private void ReSetRandomPosition()
    {
        Transform newTarget = ARTrackedManager.GetRandomPlaneTransform();
        if (Vector3.Distance(transform.position, newTarget.position) > 1)
        {
            targetPosition = newTarget.position;
        }
    }

    private void CreateRandomTime()
    {
        lastTime = Time.time;
        randomPosTime = Random.Range(randomPosMinTime, randomPosMaxTime);
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.LookRotation(DirectionTowardTarget);
    }

    private void Move()
    {
        transform.position += (moveSpeed * Time.deltaTime * DirectionTowardTarget);
    }

    private void SetInitRotation()
    {
        transform.rotation = Quaternion.Euler(initRotation);
    }
}
