using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class player : MonoBehaviour
{
    public Animator anim;
     public SpriteRenderer sr; 
     int speed = 8; 
     public Rigidbody2D Player_rb; 
     public Vector2 moveVector;
      bool jump=false;
      public float pushForce;
    public GameObject[] E = new GameObject[6];
    void Start()
    {
        Player_rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        E[1].SetActive(false); E[2].SetActive(false); E[3].SetActive(false); E[4].SetActive(false); E[0].SetActive(false); E[5].SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (jump))
        {
            jump = false;
            Player_rb.AddForce(Vector2.up * pushForce);
            anim.SetFloat("jumpanim", 1);
        }
    }
    void FixedUpdate()
    {
        move();
        flip();
        
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "floor") { jump = true; anim.SetFloat("jumpanim", 0); }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "tr1") { E[0].SetActive(true); }
        if (other.gameObject.name == "tr2") { E[1].SetActive(true); }
        if (other.gameObject.name == "tr3") { E[2].SetActive(true); }
        if (other.gameObject.name == "tr4") { E[3].SetActive(true); }
        if (other.gameObject.name == "tr5") { E[4].SetActive(true); }
        if (other.gameObject.name == "tr6") { E[5].SetActive(true); }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "tr1") { E[0].SetActive(false); }
        if (other.gameObject.name == "tr2") { E[1].SetActive(false); }
        if (other.gameObject.name == "tr3") { E[2].SetActive(false); }
        if (other.gameObject.name == "tr4") { E[3].SetActive(false); }
        if (other.gameObject.name == "tr5") { E[4].SetActive(false); }
        if (other.gameObject.name == "tr6") { E[5].SetActive(false); }
    }
    public void OnTriggerStay2D(Collider2D other)
     {
         //if ((other.gameObject.name == "tr1") && ((Input.GetKeyDown(KeyCode.E)) || (Input.GetKey(KeyCode.E)))){ SceneManager.LoadScene("FF"); }
         if ((other.gameObject.name == "tr2") && ((Input.GetKeyDown(KeyCode.E)) || (Input.GetKey(KeyCode.E)))) { SceneManager.LoadScene("3d_1_st_floor"); }
         if ((other.gameObject.name == "tr3") && ((Input.GetKeyDown(KeyCode.E)) || (Input.GetKey(KeyCode.E)))) { SceneManager.LoadScene("lv_phra"); }
         if ((other.gameObject.name == "tr4") && ((Input.GetKeyDown(KeyCode.E)) || (Input.GetKey(KeyCode.E)))) { SceneManager.LoadScene("FIP"); }
        //if ((other.gameObject.name == "tr5") && ((Input.GetKeyDown(KeyCode.E)) || (Input.GetKey(KeyCode.E)))) { SceneManager.LoadScene("FPP"); }
        if ((other.gameObject.name == "tr6") && ((Input.GetKeyDown(KeyCode.E)) || (Input.GetKey(KeyCode.E)))) { Application.Quit(); }
     }
    void move()
    {
        
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("HorizontalMove", Mathf.Abs(moveVector.x));
        Player_rb.linearVelocity = new Vector2(moveVector.x * speed, Player_rb.linearVelocity.y);
        
    }
    void flip()
    {
        sr.flipX = moveVector.x < 0;
    }
}
