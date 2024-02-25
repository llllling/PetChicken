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


//스킬 발동이 끝난 후 부터 쿨타임 체크해야함.
// 끝난 후의 시간을 바로 저장. 
// 클릭 할 때마다 끝난 후 쿨타임에서 저장된 쿨타임만큼 지낫는지 체크해서
//발동할지 말지 결정되도록.