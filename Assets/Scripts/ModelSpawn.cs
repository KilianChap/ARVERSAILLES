using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ModelSpawn : MonoBehaviour
{
    public List<GameObject> modelList = new List<GameObject>();
    public GameObject GareSpawn;
    public GameObject MairieSpawn;
    
    public void OntrackedImagesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> obj)
    {
        //Ajouter un modele 3D sur une image détécté, on check la liste des images qui sont tracké
        foreach (var trackedImage in obj.added)
        { 
            //on cherche dans la liste de modeles si on gtrouve un modele qui porte le meme nom
            foreach (var model in modelList)
            { 
                if (model.name == trackedImage.name) //si on trouve
                {
                    if (model.name == "Gare") //on compare le nom du modele avec le spawn 
                    {
                        Instantiate(model, GareSpawn.transform.position, GareSpawn.transform.rotation); // on instancie le modele a la position du spawn et avec la rotation du spawn
                    }
                    else
                    {
                        Instantiate(model, MairieSpawn.transform.position, MairieSpawn.transform.rotation);

                    }
                }
            }

        }
    }
}
