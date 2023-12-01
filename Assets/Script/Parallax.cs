using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxSpeedx = 1.0f; // Velocidade de parallax
    public float parallaxSpeedy = 1.0f; // Velocidade de parallax

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void Update()
    {
        float parallaxX = (lastCameraPosition.x - cameraTransform.position.x) * parallaxSpeedx;
        float parallaxY = (lastCameraPosition.y - cameraTransform.position.y) * parallaxSpeedy;

        Vector3 newPosition = transform.position + new Vector3(parallaxX, parallaxY, 0);
        transform.position = newPosition;

        lastCameraPosition = cameraTransform.position;
    }
}
