using UnityEngine;

public class Tcam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -4);
    public float mouseSensitivity = 3f;
    public float distance = 4f;
    public float height = 2f;

    float yaw = 0f;
    float pitch = 0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (target == null) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -30f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        Vector3 position = target.position - (rotation * Vector3.forward * distance) + Vector3.up * height;

        transform.position = position;
        transform.rotation = rotation;

        Vector3 targetForward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        if (targetForward.sqrMagnitude > 0.01f)
            target.forward = targetForward;
    }
}
