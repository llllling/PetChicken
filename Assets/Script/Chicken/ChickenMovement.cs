using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.01f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 최소 시간</summary>
    [SerializeField]
    private float randomPosMinTime = 5f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 최대 시간</summary>
    [SerializeField]
    private float randomPosMaxTime = 10f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 시간</summary>
    private float randomPosTime;
    private float lastTime;
    private Transform target;

    private ChickenAnimatorController chickenAnimator;

    private bool isExecMoveAnimation = false;

    private bool IsArrideDestination => Vector3.Distance(target.position, transform.position) < 0.01f;
    private bool IsPassedTime => Time.time >= lastTime + randomPosTime;


    void Awake()
    {
        chickenAnimator = GetComponent<ChickenAnimatorController>();
    }
    void Start()
    {
        CreateRandomTime();
        SetRandomPosition();
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
                SetRandomPosition();
            }

            if (chickenAnimator.CurrentAnimation != ChickenAnimation.IDLE)
            {
                chickenAnimator.ChangeAnimation(ChickenAnimation.IDLE);
                isExecMoveAnimation = false;
            }

            return;
        }

        if (!isExecMoveAnimation)
        {
            Debug.Log("애니메이션 걷는거로 변환");
            isExecMoveAnimation = true;
            chickenAnimator.MoveAnimation();
        }

        Move();

    }

    private void SetRandomPosition()
    {
        target = ARTrackedManager.GetRandomPlaneTransform();
    }

    private void CreateRandomTime()
    {
        lastTime = Time.time;
        randomPosTime = Random.Range(randomPosMinTime, randomPosMaxTime);
    }

    private void Move()
    {
        Debug.Log(transform.position + " / " + target.position + " = " + (transform.position == target.position));
        transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed);
        RotateTowardsTarget();
    }

    private void RotateTowardsTarget()
    {
        Vector3 targetDirection = target.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.05f * Time.deltaTime);
    }

}
