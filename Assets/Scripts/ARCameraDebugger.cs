using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARCameraManager))]
public class ARCameraDebugger : MonoBehaviour
{
    private ARCameraManager cameraManager;

    void Awake()
    {
        cameraManager = GetComponent<ARCameraManager>();
    }

    void Start()
    {
        Debug.Log("ARCameraDebugger: Test de la caméra AR...");

        if (cameraManager == null)
        {
            Debug.LogError("ARCameraManager non trouvé !");
            return;
        }

        cameraManager.frameReceived += OnCameraFrameReceived;
    }

    private void OnCameraFrameReceived(ARCameraFrameEventArgs args)
    {
        if (cameraManager.TryAcquireLatestCpuImage(out XRCpuImage image))
        {
            Debug.Log($"Frame reçue : {image.width} x {image.height}");
            image.Dispose();
        }
        else
        {
            Debug.LogWarning("Aucun accès à l'image CPU !");
        }
    }
}
