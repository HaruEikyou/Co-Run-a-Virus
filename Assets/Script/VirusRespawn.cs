using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusRespawn : MonoBehaviour
{
    public GameObject virus;
    public float minTime, maxTime;
    public float minPos, maxPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawningVirus());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RespawningVirus()
    {
        Instantiate(virus, transform.position + Vector3.right * Random.Range(minPos, maxPos)
            , Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        StartCoroutine(RespawningVirus());
    }
}
