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


    public static void Hide()
    {
        instance.tmpText.text = "";
        instance.gameObject.SetActive(false);
    }

    public static void Show(string message)
    {
        FindAnyObjectByType<Canvas>().transform.Find("Alert").gameObject.SetActive(true);
        instance.tmpText.text = message;
    }
}
