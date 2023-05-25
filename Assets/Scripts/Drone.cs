using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * 1;
        }
    }
}
