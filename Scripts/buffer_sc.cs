using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buffer_sc : MonoBehaviour
{

    public Text changingText;

    [SerializeField]
    private int randomBuff;

    void Start()
    {
        randomBuff = Random.Range(1, 3);
        TextChange();
    }
    void Update()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0, 0.3f, 0)*Time.timeScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player1")
        {
            Debug.Log(other.tag);
            if (randomBuff == 1)
            {
                player1_sc player = other.gameObject.GetComponent<player1_sc>();
                player.speedBuff();
                Destroy(this.gameObject);

            }
            else if (randomBuff == 2)
            {
                player1_sc player = other.gameObject.GetComponent<player1_sc>();
                player.lifeBuff();
                Destroy(this.gameObject);
            }
        }
        if (other.tag == "player2")
        {
            if (randomBuff == 1)
            {
                player2_sc player = other.gameObject.GetComponent<player2_sc>();
                player.speedBuff();
                Destroy(this.gameObject);
            }
            else if (randomBuff == 2)
            {
                player2_sc player = other.gameObject.GetComponent<player2_sc>();
                player.lifeBuff();
                Destroy(this.gameObject);
            }
        }
    }
    public void TextChange()
    {
        if (randomBuff == 1)
        {
            changingText.text = "Speed Buff";
        }
        if (randomBuff == 2)
        {
            changingText.text = "Life Buff";
        }
    }
}
