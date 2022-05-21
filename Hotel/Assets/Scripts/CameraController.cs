using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    public enum RotationAxes { RotationXandY = 0, RotationX, RotationY }
    public RotationAxes axes = RotationAxes.RotationXandY;

    public float minX = -360f;
    public float maxX = 360f;
    public float minY = -360f;
    public float maxY = 360f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    Quaternion originalRotation;
    public float sensivityMouse = 200f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        originalRotation = transform.localRotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if(angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.RotationXandY)
        {
            rotationX += Input.GetAxis("Mouse X")  * sensivityMouse;
            rotationY += Input.GetAxis("Mouse Y")  * sensivityMouse;

            rotationX = ClampAngle(rotationX, minX, maxX);
            rotationY = ClampAngle(-rotationY, minY, maxY);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;

        }

        else if(axes == RotationAxes.RotationX)
        {
            rotationX += Input.GetAxis("Mouse X") * Time.deltaTime * sensivityMouse;
            rotationX = ClampAngle(rotationX, minX, maxX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;

        }

        else if (axes == RotationAxes.RotationY)
        {
            rotationY += Input.GetAxis("Mouse Y") * Time.deltaTime * sensivityMouse;
            rotationY = ClampAngle(rotationY, minY, maxY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;

        }

    }
}
