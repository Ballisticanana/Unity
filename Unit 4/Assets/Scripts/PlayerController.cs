using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private SpawnManager spawnManager;
    private TextMeshProUGUI ugui_powerupLength;
    private TextMeshProUGUI ugui_powerupStrength;
    private bool canJump = true;
    public float jumpForce = 20f;
    public float speed = 5.0f;
    public bool hasPowerUp = false;
    public float powerUpStrenght = 7.5f;
    public GameObject powerupIndicator;
    public GameObject canJumpIndicator;
    public GameObject canMegaJumpIndicator;
    public float powerupRotateSpeed = 1.0f;
    public float powerupLength = 30.0f;
    public float powerupLengthDisplay;
    public float horizontalInput, forwardInput;
    public float roundedHorizontalInput, roundedForwardInput;
    public ParticleSystem jumpParticle;
    public bool canOutsideJump = true;

    public bool inside = true;
    //private IEnumerator 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        ugui_powerupLength = GameObject.Find("UI_1").GetComponent<TextMeshProUGUI>();
        ugui_powerupStrength = GameObject.Find("UI_2").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ugui_powerupLength.text = "Powerup Length ("+ powerupLengthDisplay +")";
        ugui_powerupStrength.text = "Powerup Strength (" + powerUpStrenght + ")";
        powerUpStrenght = (Mathf.Round((9.0f + 0.5f * spawnManager.waveNumber + powerupLength * 0.25f)*10))/10;
        if (powerupLength > 0)
        {
            powerupLength = powerupLength - Time.deltaTime;
            powerupLengthDisplay = Mathf.Round(powerupLength);
        }
        //(Mathf.Round(()*100)/100)

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed * Time.deltaTime);
        if (!Input.GetKey(KeyCode.LeftShift) && horizontalInput != 0)
        {
            playerRb.AddForce(focalPoint.transform.right * horizontalInput * speed * Time.deltaTime);
        }

        powerupIndicator.transform.position = transform.position;
        powerupIndicator.transform.Rotate(0, Time.deltaTime * powerupRotateSpeed, 0);
        canJumpIndicator.transform.position = transform.position;
        canJumpIndicator.transform.Rotate(Mathf.Sin(Time.realtimeSinceStartup), Time.deltaTime * powerupRotateSpeed, 0);


        if (Input.GetKey(KeyCode.Space) && canJump == true &&(inside == true || powerupLength < 3.5f))
        {
            StartCoroutine("PlayerControllerJump");
        }else if(Input.GetKey(KeyCode.Space) && canJump == true && inside == false && canOutsideJump == true && powerupLength > 3.5f)
        {
            StartCoroutine("PlayerControllerOutsideJump");
        }

        if (canJump == true && canOutsideJump == true)
        {
            canJumpIndicator.gameObject.SetActive(true);
        }
        else
        {
            canJumpIndicator.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R) || playerRb.transform.position.y < -5)
        {
            StartCoroutine("Reset");
        }
    }

    IEnumerator PlayerControllerJump()
    {
        Debug.Log("Normal jump");
        canJump = false;
        playerRb.AddForce(focalPoint.transform.up * jumpForce, ForceMode.Impulse);
        yield return new WaitForSeconds(3);
        canJump = true;
    }
    IEnumerator PlayerControllerOutsideJump()
    {
        Debug.Log("Outside jump");
        canOutsideJump = false;
        canJump = false;
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(focalPoint.transform.up * jumpForce * 2, ForceMode.Impulse);
        Instantiate(jumpParticle, transform.position, transform.rotation);
        powerupLength -= 3.5f;
        yield return new WaitForSeconds(0.25f);
        Vector3 toFocalPoint = (focalPoint.transform.position - playerRb.transform.position);
        playerRb.AddForce(toFocalPoint, ForceMode.Impulse);
        Instantiate(jumpParticle, transform.position, transform.rotation);
        yield return new WaitForSeconds(2.75f);
        canJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            inside = true;
        }
        else if (other.CompareTag("outside"))
        {
            inside = false;
        }

        if (other.CompareTag("Powerup"))
        {
            StopCoroutine("PowerupCountdownRoutine");
            hasPowerUp = true;
            powerupLength += 8.5f;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine("PowerupCountdownRoutine");
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerupLength);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            canOutsideJump = true;
        }
    }

    public void Reset()
    {
        Debug.Log("Reseting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        powerupLength = 0;

    }
}




/*if (forwardInput != 0)
{
    roundedForwardInput = (forwardInput / Mathf.Abs(forwardInput));
    playerRb.AddForce(focalPoint.transform.forward * jumpForce * roundedForwardInput * 2, ForceMode.Impulse);
}
else if (horizontalInput != 0)
{
    roundedHorizontalInput = (horizontalInput / Mathf.Abs(horizontalInput));
    playerRb.AddForce(focalPoint.transform.forward * jumpForce * roundedHorizontalInput * 2, ForceMode.Impulse);
}*/
