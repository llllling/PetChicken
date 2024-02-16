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

        // IDLE�� ��� : (����Ǵ� �ִϸ��̼� �Ķ���͸�,  false)
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
            default: //IDLE�� ���°� ����Ǿ��� ��� ���� �Ķ���͸� �Ѱ��ش�. 
                return currentParamter;
        }
    }

}
