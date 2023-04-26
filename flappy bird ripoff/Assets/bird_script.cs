using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapForce;
    public LogicScript logic;
    public bool isDead = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) == true && isDead))
        {
            myRigidbody.velocity = Vector2.up * flapForce;
        }

        if (transform.position.y > 3 || transform.position.y < -2)
        {
            logic.GameOver();
            isDead = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            logic.GameOver();
            isDead = false;
    }
}
