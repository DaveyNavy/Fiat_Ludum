using System.Collections;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    [SerializeField] GameObject spikePrefab;
    [SerializeField] GameObject spawnPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(dropSpike());
    }

    IEnumerator dropSpike()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(spikePrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
