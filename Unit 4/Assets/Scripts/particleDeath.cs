using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LifeSpan");
    }

    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
