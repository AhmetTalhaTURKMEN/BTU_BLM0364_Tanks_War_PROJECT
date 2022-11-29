using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1turret_sc : MonoBehaviour
{

    [SerializeField]
    private AudioSource turret_sound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    float turretSpeed = 0.1f;
    void Update()
    {
        // Get the mouse delta. This is not in the range -1...1
        float h = turretSpeed * Input.GetAxis("Turret1")*Time.timeScale;
        //Debug.Log(h);
        turretRotation(h);
        turretSound(h);
    }
    void turretRotation(float horizontalInput)
    {
        transform.Rotate(0, 0, horizontalInput);
    }
    void turretSound(float horizontalInput)
    {

        if (horizontalInput != 0)
        {
            if (!turret_sound.isPlaying)
            {
                turret_sound.volume = 0.5f;
                turret_sound.Play();
            }
        }
        else
        {
            if (turret_sound.isPlaying && turret_sound.volume > 0.1)
            {
                turret_sound.volume -= turret_sound.volume * Time.deltaTime * 5f;
            }

            else if (turret_sound.volume < 0.1)
            {
                turret_sound.Stop();
            }
        }
    }
}
