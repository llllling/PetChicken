using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackedManager : MonoBehaviour
{
    [HideInInspector]
    public ARPlane lastTrackedPlane;

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
        if (changes.added.Count > 0)
        {
            CreatePrefab(changes.added[0]);
            lastTrackedPlane = changes.added[0];
        }

        if (changes.updated.Count > 0)
        {
            lastTrackedPlane = changes.updated[0];
        }
    }

    private void CreatePrefab(ARPlane trackedPlane)
    {

        if (trackedPrefab != null && chicken != null) return;

        chicken = Instantiate(trackedPrefab);
        chicken.transform.SetPositionAndRotation(trackedPlane.transform.position, trackedPlane.transform.rotation);

    }
}
