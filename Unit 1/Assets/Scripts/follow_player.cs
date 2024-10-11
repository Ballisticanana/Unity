using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour
{
    public GameObject playerCar;
    public Vector3 cameraOffSet;
    public Vector3 cameraAngleOffSet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = playerCar.transform.position + cameraOffSet;
        this.transform.eulerAngles = playerCar.transform.eulerAngles + cameraAngleOffSet;
    }
}
