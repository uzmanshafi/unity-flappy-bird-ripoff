using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_speed_pipe : MonoBehaviour
{
    public float base_move_speed = 2;
    public float speed_increase_amount = 0.1f;
    public float speed_increase_interval = 10;
    private float current_speed;
    private float timer = 0;

    public float deadzone = -4;

    public bool gameIsOver = false;

    void Start()
    {
        current_speed = base_move_speed;
    }

    void Update()
    {
        // Check if it's time to increase the speed
        if (timer >= speed_increase_interval)
        {
            current_speed += speed_increase_amount;
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }

        // Move the pipe and check if it's offscreen
        if (transform.position.x < deadzone)
        {
            Debug.Log("Pipe is offscreen and Destoryed");
            Destroy(gameObject);
        }
        else
        {
            if(!gameIsOver)
            {
                transform.position += (Vector3.left * current_speed) * Time.deltaTime;
            }
        }
    }

    public void GameOver()
    {
        gameIsOver = true;
    }
}
