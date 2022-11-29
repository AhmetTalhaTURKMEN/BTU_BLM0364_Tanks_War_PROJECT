using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_sc : MonoBehaviour
{

    [SerializeField]
    private float speed = 50;
    [SerializeField]
    private GameObject player;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(-new Vector3(0, 1, 0) * speed*Time.timeScale);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("carpisti " + other.transform.name);
        if (other.tag == "ground")
        {
            Destroy(this.gameObject);
            //add animation explosion
        }
        if (other.tag == "target")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            //add animation explosion
        }
        if (other.tag == "tankbody1" || other.tag == "turret1" || other.tag == "tankbody2" || other.tag == "turret2")
        {
            if (other.tag == "tankbody1" || other.tag == "turret1")
            {
                Destroy(this.gameObject);
                player1_sc player = other.gameObject.GetComponentInParent<player1_sc>();
                if (player != null)
                {
                    player.Damage();
                }
            }
            if (other.tag == "tankbody2" || other.tag == "turret2")
            {
                Destroy(this.gameObject);
                player2_sc player = other.gameObject.GetComponentInParent<player2_sc>();
                if (player != null)
                {
                    player.Damage();
                }
            }
        }
        if (other.tag == "Untagged")
        {
            Destroy(this.gameObject);
        }
        if (other.tag == "buffer")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
