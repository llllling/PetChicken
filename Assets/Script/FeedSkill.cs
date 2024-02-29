using UnityEngine;

public class FeedSkill : MonoBehaviour
{
    private ChickenController chickenControll;
    private GameObject cameraOffset;

    void Awake()
    {
        cameraOffset = GameObject.Find("Camera Offset");
        chickenControll = FindAnyObjectByType<ChickenController>();
    }
    void Start()
    {
       // CameraEatMode();
        chickenControll.ChangeAnimation(ChickenAnimation.EAT);
        transform.position = chickenControll.transform.position  + new Vector3(-0.24f, 0, 0);
    }

    void OnDestroy()
    {
        chickenControll.affectionPrtcl.Play();
        GameManager.Instance.AddAffectionScore(Constract.Instance.feed_add_score);
    }
    public void FeedAnimationEndEvent()
    {
        if (chickenControll.IsLevelUP)
        {
            chickenControll.LevelUP();
        }
        chickenControll.ChangeAnimation(ChickenAnimation.IDLE);
        CoolTimeController.SaveCoolTime(Constract.FEED_COOLTIME_KEY);
        // cameraOffset.transform.position = Vector3.zero;
        Destroy(gameObject);
    }

    public void CameraEatMode()
    {
        Debug.Log("EatMode chickenPos :" + chickenControll.transform.position);
      
        // 캐릭터의 정면 방향을 얻어옴
        Vector3 characterForward = chickenControll.transform.forward;

        // 캐릭터의 위치에 대한 오프셋 계산
        Vector3 offset = characterForward * -5f + chickenControll.transform.up * 2f;

        // 캐릭터의 위치와 오프셋을 사용하여 카메라 위치 설정
        cameraOffset.transform.position = chickenControll.transform.position;

        // 캐릭터를 항상 바라보도록 카메라 회전 설정
       // transform.LookAt(chickenControll.transform);
        Debug.Log("camera.transform.position :" + cameraOffset.transform.position);
    }

  
}
