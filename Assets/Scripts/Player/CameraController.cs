using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    // Camera movement
    public float cameraRotationSpeed = 100f;
    private Camera playerCamera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();



    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        CheckRaycast();
    }

    void MoveCamera()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -cameraRotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, cameraRotationSpeed * Time.deltaTime);
        }
    }
    void CheckRaycast()
    {
        // Create a ray from the center of the viewport (0.5, 0.5)
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        // We'll limit the range to 100 units so it doesn't calculate forever
        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log("Center of screen is hitting: " + hit.collider.name + hit.distance);

            // This helps you see the ray in the Scene tab
            Debug.DrawLine(ray.origin, hit.point, Color.black);

            
        }
        else
        {
            Debug.Log("not hitting anything");
        }
    }
}
