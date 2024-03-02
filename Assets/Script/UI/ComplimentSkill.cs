using TMPro;
using UnityEngine;

public class ComplimentSkill : MonoBehaviour
{
    private ChickenController chickenControll;
    [SerializeField]
    private TMP_InputField complimentText;

    void Awake()
    {
        chickenControll = FindAnyObjectByType<ChickenController>();
    }
    void OnDisable()
    {
        ClearCompliment();
    }

    public void SendCompliment()
    {
        GameManager.Instance.AddAffectionScore(Constract.Instance.compliment_score);
        CooldownManager .SaveCooldown(Constract.COMPLIMENT_COOLTIME_KEY);

        chickenControll.ChangeAnimation(ChickenAnimation.RUN);

        gameObject.SetActive(false);
    }

    private void ClearCompliment()
    {
        complimentText.text = "";
    }

}
