
using UnityEngine;

public class Wavespawner : MonoBehaviour
{
    public GameObject[] enemywaves;
    public float waveTimer = 0, waveWait = 3;
    void Update()
    {
        waveTimer += Time.deltaTime;
        //Grab wave from array
        if(waveTimer > waveWait)
        {
            waveTimer = 0;
            Instantiate(enemywaves[Random.Range(0, enemywaves.Length)], transform.position, Quaternion.identity);
        }
    }
}
