using System.Collections;
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
        ClearComplimentInput();
    }

    public void SendCompliment()
    {
        GameManager.Instance.PlayButtonSound();

        GameManager.Instance.AddAffectionScore(Constract.Instance.compliment_score);
        CooldownManager.SaveCooldown(Constract.COMPLIMENT_COOLTIME_KEY);
        StartCoroutine(ExecComplimentAnimation());
    }

    private IEnumerator ExecComplimentAnimation()
    {
        chickenControll.animationController.StartComplimentAnimaition();
        InactiveComplimentChild();

        yield return new WaitForSeconds(5);

        chickenControll.animationController.EndAnimation();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// �����ϱ� alertâ�� background ��Ȱ��ȭ�ϴ� �Լ�
    /// </summary>
    private void InactiveComplimentChild()
    {
      for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void ClearComplimentInput()
    {
        complimentText.text = "";
    }

}
