using UnityEngine;
using UnityEngine.EventSystems;

public class ChickenDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    void Start()
    {
        Debug.Log("ChickenDrag Start");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }
}
