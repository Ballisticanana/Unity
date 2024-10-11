using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public int canSpawnDog = 1;
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canSpawnDog == 1)
        {
            StartCoroutine (DogDelay());
        }
    }

    // Update is called once per frame
    IEnumerator DogDelay()
    {
        canSpawnDog = 0;
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        yield return new WaitForSeconds(1);
        canSpawnDog = 1;
    }
}
