using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1bulletspawner_sc : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefeb;

    [SerializeField]
    private GameObject turret;

    [SerializeField]
    private GameObject player;

    public float nextFire = 0;


    [SerializeField]
    private AudioSource fire_sound;

    [SerializeField]
    private AudioSource bullet_falling_sound_effect;

    [SerializeField]
    private AudioSource ready_sound_effect;

    //public camerafireeffect_sc shake;



    void Update()
    {
        bool tankIsAlive = player.GetComponent<player1_sc>().tankIsAlive;
        if (tankIsAlive)
        {
            if (Input.GetAxis("firespace") != 0 && Time.time > nextFire) //
            {

                fireBullet();
                //StartCoroutine(shake.Shake(5,5));
            }
        }
    }
    void fireBullet()
    {
        Instantiate(bulletPrefeb, transform.position + new Vector3(1f, 0.8f, 0), Quaternion.Euler(new Vector3(turret.transform.rotation.eulerAngles.x, turret.transform.rotation.eulerAngles.y + 90, turret.transform.rotation.eulerAngles.z)));
        fire_sound.Play();
        bullet_falling_sound_effect.PlayDelayed(1F);
        nextFire = Time.time + 5;
        ready_sound_effect.PlayDelayed(5F);
    }
}
