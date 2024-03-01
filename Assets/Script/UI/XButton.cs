using UnityEngine;

public class XButton : MonoBehaviour
{
    /// <summary>
    /// X 버튼이 클릭 될 때 닫혀야하는 오브젝트들 중 최상위 오브젝트 이름
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
