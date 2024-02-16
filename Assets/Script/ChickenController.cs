using UnityEngine;

public enum ChickenStatus
{
    IDLE,
    WALK,
    RUN,
    EAT,
    TURN_HEAD
}
public class ChickenController : MonoBehaviour
{

    [HideInInspector]
    public ChickenStatus status;

    [SerializeField]
    private float moveSpeed = 3f;

    [SerializeField]
    private float moveMinTime = 3f;
    [SerializeField]
    private float moveMaxTime = 5f;
    private float moveTime;
    private float lastTime;

    private ARTrackedManager trackedManager;
    private ChickenAnimator animator;

    private bool IsEnableMove
    {
        get => trackedManager.lastTrackedPlane.transform.position != transform.position;
    }
    void Start()
    {
        moveTime = 0f;
        lastTime = Time.time;
        status = ChickenStatus.IDLE;

        animator = GetComponent<ChickenAnimator>();
        trackedManager = GameObject.Find("XR Origin").GetComponent<ARTrackedManager>();
    }

    void Update()
    {
        if (!IsEnableMove) return;

        //if (trackedManager.lastTrackedPlane.transform.position == transform.position)
        //{
        //    Debug.Log("Idle");

        //    lastTime = Time.time;
        //    moveTime = Random.Range(moveMinTime, moveMaxTime);

        //    ChangeStatus(ChickenStatus.IDLE);
        //    return;
        //}
      
        Move();

        //ChickenStatus statusForMove = (ChickenStatus)Random.Range(1, 3);
        //ChangeStatus(statusForMove);
        //animator.ChangeAnimationByStatus(statusForMove);
    }

    private void Move()
    {
        Vector3 direction = (trackedManager.lastTrackedPlane.transform.position - transform.position).normalized;

        transform.Translate(moveSpeed * Time.deltaTime * direction);
        Debug.Log(moveSpeed * Time.deltaTime * direction + " : " + trackedManager.lastTrackedPlane.transform.position  + " / "+ transform.position);
    }

    public void ChangeStatus(ChickenStatus status)
    {
        this.status = status;
    }

}
