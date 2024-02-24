using UnityEditor.XR.LegacyInputHelpers;
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
        chickenControll.ChangeStatus(ChickenStatus.EAT);
        transform.position = chickenControll.transform.position  + new Vector3(-0.24f, 0, 0);
    }

    void OnDestroy()
    {
        chickenControll.affectionPrtcl.Play();
        GameManager.Instance.AddAffectionScore(Constract.feed_add_score);
    }
    public void FeedAnimationEndEvent()
    {
        chickenControll.ChangeStatus(ChickenStatus.IDLE);
     
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
