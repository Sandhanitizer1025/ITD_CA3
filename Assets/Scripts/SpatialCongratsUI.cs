using UnityEngine;

public class SpatialCongratsUI : MonoBehaviour
{
    [Header("Follow Settings")]
    public Transform playerCamera;          // XR Origin Main Camera
    public float distance = 1.2f;           // how far in front
    public float heightOffset = -0.1f;      // slight down so it's not blocking view
    public bool followWhileVisible = false; // if true, it keeps following

    private bool isShowing = false;

    void OnEnable()
    {
        isShowing = true;
        SnapInFront();
    }

    void Update()
    {
        if (!isShowing) return;
        if (!followWhileVisible) return;

        SnapInFront();
    }

    public void SnapInFront()
    {
        if (playerCamera == null) return;

        Vector3 forwardFlat = playerCamera.forward;
        forwardFlat.y = 0f;
        forwardFlat.Normalize();

        transform.position = playerCamera.position + forwardFlat * distance + Vector3.up * heightOffset;

        // Face the camera (billboard)
        Vector3 lookDir = transform.position - playerCamera.position;
        lookDir.y = 0f;
        transform.rotation = Quaternion.LookRotation(lookDir);
    }

    public void Hide()
    {
        isShowing = false;
        gameObject.SetActive(false);
    }
}
