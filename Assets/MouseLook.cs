using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVer = 9.0f;

    public float minimumVer = -45.0f;
    public float maximumVer = 45.0f;

    private float verticalRot = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        switch (axes)
        {
            case RotationAxes.MouseX:
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0, Space.Self);
                    break;
                }
            case RotationAxes.MouseY:
                {
                    verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVer;
                    verticalRot = Mathf.Clamp(verticalRot, minimumVer, maximumVer);

                    float horizontalRot = transform.localEulerAngles.y;

                    transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
                    break;
                }
            case RotationAxes.MouseXAndY:
                {
                    verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVer;
                    verticalRot = Mathf.Clamp(verticalRot, minimumVer, maximumVer);

                    float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                    float horizontalRot = transform.localEulerAngles.y + delta;

                    transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
                    break;
                }
            default: break;
        }
    }
}
