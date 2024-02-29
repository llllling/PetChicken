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
      
        // ĳ������ ���� ������ ����
        Vector3 characterForward = chickenControll.transform.forward;

        // ĳ������ ��ġ�� ���� ������ ���
        Vector3 offset = characterForward * -5f + chickenControll.transform.up * 2f;

        // ĳ������ ��ġ�� �������� ����Ͽ� ī�޶� ��ġ ����
        cameraOffset.transform.position = chickenControll.transform.position;

        // ĳ���͸� �׻� �ٶ󺸵��� ī�޶� ȸ�� ����
       // transform.LookAt(chickenControll.transform);
        Debug.Log("camera.transform.position :" + cameraOffset.transform.position);
    }

  
}
