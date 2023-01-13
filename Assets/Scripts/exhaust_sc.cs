using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exhaust_sc : MonoBehaviour
{
    public GameObject player;

    public bool isThatP1;

    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isThatP1 == true)
        {
            bool tankIsAlive = player.GetComponent<player1_sc>().tankIsAlive;
            if (tankIsAlive)
            {
                float smokeSpeed = player.GetComponent<player1_sc>().speed;
                ps.playbackSpeed = smokeSpeed*Time.timeScale;
                float horizontalInput = player.GetComponent<player1_sc>().horizontalInput;
                if (horizontalInput < 0)
                {
                    ps.Play();
                    if (transform.rotation.eulerAngles.x > 330)
                    {
                        transform.rotation *= Quaternion.Euler(new Vector3(0, 0.01f, 0) * Time.timeScale);
                        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0.1f, 0) * 5 * Time.timeScale);
                    }

                }
                if (horizontalInput > 0)
                {
                    ps.Play();
                    if (transform.rotation.eulerAngles.x < 359)
                    {
                        transform.rotation *= Quaternion.Euler(new Vector3(0, -0.01f, 0) * Time.timeScale);
                        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, -0.1f, 0) * 5 * Time.timeScale);
                    }
                }
                if (horizontalInput == 0)
                {
                    ps.Stop();
                    if (transform.rotation.eulerAngles.x < 359)
                    {
                        transform.rotation *= Quaternion.Euler(new Vector3(0, -0.01f, 0) * Time.timeScale);
                        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, -0.1f, 0) * 10 * Time.timeScale);
                    }
                }
            }

        }
        else
        {
            bool tankIsAlive = player.GetComponent<player2_sc>().tankIsAlive;
            if (tankIsAlive)
            {
                float smokeSpeed = player.GetComponent<player2_sc>().speed;
                ps.playbackSpeed = smokeSpeed*Time.timeScale;
                float horizontalInput = player.GetComponent<player2_sc>().horizontalInput;
                if (horizontalInput < 0)
                {
                    ps.Play();
                    if (transform.rotation.eulerAngles.x > 330)
                    {
                        transform.rotation *= Quaternion.Euler(new Vector3(0, 0.01f, 0) * Time.timeScale);
                        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0.1f, 0) * 5 * Time.timeScale);
                    }

                }
                if (horizontalInput > 0)
                {
                    ps.Play();
                    if (transform.rotation.eulerAngles.x < 359)
                    {
                        transform.rotation *= Quaternion.Euler(new Vector3(0, -0.01f, 0) * Time.timeScale);
                        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, -0.1f, 0) * 5 * Time.timeScale);
                    }
                }
                if (horizontalInput == 0)
                {
                    ps.Stop();
                    if (transform.rotation.eulerAngles.x < 359)
                    {
                        transform.rotation *= Quaternion.Euler(new Vector3(0, -0.01f, 0) * Time.timeScale);
                        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, -0.1f, 0) * 10 * Time.timeScale);
                    }
                }

            }
        }
    }
}
