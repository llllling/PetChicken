using TMPro;
using UnityEngine;

public class Alert : MonoBehaviour
{
    private TMP_Text textComponent;

    void Start()
    {
        textComponent = transform.Find("Text").GetComponent<TMP_Text>(); 
    }
    public void Close()
    {
        Destroy(gameObject);
    }

    public void OpenAlert(string message)
    {
        textComponent.text = message;
        gameObject.SetActive(true);
    }
}
