using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    public bool isFlying = true;

    public float HorizontalSensitivity = 5f;
    public float VerticalSensitivity = 5f;
    public int VerticalInversion = -1;

    public float ForwardMovementSpeed = 0.25f;
    public float SideMovementSpeed = 0.1f;
    public float VerticalMovementSpeed = 0.125f;

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    private float SlowerVerticalMovementSpeed;


    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            isFlying = !isFlying;
        }
        if (isFlying)
        {
            ///Camera
            xRotation += VerticalInversion * VerticalSensitivity * Input.GetAxis("Mouse Y");
            yRotation += HorizontalSensitivity * Input.GetAxis("Mouse X");

            transform.eulerAngles = new Vector3(xRotation, yRotation, 0);


            ///Movement
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(
                    transform.forward.x * ForwardMovementSpeed,
                    0,
                    transform.forward.z * ForwardMovementSpeed
                );
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(
                    transform.forward.x * (-ForwardMovementSpeed / 1.95f),
                    0,
                    transform.forward.z * (-ForwardMovementSpeed / 1.95f)
                );
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-transform.right * SideMovementSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(transform.right * SideMovementSpeed);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * VerticalMovementSpeed);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.down * VerticalMovementSpeed);
            }



            ///Gravity
            SlowerVerticalMovementSpeed = VerticalMovementSpeed * 0.1f;

            transform.Translate(Vector3.down * SlowerVerticalMovementSpeed);
        }
    }
}
