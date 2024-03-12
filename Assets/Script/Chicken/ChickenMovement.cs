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
    
    private ChickenAnimatorController chickenAnimator;

    private bool isExecMoveAnimation = false;

    private bool IsArrideDestination => Vector3.Distance(targetPosition, transform.position) < 0.1f;
    private bool IsPassedTime => Time.time >= lastTime + randomPosTime;
    private Vector3 DirectionTowardTarget => (targetPosition - transform.position).normalized;
    private bool IsEnableMove => !(chickenAnimator.CurrentAnimation == ChickenAnimation.EAT || chickenAnimator.CurrentAnimation == ChickenAnimation.TURN_HEAD);


    void Awake()
    {
        chickenAnimator = GetComponent<ChickenAnimatorController>();
    }
    void Start()
    {
        CreateRandomTime();
        targetPosition = transform.position;
        initRotation = transform.rotation.eulerAngles;
    }

    // 일정 시간이 지나면 랜덤 위치로 이동한다.
    //도착하면 애니메이션 대기상태로 바꾸고 
    void Update()
    {
        if (!IsEnableMove) return;

        if (IsArrideDestination)
        {
            if (IsPassedTime)
            {
                CreateRandomTime();
                ReSetRandomPosition();
            }

            if (isExecMoveAnimation)
            {
                SetInitRotation();
                chickenAnimator.ChangeAnimation(ChickenAnimation.IDLE);
                isExecMoveAnimation = false;
            }
        }
        else
        {

            if (!isExecMoveAnimation)
            {
                isExecMoveAnimation = true;
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
