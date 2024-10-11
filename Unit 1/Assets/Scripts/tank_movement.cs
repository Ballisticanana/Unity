using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_movement : MonoBehaviour
{
    public int tank_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, tank_speed * Time.deltaTime);
    }
}
