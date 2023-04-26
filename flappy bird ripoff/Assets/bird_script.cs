using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) == true))
        {
            myRigidbody.velocity = Vector2.up * flapForce;
        }
        
    }
}
