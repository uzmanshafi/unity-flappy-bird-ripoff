using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pipe_spawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 1.25f;
    private float timer = 0;

    public float heightOffset = 0.86f;

    public bool gameIsOver = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnpipes();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        } 
        else
        {
            spawnpipes();
            timer = 0;
        }
        
        
    }

    void spawnpipes()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }


}