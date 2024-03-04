using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackedManager : MonoBehaviour
{ 
    [SerializeField]
    private GameObject chickenPrefab;

    private ARPlaneManager planeManager;
    private static List<ARPlane> planes = new ();
    private bool isCreateChicken = false;

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
        if (planes.Count > 0 && !isCreateChicken)
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
        isCreateChicken = true;
        Instantiate(chickenPrefab, planeTransform.position, planeTransform.rotation);
    }
}
