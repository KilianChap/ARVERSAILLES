using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ModelSpawn : MonoBehaviour
{
    public List<GameObject> modelList = new List<GameObject>();
    public GameObject GareSpawn;
    public GameObject MairieSpawn;

    private Dictionary<string, GameObject> spawnedModels = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    void Awake()
    {
        trackedImageManager = FindFirstObjectByType<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackablesChanged.AddListener(OnTrackablesChanged);
    }

    void OnDisable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackablesChanged.RemoveListener(OnTrackablesChanged);
    }

    private void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            string imageName = trackedImage.referenceImage.name;

            if (!spawnedModels.ContainsKey(imageName))
            {
                foreach (var model in modelList)
                {
                    if (model.name == imageName)
                    {
                        Vector3 spawnPos = (imageName == "Gare") ? GareSpawn.transform.position : MairieSpawn.transform.position;
                        Quaternion spawnRot = (imageName == "Gare") ? GareSpawn.transform.rotation : MairieSpawn.transform.rotation;

                        GameObject instance = Instantiate(model, spawnPos, spawnRot);
                        spawnedModels.Add(imageName, instance);

                        Debug.Log("Modèle instancié : " + imageName);
                        break;
                    }
                }
            }
        }
    }
}
