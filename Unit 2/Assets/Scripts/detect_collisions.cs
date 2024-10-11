using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_collisions : MonoBehaviour
{
    public ParticleSystem effectOne;
    public ParticleSystem effectTwo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
        Instantiate(effectOne, transform.position, transform.rotation);
        Instantiate(effectTwo, transform.position, transform.rotation);
    }
}