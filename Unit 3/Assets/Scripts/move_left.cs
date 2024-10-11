using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_left : MonoBehaviour
{

    private float speed = 30;
    private player_controller playerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<player_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
