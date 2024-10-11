using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public float speed, turnSpeed, forwardControl, turnControl;
    public Rigidbody rb;
    public Vector3 currentV;
    public float currentSpeed;
    public float neededTurnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //currentV = rb.GetRelativePointVelocity(transform.position);
        Debug.Log(currentV);
        forwardControl = Input.GetAxis("Vertical");
        turnControl = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(0, 0, speed * Time.deltaTime * forwardControl, ForceMode.VelocityChange);
        if (rb.velocity.z > neededTurnSpeed)  
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime * turnControl, 0);
        }
        if (rb.velocity.z < -neededTurnSpeed)
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime * turnControl, 0);
        }


    }
}
//if (Input.GetKey(KeyCode.W))
//transform.Translate(0, 0, speed * Time.deltaTime * forwardControl);

//currentV = rb.GetRelativePointVelocity(transform.position);
//Debug.Log(currentV);
//forwardControl = Input.GetAxis("Vertical");
//turnControl = Input.GetAxis("Horizontal");
//rb.AddRelativeForce(0, 0, speed * Time.deltaTime * forwardControl, ForceMode.Force);
//transform.Rotate(0, turnSpeed * Time.deltaTime * turnControl * currentV.z, 0);
//rb.velocity = new Vector3(0, 0, speed * forwardControl);