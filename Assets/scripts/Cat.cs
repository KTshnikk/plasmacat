using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float Speed = 400f;
    private Rigidbody2D _rb;
    float jump_heigh = 400f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();  
    }
    private void FixedUpdate()
    {
        float horizontal_movement = 1;
        if (Input.GetKeyDown(KeyCode.Space))
            _rb.AddForce(new Vector3(0, jump_heigh, 0), ForceMode2D.Impulse);
        else
            _rb.linearVelocity = transform.TransformDirection(new Vector3(horizontal_movement, 0, 0) * Time.fixedDeltaTime * Speed);
    }
     //_rb.velocity = new Vector2(horizontal_movement * Speed, _rb.velocity.y);
        ///if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _rb.AddForce(new Vector2(_rb.linearVelocity.x, jump_heigh * 10));
        //}
        //float horizontal_movement = Input.GetAxis("Horizontal");
        //_rb.linearVelocity = transform.TransformDirection(new Vector3(horizontal_movement, jumping(), 0) * Time.fixedDeltaTime * Speed);
            /*
    public void jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _rb.AddForce(new Vector2(_rb.linearVelocity.x, jump_heigh * 10));
    }
    */
}
