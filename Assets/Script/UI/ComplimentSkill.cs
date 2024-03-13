using System.Collections;
using TMPro;
using UnityEngine;

public class ComplimentSkill : MonoBehaviour
{
    private ChickenController chickenControll;
    [SerializeField]
    private TMP_InputField complimentText;

    private bool IsEmptyForText => complimentText.text == "";

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

        if (IsEmptyForText)
        {
            Alert.Show("입력한 내용이 없습니다. 글자를 입력 후 전송해주세요.");
            return;
        }

        GameManager.Instance.AddAffectionScore(Constract.Instance.compliment_score);
        CooldownManager.SaveCooldown(Constract.COMPLIMENT_COOLTIME_KEY);
        StartCoroutine(ExecComplimentAnimation());
    }

    private IEnumerator ExecComplimentAnimation()
    {
        chickenControll.animationController.StartComplimentAnimaition();
        SetActiveComplimentChild(false);

        yield return new WaitForSeconds(4);

        chickenControll.animationController.EndAnimation();
        SetActiveComplimentChild(true);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 전송하기 alert창과 background 비활성화하는 함수
    /// </summary>
    private void SetActiveComplimentChild(bool active)
    {
      for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(active);
        }
    }
    private void ClearComplimentInput()
    {
        complimentText.text = "";
    }

}
