using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
    private float speedMulti = 2.5f;

    [SerializeField]
    private GameObject laserPreFab;

    [SerializeField]
    private GameObject tripleShotLaser;

    [SerializeField]
    private GameObject playerShield;

    [SerializeField]
    private GameObject ShieldPowerUp;
   

    public float fireRate = 0.5f;
    private float canFire = -1f;

    [SerializeField]
    private int lives = 3;

    private SpawnManager spawnManager;

    [SerializeField]
    private bool isTripleShotActive = false;
    [SerializeField]
    private bool isSpeedPowerActive = false;
    [SerializeField]
    private bool isShieldPowerActive = false;

    [SerializeField]
    private int score;

    private UIManager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Bounds();
        inputKeyLaser();


    }
    public void inputKeyLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            canFire = Time.time + fireRate;

            if (isTripleShotActive == true)
            {
                GameObject tripleLaser = Instantiate(tripleShotLaser, transform.position + Vector3.up * 1, Quaternion.identity);
            }
            else
            {
                GameObject newLaser = Instantiate(laserPreFab, transform.position + Vector3.up * 1, Quaternion.identity);
            }

        }

    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        if (isSpeedPowerActive == true)
        {
            transform.Translate(direction * speed * speedMulti * Time.deltaTime);
        }
        else
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }

    }
    void Bounds()
    {

        if (transform.position.y >= 0)
        {

            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.96f)
        {
            transform.position = new Vector3(transform.position.x, -3.96f, 0);
        }

        if (transform.position.x >= 11.34f)
        {
            transform.position = new Vector3(-11.34f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.34f)
        {
            transform.position = new Vector3(11.34f, transform.position.y, 0);
        }
    }
    public void damage()
    {
        if(isShieldPowerActive == true)
        {
            playerShield.SetActive(false);

            return;

        }
        lives--;
        uiManager.UpdateLives(lives);
        if (lives < 1)
        {
            spawnManager.OnDeath();
            uiManager._gameOver();
            Destroy(gameObject);
        }
    }

    public void EnableTripleShot()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        int timeWait = 5;
        while (isTripleShotActive == true)
        {
            yield return new WaitForSeconds(timeWait);
            isTripleShotActive = false; 
        }
    }

    public void EnableSpeedPowerUp()
    {
        isSpeedPowerActive = true;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    IEnumerator SpeedPowerDownRoutine()
    {
        int timeWait = 7;

        while (isSpeedPowerActive == true)
        {
            yield return new WaitForSeconds(timeWait);
            isSpeedPowerActive = false;
        }

    }
    public void EnableShieldPowerUp()
    {
        isShieldPowerActive = true;
        playerShield.SetActive(true);
        StartCoroutine(ShieldPowerDownRoutine());
    }

    IEnumerator ShieldPowerDownRoutine()
    {
        int timeWait = 20;

        while (isShieldPowerActive == true)
        {
            
            yield return new WaitForSeconds(timeWait);
            isShieldPowerActive = false;
        }


    }

    public void AddScore(int points)
    {
        score += points;
        uiManager.updateScore(score);
    }
}
