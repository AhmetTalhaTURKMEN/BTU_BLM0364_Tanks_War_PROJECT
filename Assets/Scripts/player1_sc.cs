using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1_sc : MonoBehaviour
{

    [SerializeField]
    private AudioSource tank_sound;

    public float speed = 1;

    [SerializeField]
    private float rotationSpeed = 10;

    [SerializeField]
    private float maxSpeed = 10;

    [SerializeField]
    private float reverseSpeed = 5;

    public float lives = 3;

    [SerializeField]
    private float maxLives = 3;

    public bool tankIsAlive = true;

    public float horizontalInput = 0;

    [SerializeField]
    private bool isThatP1 = true;//oyuncu kontrol script sayisini 1'e dusur

    public Material[] materialsArray;

    [SerializeField]
    private ParticleSystem ps;

    public int enemyScore;

    public bool didEnemyScored = false;

    void Start()
    {
        enemyScore = PlayerPrefs.GetInt("p2score");
    }

    void Update()
    {
        if (tankIsAlive)
        {
            horizontalInput = Input.GetAxis("Vertical");
            float verticalInput = Input.GetAxis("Horizontal");
            tankControl(horizontalInput, verticalInput);
            tankSound(horizontalInput, verticalInput);
        }
        else
        {
            tank_sound.Stop();
        }
    }
    public void Damage()
    {
        if (lives > 0)
        {
            lives--;
        }
        if (lives < 1)
        {
            tankIsAlive = false;
            int numOfChildren = transform.childCount;
            for (int i = 0; i < numOfChildren; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                child.GetComponent<Renderer>().sharedMaterial = materialsArray[0];
            }
            ps.enableEmission = true;

            if (!didEnemyScored)
            {
                enemyScore = enemyScore + 1;
                PlayerPrefs.SetInt("p2score", enemyScore);
                didEnemyScored = true;
            }
        }
    }
    void tankControl(float horizontalInput, float verticalInput)
    {
        Vector3 direction = new Vector3(0, 0, horizontalInput);

        if (horizontalInput > 0)
        {
            lineerSpeed();
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else if (horizontalInput < 0)
        {
            transform.Translate(direction * reverseSpeed * Time.deltaTime);
            if (speed > 1)
            {
                speed -= speed * Time.deltaTime * 1f;
            }
            else
            {
                speed = 1;
            }
        }
        else if (horizontalInput == 0)
        {

            if (speed > 1)
            {
                speed -= speed * Time.deltaTime * 1f;
            }
            else
            {
                speed = 1;
            }
        }

        if (verticalInput > 0)
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0.01f, 0) * Time.timeScale);
            transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0.01f, 0) * rotationSpeed * Time.timeScale);

        }
        if (verticalInput < 0)
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0, -0.01f, 0) * Time.timeScale);
            transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, -0.01f, 0) * rotationSpeed * Time.timeScale);
        }
    }
    void lineerSpeed()
    {
        //++speed
        if (speed < maxSpeed)
        {
            speed += speed * Time.deltaTime * 1f;
        }
        else
        {
            speed = maxSpeed;
        }
    }

    void tankSound(float horizontalInput, float verticalInput)
    {

        if (verticalInput != 0 || horizontalInput != 0)
        {
            if (!tank_sound.isPlaying)
            {
                tank_sound.volume = 0.5f;
                tank_sound.Play();
            }
        }
        else
        {
            if (tank_sound.isPlaying && tank_sound.volume > 0.1)
            {
                tank_sound.volume -= tank_sound.volume * Time.deltaTime * 2f;
            }

            else if (tank_sound.volume < 0.1)
            {
                tank_sound.Stop();
            }
        }
    }
    public void speedBuff()
    {
        maxSpeed += 5;
        rotationSpeed += 5;
    }
    public void lifeBuff()
    {
        lives += 1;
        if (lives > 3)
        {
            lives = maxLives;
        }
    }

}
