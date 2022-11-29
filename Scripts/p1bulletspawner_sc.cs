using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1bulletspawner_sc : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefeb;

    [SerializeField]
    private GameObject player;

    public float nextFire = 0;


    [SerializeField]
    private AudioSource fire_sound;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxis("firespace") != 0 && Time.time > nextFire) //
        {
            fireBullet();
        }
    }
    void fireBullet()
    {
        Instantiate(bulletPrefeb, transform.position + new Vector3(1f, 0.8f, 0), Quaternion.Euler(new Vector3(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y + 90, player.transform.rotation.eulerAngles.z)));
        fire_sound.Play();
        nextFire = Time.time + 5;
    }
}
