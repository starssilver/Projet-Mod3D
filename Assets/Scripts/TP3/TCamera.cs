using UnityEngine;

public class TCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0.2f, 0);
    public float followSpeed = 5f;
    public float lookSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        Quaternion desiredRotation = Quaternion.LookRotation(target.forward, target.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, lookSpeed * Time.deltaTime);
    }
}
