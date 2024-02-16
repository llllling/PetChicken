using UnityEngine;

public class ChickenAnimator : MonoBehaviour
{
    private string currentParamter = string.Empty;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    public void ChangeAnimationByStatus(ChickenStatus status)
    {
        currentParamter = GetParamterNameByStatus(status);
        if (currentParamter == string.Empty) return;

        // IDLE일 경우 : (실행되던 애니메이션 파라미터명,  false)
        animator.SetBool(GetParamterNameByStatus(status), status != ChickenStatus.IDLE);
    }

    private string GetParamterNameByStatus(ChickenStatus status)
    {
        switch (status)
        {
            case ChickenStatus.WALK:
                return "Walk";
            case ChickenStatus.RUN:
                return "Run";
            case ChickenStatus.EAT:
                return "Eat";
            case ChickenStatus.TURN_HEAD:
                return "Turn_Head";
            default: //IDLE로 상태가 변경되었을 경우 직전 파라미터명 넘겨준다. 
                return currentParamter;
        }
    }

}
