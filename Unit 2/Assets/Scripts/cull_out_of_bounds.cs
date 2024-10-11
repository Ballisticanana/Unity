using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cull_out_of_bounds : MonoBehaviour
{
    private float topBound = 80;
    private float lowerBound = -25;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("womp womp");
            Destroy(gameObject);
        }
    }
}
