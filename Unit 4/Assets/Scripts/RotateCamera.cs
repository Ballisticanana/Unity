using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(Vector3.up, -horizontalInput * rotationSpeed * Time.deltaTime);
        }
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime / 5);
    }
}
