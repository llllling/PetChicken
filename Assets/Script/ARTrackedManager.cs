using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackedManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trackedPrefab;

    private ARPlaneManager planeManager;
    private GameObject chicken;

    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();


    }
    void OnEnable()
    {
        planeManager.planesChanged += OnTrackablesChanged;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= OnTrackablesChanged;
    }

    public void OnTrackablesChanged(ARPlanesChangedEventArgs changes)
    {
        foreach (var plane in changes.added)
        {
            UpdatePlane(plane);
        }

        foreach (var plane in changes.updated)
        {
            // handle updated planes
        }

        foreach (var plane in changes.removed)
        {
            // handle removed planes
        }
    }

    private void UpdatePlane(ARPlane trackedPlane)
    {

        if (trackedPrefab != null && chicken == null)
        {
            Debug.Log(trackedPlane);

            chicken = Instantiate(trackedPrefab);
            chicken.transform.SetPositionAndRotation(trackedPlane.transform.position, trackedPlane.transform.rotation);
        }

    }
}
