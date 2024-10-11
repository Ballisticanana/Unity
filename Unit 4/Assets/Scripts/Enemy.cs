using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    public ParticleSystem deathExplosion;
    private Vector3 playerLocal;
    private Vector3 enemyLocal;
    private Vector3 mainIslandCenter;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        mainIslandCenter = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerLocal = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        enemyLocal = new Vector3(transform.position.x, 0, transform.position.z);
        enemyRb.AddForce((playerLocal - enemyLocal).normalized * speed * Time.deltaTime);
        
        if (Vector3.Distance(mainIslandCenter, enemyRb.transform.position) > 20)
        { 
            Instantiate(deathExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    //IEnumerator ParticaleLife() 
    //{
        //ParticleSystem temp = Instantiate(deathExplosion, transform.position, transform.rotation);
       // yield return new WaitForSeconds(2);
        //Destroy(temp.gameObject);
    //}

}
