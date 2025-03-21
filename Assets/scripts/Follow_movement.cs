using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_movement : MonoBehaviour {
    public Transform Tracked_object;
    public Transform Camera;
    public float Tx, Ty, Tz; // х1 у1 z1 - координаты камеры ; x2 y2 z2 - coordinates of object we track down
	// Use this for initialization
	void Start () {
		
	}
    Transform target;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;

    void Update()
    {
        float newPosition = Mathf.SmoothDamp(Tracked_object.position.y +2.0f, Tracked_object.position.y+2.0f, ref yVelocity, smoothTime);
        float newPosition1 = Mathf.SmoothDamp(Tracked_object.position.x, Tracked_object.position.x, ref yVelocity, smoothTime);
        Camera.position = new Vector3(newPosition1, newPosition, Camera.position.z);

        
        
    }
    void FixedUpdate()
    {
        //Tx = Tracked_object.position.x;
       // Ty = Tracked_object.position.y;
        //Tz = Tracked_object.position.z;

        

    }
}
