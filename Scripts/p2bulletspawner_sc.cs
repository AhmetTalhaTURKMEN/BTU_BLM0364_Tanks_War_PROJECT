using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2bulletspawner_sc : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefeb;

    [SerializeField]
    private GameObject player;

    public float nextFire = 0;

    [SerializeField]
    private AudioSource fire_sound;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("firenumpad2") != 0 && Time.time > nextFire) //
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
