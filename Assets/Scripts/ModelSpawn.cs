using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ModelSpawn : MonoBehaviour
{
    public List<GameObject> modelList = new List<GameObject>();
    public GameObject GareSpawn;
    public GameObject MairieSpawn1897;
    public GameObject MairieSpawn1907;

    private Dictionary<string, GameObject> spawnedModels = new Dictionary<string, GameObject>();

    // Appelle automatiquement par Unity depuis l'inspecteur
    public void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            string imageName = trackedImage.referenceImage.name;

            if (!spawnedModels.ContainsKey(imageName))
            {
                foreach (var model in modelList)
                {
                    if (model.name == "mairie1897" && imageName == "A")
                    {
                        GameObject instance = Instantiate(model, MairieSpawn1897.transform.position, MairieSpawn1897.transform.rotation);
                        spawnedModels.Add(imageName, instance);
                        Debug.Log("mairie1897 instanciee via l'image A");
                        break;
                    }
                    if (model.name == "mairie1907" && imageName == "B")
                    {
                        GameObject instance = Instantiate(model, MairieSpawn1907.transform.position, MairieSpawn1907.transform.rotation);
                        spawnedModels.Add(imageName, instance);
                        Debug.Log("mairie1907 instanciee via l'image B");
                        break;
                    }
                }
            }
        }
    }
}
