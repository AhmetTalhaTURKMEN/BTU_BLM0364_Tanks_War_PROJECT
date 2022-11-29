using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1_sc : MonoBehaviour
{

    [SerializeField]
    private AudioSource tank_sound;

    [SerializeField]
    private float speed = 10;

    public float lives = 3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");
        tankControl(horizontalInput, verticalInput);
        tankSound(horizontalInput, verticalInput);

    }
    public void Damage()
    {
        lives--;
        if (lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
    void tankControl(float horizontalInput, float verticalInput)
    {
        Vector3 direction = new Vector3(0, 0, horizontalInput);
        transform.Translate(direction * speed * Time.deltaTime);//add force

        if (verticalInput > 0)
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0.01f, 0) * Time.timeScale);
            transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0.01f, 0) * speed * Time.timeScale);

        }
        if (verticalInput < 0)
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0, -0.01f, 0) * Time.timeScale);
            transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, -0.01f, 0) * speed * Time.timeScale);
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
        speed += 5;
    }
    public void lifeBuff()
    {
        lives += 1;
    }

}
