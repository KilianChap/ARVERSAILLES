using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ModelSpawn : MonoBehaviour
{
    public List<GameObject> modelList = new List<GameObject>();
    public GameObject GareSpawn;
    public GameObject MairieSpawn;

    private Dictionary<string, GameObject> spawnedModels = new Dictionary<string, GameObject>();

    // Appelé automatiquement par Unity depuis l'inspecteur
    public void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            string imageName = trackedImage.referenceImage.name;

            if (!spawnedModels.ContainsKey(imageName))
            {
                foreach (var model in modelList)
                {
                    if (model.name == "mairie1907" && imageName == "A")
                    {
                        GameObject instance = Instantiate(model, MairieSpawn.transform.position, MairieSpawn.transform.rotation);
                        spawnedModels.Add(imageName, instance);
                        Debug.Log("mairie1907 instanciée via l'image A");
                        break;
                    }
                }
            }
        }
    }
}
