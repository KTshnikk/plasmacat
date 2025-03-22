using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class pressing_tracking : MonoBehaviour {
    
    public GameObject Lamp;
    public MeshRenderer mesh;
    public Rigidbody rb;
    public float speed;
    public float v;
    public float h;
    public float xInput;
    public float zInput;
    bool jumpRequest =true;
    private float pushForce=10;
    public int jumps = 0; // amount of jumps 
    public int hp = 100;
    //public Text hp_out; // переменная для вывода кол. хп на данный момент
    //public Text jumpcd;// переменная для вывода кол. прыжков на данный момент
    public string death_reset_level;
	// Use this for initialization
	void Start () {
        mesh = Lamp.GetComponent<MeshRenderer>();
        death_reset_level = "3d_1_st_floor";
	}
	
	// Update is called once per frame
	void Update () {
        rb.linearVelocity = transform.TransformDirection(new Vector3(v, rb.linearVelocity.y, h));
        if (Input.GetKeyDown(KeyCode.Space) && jumpRequest)
        {
            
                rb.AddForce(Vector3.up * pushForce, ForceMode.Impulse);
                jumpRequest = false;
        }
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Debug.Log("Кнопка нажата успешно");
        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    Debug.Log("Кнопка нажата успешно");
        //    mesh.color = Color.green;
        //}
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        //hp_out.text = Convert.ToString(hp);// Каждый кадр количество хп на экране будет отображаться
        //jumpcd.text = Convert.ToString(jumps);
	}
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "floor"|| other.gameObject.name == "floorFORQUEST") { jumpRequest = true; }
        if (other.gameObject.name == "tp") { SceneManager.LoadScene("3d_2_st_floor"); }
        if (other.gameObject.name == "end" ) { SceneManager.LoadScene("Main_menu");  }
    }    
    void FixedUpdate()
    {
        v = xInput * Time.fixedDeltaTime * speed;
        h = zInput * Time.fixedDeltaTime * speed;
        rb.linearVelocity = transform.TransformDirection(new Vector3(v, rb.linearVelocity.y, h));
        if (hp == 0)
        {
            SceneManager.LoadScene(death_reset_level);
        }
    }
}
