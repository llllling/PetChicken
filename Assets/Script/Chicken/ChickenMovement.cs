using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.5f;
    ///<summary> �ֿ� ���� ������ ��ġ�� �̵��ϱ� ���� ��ġ �缳�� �ּ� �ð�</summary>
    [SerializeField]
    private float randomPosMinTime = 5f;
    ///<summary> �ֿ� ���� ������ ��ġ�� �̵��ϱ� ���� ��ġ �缳�� �ִ� �ð�</summary>
    [SerializeField]
    private float randomPosMaxTime = 10f;
    ///<summary> �ֿ� ���� ������ ��ġ�� �̵��ϱ� ���� ��ġ �缳�� �ð�</summary>
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

    // ���� �ð��� ������ ���� ��ġ�� �̵��Ѵ�.
    //�����ϸ� �ִϸ��̼� �����·� �ٲٰ� 
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
