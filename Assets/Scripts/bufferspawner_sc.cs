using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bufferspawner_sc : MonoBehaviour
{
    [SerializeField]
    private GameObject buffer;

    [SerializeField]
    private bool stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {

    }
    public void OnplayerDeath()
    {
        stopSpawning = true;
    }
    IEnumerator SpawnRoutine()
    {
        while (stopSpawning == false)
        {
            yield return new WaitForSeconds(1.0f);
            Vector3 position = new Vector3(Random.Range(-300f, 270f), 18, Random.Range(40f, 310f));
            GameObject newBuffer = Instantiate(buffer, position, Quaternion.identity) as GameObject;
            newBuffer.transform.parent = transform;
            yield return new WaitForSeconds(20.0f);
        }
    }
}
