using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_speed_pipe : MonoBehaviour
{
    public float move_speed = 2;
    public float deadzone = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x < deadzone))
        {
            Debug.Log("destroying pipe");
            Destroy(gameObject);
        }

        transform.position = transform.position + (Vector3.left * move_speed)* Time.deltaTime;
    }
}
