using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.01f;
    ///<summary> �ֿ� ���� ������ ��ġ�� �̵��ϱ� ���� ��ġ �缳�� �ּ� �ð�</summary>
    [SerializeField]
    private float randomPosMinTime = 5f;
    ///<summary> �ֿ� ���� ������ ��ġ�� �̵��ϱ� ���� ��ġ �缳�� �ִ� �ð�</summary>
    [SerializeField]
    private float randomPosMaxTime = 10f;
    ///<summary> �ֿ� ���� ������ ��ġ�� �̵��ϱ� ���� ��ġ �缳�� �ð�</summary>
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
    // ���� �ð��� ������ ���� ��ġ�� �̵��Ѵ�.
    //�����ϸ� �ִϸ��̼� �����·� �ٲٰ� 

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
            Debug.Log("�ִϸ��̼� �ȴ°ŷ� ��ȯ");
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
