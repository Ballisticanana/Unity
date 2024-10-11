using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_spin : MonoBehaviour
{
    public float turnSpeed, turnControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime * turnControl);
    }
}
