using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    public bool isFlying = true;

    public Rigidbody rb;

    public float HorizontalSensitivity = 5f;
    public float VerticalSensitivity = 5f;
    public int VerticalInversion = -1;

    public float ForwardMovementSpeed = 0.25f;
    public float SideMovementSpeed = 0.1f;
    public float VerticalMovementSpeed = 0.125f;

    public float SpeedOverTime = 0.01f;
    public float CapSpeedOverTime = 1;
    private float MinSpeedOverTime;

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    private float SlowerVerticalMovementSpeed;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        MinSpeedOverTime = SpeedOverTime;
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            isFlying = !isFlying;
        }
        if (isFlying)
        {
            Camera();
            Movement();
            Gravity();
        }
    }
    public void Camera()
    {
        xRotation += VerticalInversion * VerticalSensitivity * Input.GetAxis("Mouse Y");
        yRotation += HorizontalSensitivity * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(xRotation, yRotation, 0);
    }
    public void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (SpeedOverTime <= CapSpeedOverTime)
            {
                SpeedOverTime = SpeedOverTime + 0.001f;
            }

            rb.velocity = transform.forward * ForwardMovementSpeed * SpeedOverTime * 100;
            /*transform.position += new Vector3(
                transform.forward.x * ForwardMovementSpeed * SpeedOverTime,
                0,
                transform.forward.z * ForwardMovementSpeed * SpeedOverTime
            );*/
        }
        if (!Input.anyKey)
        {
            rb.velocity = new Vector3(0, 0);
            SpeedOverTime = MinSpeedOverTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * ForwardMovementSpeed * 50;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * SideMovementSpeed * 50;
            //transform.Translate(-transform.right * SideMovementSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * SideMovementSpeed * 50;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = transform.up * VerticalMovementSpeed*50;
            //transform.Translate(Vector3.up * VerticalMovementSpeed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.down * VerticalMovementSpeed);
        }
    }
    public void Gravity()
    {
        SlowerVerticalMovementSpeed = VerticalMovementSpeed * 0.1f;

        //rb.velocity = -transform.up * SlowerVerticalMovementSpeed*50;
    }
}
