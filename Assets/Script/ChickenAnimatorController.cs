using UnityEngine;


public enum ChickenAnimation
{
    IDLE,
    WALK,
    RUN,
    EAT,
    TURN_HEAD
}

public class ChickenAnimatorController : MonoBehaviour
{
    private string currentParamter = string.Empty;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

   
    public void OnAnimation(ChickenAnimation currentAnimation)
    {
        currentParamter = GetParamterNameByAnimation(currentAnimation);
        if (currentParamter == string.Empty) return;

        // IDLE�� ��� : (����Ǵ� �ִϸ��̼� �Ķ���͸�,  false)
        animator.SetBool(GetParamterNameByAnimation(currentAnimation), currentAnimation != ChickenAnimation.IDLE);
    }

    private string GetParamterNameByAnimation(ChickenAnimation currentAnimation)
    {
        return currentAnimation switch
        {
            ChickenAnimation.WALK => "Walk",
            ChickenAnimation.RUN => "Run",
            ChickenAnimation.EAT => "Eat",
            ChickenAnimation.TURN_HEAD => "Turn_Head",
            //IDLE�� ���°� ����Ǿ��� ��� ���� �Ķ���͸� �Ѱ��ش�. 
            _ => currentParamter,
        };
    }

}
