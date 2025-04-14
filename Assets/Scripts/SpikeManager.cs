using System.Collections;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    [SerializeField] GameObject spikePrefab;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] bool up = false;
    [SerializeField] float thrust = 15;
    
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
            if (!up)
            {
                Instantiate(spikePrefab, spawnPoint.transform.position, Quaternion.identity);
            } else
            {
                Quaternion up = new Quaternion(0, 0, 180, 0);
                GameObject spike = Instantiate(spikePrefab, spawnPoint.transform.position, up);
                spike.GetComponent<Rigidbody2D>().AddForce(-spike.transform.up * thrust, ForceMode2D.Impulse);
            }

        }
    }
}
