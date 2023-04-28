using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_script : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapForce;
    public LogicScript logic;
    public bool isDead = true;
    private bool isFlapping = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
void Update()
{
    if (isDead)
    {
        if (Input.GetKeyDown(KeyCode.W) && !isFlapping)
        {
            isFlapping = true;
            Flap();
        }

        if (transform.position.y > 3 || transform.position.y < -2)
        {
            isDead = false;
            logic.GameOver();
        }

        // Check vertical velocity to rotate bird when falling or flapping
        if (myRigidbody.velocity.y < 0)
        {
            float angle = Mathf.Lerp(0, -90, -myRigidbody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (isFlapping && myRigidbody.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
}


    void Flap() {
        myRigidbody.velocity = Vector2.up * flapForce;
        transform.rotation = Quaternion.Euler(0, 0, 45);
        Invoke("ResetRotation", 0.5f);
        isFlapping = false;
    }

    void ResetRotation() {
        transform.rotation = Quaternion.identity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = false;
        logic.GameOver();
    }
}
