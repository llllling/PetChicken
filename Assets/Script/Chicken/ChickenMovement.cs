using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.5f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 최소 시간</summary>
    [SerializeField]
    private float randomPosMinTime = 5f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 최대 시간</summary>
    [SerializeField]
    private float randomPosMaxTime = 10f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 시간</summary>
    private float randomPosTime;
    private float lastTime;

    private Vector3 targetPosition;

    private ChickenAnimatorController chickenAnimator;

    private bool isExecMoveAnimation = false;

    private bool IsArrideDestination => Vector3.Distance(targetPosition, transform.position) < 0.1f;
    private bool IsPassedTime => Time.time >= lastTime + randomPosTime;
    private Vector3 DirectionTowardTarget => (targetPosition - transform.position).normalized;


    void Awake()
    {
        chickenAnimator = GetComponent<ChickenAnimatorController>();
    }
    void Start()
    {
        CreateRandomTime();
        targetPosition = transform.position;
    }

    // 일정 시간이 지나면 랜덤 위치로 이동한다.
    //도착하면 애니메이션 대기상태로 바꾸고 
    void Update()
    {
        if (IsArrideDestination)
        {
            if (IsPassedTime)
            {
                CreateRandomTime();
                ReSetRandomPosition();
            }

            if (isExecMoveAnimation)
            {
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
                if (chickenAnimator.CurrentAnimation == ChickenAnimation.RUN)
                {
                    moveSpeed *= 2;
                }
                Rotate();

                return;
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
}
