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
    public static ChickenStatus status;

    void Start()
    {
        status = ChickenStatus.IDLE;
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        Debug.Log(Input.GetMouseButtonDown(0));
        if (Input.GetMouseButtonDown(0))
        {
            OnTouch();
        }

#endif

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                OnTouch();
            }
        }
#endif
    }

    private void OnTouch()
    {
        Debug.Log("터치터치");
        GameManager.Instance.AddAffectionScore(10);
    }

}
