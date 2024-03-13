using System.Collections;
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
    private ChickenController chickenControll;
    private ChickenVoice chickenVoice;
    private string currentParamter = string.Empty;
    private Animator animator;
    public ChickenAnimation CurrentAnimation
    {
        get;
        private set;
    } = ChickenAnimation.IDLE;


    void Awake()
    {
        chickenVoice = GetComponent<ChickenVoice>();
        chickenControll = GetComponent<ChickenController>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        CurrentAnimation = ChickenAnimation.IDLE;
    }

    //idel => 모든걸 false 
    // 그외의 애니메이션은 true
    public void ChangeAnimation(ChickenAnimation animation)
    {
        Debug.Log("ChangeAnimation :" + CurrentAnimation + " > "+ animation.ToString() + Time.time);
        if (currentParamter != string.Empty)
        {
            animator.SetBool(currentParamter, false);
        }

        CurrentAnimation = animation;

        if (animation == ChickenAnimation.IDLE) return;

        currentParamter = GetParamterNameByAnimation(animation);
        animator.SetBool(currentParamter, true);
    }
  
    public void StartEatAniamtion()
    {
        chickenControll.status = ChickenStatus.EAT;
        ChangeAnimation(ChickenAnimation.EAT);
        chickenVoice.PlayRepeating(ChickenVoiceType.EAT, 3);
    }

    public void StartComplimentAnimaition()
    {
        chickenControll.status = ChickenStatus.COMPLIMENT;
        ChangeAnimation(ChickenAnimation.RUN);
        chickenVoice.PlayRepeating(ChickenVoiceType.COMPLIMENT, 3, 0);
    }


    public void EndAnimation()
    {
        chickenControll.status = ChickenStatus.NONE;
        ChangeAnimation(ChickenAnimation.IDLE);
        chickenVoice.PlayRepeating();

        chickenControll.affectionPrtcl.Play();
        if (chickenControll.IsTransformation)
        {
            chickenControll.Transformation();
        }
    }

    public void StartTurnHeadAnimaition()
    {
        chickenControll.status = ChickenStatus.STROKING;
        ChangeAnimation(ChickenAnimation.TURN_HEAD);
        chickenVoice.PlayRepeating(ChickenVoiceType.STROKING, 3, 0);
    }

    public void EndTurnHeadAnimation()
    {

        chickenControll.status = ChickenStatus.NONE;
        ChangeAnimation(ChickenAnimation.IDLE);
        chickenVoice.PlayRepeating();

        if (chickenControll.IsTransformation)
        {
            chickenControll.Transformation();
        }

    }

    public void MoveAnimation()
    {
        ChickenAnimation animationForMove = (ChickenAnimation)Random.Range(1, 3);
        ChangeAnimation(animationForMove);
    }

    private string GetParamterNameByAnimation(ChickenAnimation currentAnimation)
    {
        return currentAnimation switch
        {
            ChickenAnimation.WALK => "Walk",
            ChickenAnimation.RUN => "Run",
            ChickenAnimation.EAT => "Eat",
            ChickenAnimation.TURN_HEAD => "Turn Head",
            //IDLE로 상태가 변경되었을 경우 직전 파라미터명 넘겨준다. 
            _ => currentParamter,
        };
    }
   
}
