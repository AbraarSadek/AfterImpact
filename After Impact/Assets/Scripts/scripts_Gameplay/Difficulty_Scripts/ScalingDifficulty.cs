using UnityEngine;
using static UnityEditor.SceneView;

public class ScalingDifficulty : MonoBehaviour
{
    [Header("Speed Scaling Settings")]
    public MainCameraController cameraMover;  // Reference to the CameraMover script
    public float growthRate = 1.5f;  // How much speed multiplies every 30 seconds
    public float interval = 30f;     // Seconds per exponential step
    private float startSpeed;        // Original starting speed
    private float startTime;         // Time when game started

    void Start()
    {
        //check if cameraMover has reference
        if (cameraMover == null)
        {
            cameraMover = GetComponent<MainCameraController>();
        }


        if (cameraMover != null)
        {
            startSpeed = cameraMover.cameraSpeed;
            startTime = Time.time;
        }
        else
        {
            Debug.LogError("CameraSpeedScaler: No CameraMover found! Please assign one in the Inspector.");
        }
    }

    void Update()
    {
        if (cameraMover == null) return;

        // Calculate elapsed time since start
        float elapsed = Time.time - startTime;
        float intervalsPassed = elapsed / interval;

        // Exponential speed scaling formula
        cameraMover.cameraSpeed = startSpeed * Mathf.Pow(growthRate, intervalsPassed);
    }
}
