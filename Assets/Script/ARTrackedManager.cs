using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackedManager : MonoBehaviour
{ 
    [SerializeField]
    private GameObject chickenPrefab;

    private ARPlaneManager planeManager;
    private static List<ARPlane> planes;
    public static bool IsCreateChicken { get; private set; } = false;

    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
    }

     void Start()
    {
        planes = new List<ARPlane>();
        IsCreateChicken = false;
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
        if (planes.Count > 0 && !IsCreateChicken)
        {
            CreateChicken();
        }

        foreach (var plane in changes.added)
        {
            planes.Add(plane);
        }

        foreach (var plane in changes.removed)
        {
            planes.Remove(plane);
        }
    }

    public static Transform GetRandomPlaneTransform()
    {
        return planes[Random.Range(0, planes.Count)].transform;
    }
    private void CreateChicken()
    {
        Transform planeTransform = GetRandomPlaneTransform();
        IsCreateChicken = true;
        Instantiate(chickenPrefab, planeTransform.position, planeTransform.rotation);
    }
}
