using Unity.XR.CoreUtils;
using UnityEngine;

public class ARCameraController : MonoBehaviour
{
    private Camera camera;

    void Start()
    {
        camera = GetComponent<XROrigin>().Camera;
    }

    public void EatMode(Vector3 chickenPos)
    {
        Debug.Log("chickenPos :" + chickenPos);
        Vector3 newPosition = chickenPos + new Vector3(0f, 0f, 1.5f);
        camera.transform.position = newPosition;
    }
}
