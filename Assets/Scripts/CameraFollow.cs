using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
