using UnityEngine;

public class HungryChat : MonoBehaviour
{
    private Transform chickenTransform;
    void Awake()
    {
        chickenTransform = FindAnyObjectByType<ChickenController>().transform;
    }

    void Update()
    {
        transform.localPosition = new Vector3(0f, 2f, 0f);
    }

   
}
