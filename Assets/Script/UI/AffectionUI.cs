using TMPro;
using UnityEngine;

public class AffectionUI : MonoBehaviour
{
    [SerializeField]
    private GameObject affectionSkillAlert;
    private TMP_Text tmpText;
    void Start()
    {
        tmpText = transform.Find("Text").GetComponent<TMP_Text>();
        tmpText.text = GameManager.Instance.AffectionScore.ToString();
    }

     void Update()
    {

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0) && IsTouchCurrentObj(Input.mousePosition))
        {
            OpenAffectionSkillAlert();
        }

#endif

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && IsTouchCurrentObj(touch.position))
            {
                OpenAffectionSkillAlert();
            }
        }
#endif
    }

    public void ChangeText()
    {
        tmpText.text = GameManager.Instance.AffectionScore.ToString();
    }

    public void OpenAffectionSkillAlert()
    {
        if (affectionSkillAlert.activeSelf) return;
        affectionSkillAlert.SetActive(true);
    }

    private bool IsTouchCurrentObj(Vector3 touchPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.collider.gameObject == gameObject;
        }
        return false;
    }

}
