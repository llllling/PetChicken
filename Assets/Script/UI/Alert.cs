using TMPro;
using UnityEngine;

public class Alert : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tmpText;
    private static Alert instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDisable()
    {
        instance.tmpText.text = "";

    }

    public static void Show(string message)
    {
        GameManager.Instance.PlayButtonSound();

        FindAnyObjectByType<Canvas>().transform.Find("Alert").gameObject.SetActive(true);
        instance.tmpText.text = message;
    }
}
