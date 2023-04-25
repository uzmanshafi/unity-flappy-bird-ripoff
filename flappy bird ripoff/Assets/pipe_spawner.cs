using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe_spawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawn_time = 1;
    private float timer = 0;

    public float heightOffset;
    // Start is called before the first frame update
    void Start()
    {
        spawnpipes();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawn_time)
        {
            timer = timer + Time.deltaTime;
        } 
        else
        {
            timer = 0;
            spawnpipes();
        }
        
        
    }

    void spawnpipes()
    {
        float lowestpoint = transform.position.y - heightOffset;
        float highestpoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestpoint, heightOffset), 0), transform.rotation);
    }

}
