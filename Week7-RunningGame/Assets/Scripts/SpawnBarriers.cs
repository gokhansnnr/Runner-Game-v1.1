using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarriers : MonoBehaviour
{
    // Start is called before the first frame update
    public int spawnCount = Random.Range(35,50);
    public GameObject barrier;

    void SpawnBarrier()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-5.9f, 87.5f));
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(barrier, spawnPosition, spawnRotation);
        }
    }
    
    void Start()
    {
        SpawnBarrier();
    }

}
