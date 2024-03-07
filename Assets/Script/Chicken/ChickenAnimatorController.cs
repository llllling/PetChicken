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
    public void ChangeAnimation(ChickenAnimation animation)
    {
        CurrentAnimation = animation;
        currentParamter = GetParamterNameByAnimation(animation);

        if (currentParamter == string.Empty) return;

        // IDLE일 경우 : (실행되던 애니메이션 파라미터명,  false)
        animator.SetBool(currentParamter, animation != ChickenAnimation.IDLE);
    }

    public void StartEatAniamtion()
    {
        ChangeAnimation(ChickenAnimation.EAT);
        chickenVoice.PlayRepeating(ChickenVoiceType.COMPLIMENT, 3f);
    }
    public void EndEatAnimation()
    {
        ChangeAnimation(ChickenAnimation.IDLE);
        chickenVoice.PlayRepeating();

        chickenControll.affectionPrtcl.Play();
        if (chickenControll.IsTransformation)
        {
            chickenControll.Transformation();
        }
    }
    public void EndRunAnimation()
    {
        ChangeAnimation(ChickenAnimation.IDLE);
        chickenControll.affectionPrtcl.Play();
        if (chickenControll.IsTransformation)
        {
            chickenControll.Transformation();
        }
    }
    public IEnumerator TurnHeadAnimaition()
    {
        ChangeAnimation(ChickenAnimation.TURN_HEAD);

        yield return new WaitForSeconds(3);

        ChangeAnimation(ChickenAnimation.IDLE);
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
