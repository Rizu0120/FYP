using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //variables
    public Transform target; //follow target
    public Vector3 offset; //init position of the camera
    public bool useOffsetValues;
    public float rotateSpeed; //camera rotation speed
    public Transform pivot; //follow pivot
    public float maxViewAngle; //max view angle value
    public float minViewAngle; //min view angle value
    public bool invertY; //better up down camera view rotation control

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        //camera following target, called pivot. (transform mean move, so move to target = following target)
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = null;

        //lock the mouse state but locking mouse will make it no longer able to click anything in further gameplay such as clicking UI button, so I disable this
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    //make it LateUpdate for smoother response
    void LateUpdate()
    {
        //camera following target, called pivot
        pivot.transform.position = target.transform.position;

        //Get the X position of the mouse & rotation of the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        //Get the Y position of the mouse & rotate the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //pivot.Rotate(vertical, 0, 0);
        if(invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        //Limit up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180.0f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, pivot.eulerAngles.y, 0.0f);
        }

        if (pivot.rotation.eulerAngles.x > 180.0f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360.0f + minViewAngle, pivot.eulerAngles.y, 0.0f);
        }

        //Move the camera based on the current rotation of the target & the original offset
        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y -.5f, transform.position.z);
        }

        transform.LookAt(target);
    }
}