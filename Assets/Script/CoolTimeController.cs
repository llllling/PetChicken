using System;
using UnityEngine;

public class CoolTimeController : MonoBehaviour
{
    private DateTime feedCoolTime;
    private DateTime complimentCoolTime;
    private DateTime strokingCoolTime;

    public DateTime FeedCoolTime
    {
        get => feedCoolTime;
        set => feedCoolTime = value;
    }
    public DateTime ComplimentCoolTime
    {
        get => complimentCoolTime;
        set => complimentCoolTime = value;
    }
    public DateTime StrokingCoolTime
    {
        get => strokingCoolTime;
        set => strokingCoolTime = value;
    }

    //public bool IsUseFeedSkill
    //{
    //    get => CheckUseSkill();
    //}

    //private bool CheckUseSkill()
    //{

    //}

}


//��ų �ߵ��� ���� �� ���� ��Ÿ�� üũ�ؾ���.
// ���� ���� �ð��� �ٷ� ����. 
// Ŭ�� �� ������ ���� �� ��Ÿ�ӿ��� ����� ��Ÿ�Ӹ�ŭ �������� üũ�ؼ�
//�ߵ����� ���� �����ǵ���.