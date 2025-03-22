using UnityEngine;
using System.Collections;

// The velocity in y is 10 units per second.  If the GameObject starts at (0,0,0) then
// it will reach (0,100,0) units after 10 seconds.

public class lv_3_Player : MonoBehaviour
{
    public bool is_jumping = true;
    public float speed = 10f;
    public Rigidbody2D rb;

    private float t = 0.0f;
    private bool moving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity =new Vector3(1*speed,0,0); 
        if (Input.GetButtonDown("Jump") && !is_jumping)
        {
            // the cube is going to move upwards in 10 units per second
            rb.linearVelocity = new Vector3(0, 10, 0);
            moving = true;
            Debug.Log("jump");
        }

        if (moving)
        {
            // when the cube has moved over 1 second report it's position
            t = t + Time.deltaTime;
            if (t > 1.0f)
            {
                Debug.Log(gameObject.transform.position.y + " : " + t);
                t = 0.0f;
            }
        }
    }
}