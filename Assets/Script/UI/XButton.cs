using UnityEngine;

public class XButton : MonoBehaviour
{
    /// <summary>
    /// X ��ư�� Ŭ�� �� �� �������ϴ� ������Ʈ�� �� �ֻ��� ������Ʈ �̸�
    /// </summary>
    [SerializeField]
    private string rootParentName;

    private GameObject rootParent;

    void Start()
    {
        rootParent = GameObject.Find(rootParentName);
    }
    public void OnClick()
    {
        rootParent.SetActive(false);
    }
}
