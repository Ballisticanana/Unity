using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class PowerupMovement : MonoBehaviour
{
    public Vector3 movement;
    public float gameTime;
    public float sinSpeed;
    public float bounceRange;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        movement = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime = (gameTime + Time.deltaTime);
        transform.position = movement;
        movement.y = bounceRange * Mathf.Sin(gameTime *sinSpeed) + bounceRange + 0.77f;
        transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
    }
}