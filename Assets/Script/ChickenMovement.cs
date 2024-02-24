using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.01f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 쿨타임 최소 시간</summary>
    [SerializeField]
    private float randomPosMinTime = 5f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 쿨타임 최대 시간</summary>
    [SerializeField]
    private float randomPosMaxTime = 10f;
    ///<summary> 애완 닭이 랜덤의 위치로 이동하기 위해 위치 재설정 쿨타임 시간</summary>
    private float randomPosTime;
    private float lastTime;
    private Transform target;

    private ARTrackedManager trackedManager;

    private ChickenController chickenController;

    private bool IsArrideDestination => Vector3.Distance(target.position, transform.position) < 0.01f;

    private bool IsResetTarget => Time.time >= lastTime + randomPosTime;
    private bool isMoving = false;

    void Awake()
    {
        chickenController = GetComponent<ChickenController>();
        trackedManager = GameObject.Find("XR Origin").GetComponent<ARTrackedManager>();
    }
    void Start()
    {
        CreateRandomMoveTime();
        target = trackedManager.lastTrackedPlane.transform;
    }

    void Update()
    {
        if (target == null) return;

        if (IsArrideDestination)
        {
            // 목적지에 도착했다면 일정 시간이 지난 후 목적지 재설정.
            if (chickenController.Status != ChickenStatus.IDLE)
            {
                chickenController.ChangeStatus(ChickenStatus.IDLE);
                isMoving = false;

                Debug.Log("IDLE");
                return;
            }

            if (IsResetTarget)
            {
                target = trackedManager.lastTrackedPlane.transform;
                CreateRandomMoveTime();
                Debug.Log("IsResetTarget");
            }
            return;
        }

        Move();
        if (!isMoving)
        {
            ChickenStatus statusForMove = (ChickenStatus)Random.Range(1, 3);
            if (statusForMove == ChickenStatus.RUN) { moveSpeed += 0.02f; }
            chickenController.ChangeStatus(statusForMove);
            isMoving = true;
            Debug.Log("isMoving");

        }
    }

    private void CreateRandomMoveTime()
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
