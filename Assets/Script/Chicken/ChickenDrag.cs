using UnityEngine;

public class ChickenDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    void Update()
    {
        // 터치 입력 처리
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnTouchStart(touch.position);
                    break;

                case TouchPhase.Moved:
                    OnTouchMove(touch.position);
                    break;

                case TouchPhase.Ended:
                    OnTouchEnd();
                    break;
            }
        }
        // 마우스 입력 처리
        else if (Input.GetMouseButtonDown(0))
        {
            OnTouchStart(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            OnTouchMove(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnTouchEnd();
        }
    }

    void OnTouchStart(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            isDragging = true;
            offset = hit.transform.position - ray.origin;
        }
    }

    void OnTouchMove(Vector3 inputPosition)
    {
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(inputPosition);
            Vector3 newPosition = ray.origin + offset;
            transform.position = newPosition;
        }
    }

    void OnTouchEnd()
    {
        isDragging = false;
    }
}
