using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.Search;
using System.Xml.Serialization;
using Unity.VisualScripting;
using System;

public class MoveCat : MonoBehaviour
{
    float Speed = 200.0f;
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider;
    float jump_heigh = 12f;
    float horizontal_movement = 0.01f;
    private float oldPosition;
    private float oldPosition2;
    float Distx; public Animator anim;
    bool space;
    public GameObject[] butqte= new GameObject[4];//0 - пробел, 1 - А, 2 - S, 3 - D
    GameObject bufer;
    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();  
        anim= GetComponent<Animator>();
        oldPosition = transform.position.x;
        oldPosition2 = oldPosition;
    }
    private void Update()
    {
        if (!Bqte)
        {   
            if (Input.GetKeyDown(KeyCode.Space)&&space)
            {
                anim.SetFloat("jump", 1);
                _rb.AddForce(new Vector3(3, jump_heigh, 0), ForceMode2D.Impulse);
                space = false;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _boxCollider.size = new Vector2(0.530636f, 0.1006853f);
                anim.SetFloat("jump", 1);
            }
            else
            if (Input.GetKeyUp(KeyCode.S))
            {
                _boxCollider.size = new Vector2(0.530636f, 0.2006853f);
                anim.SetFloat("jump", 0);
            }
        }
        else
        {

            if (rand == 0 && Input.GetKeyDown(KeyCode.Space))
            {
                bufer= GameObject.Find("SPACE(Clone)");
                Destroy(bufer); count++;
            }
            if ((rand == 1|| rand == 2 || rand == 3 ) && Input.GetKeyDown(KeyCode.Space))
            {
                gameOver();
            }
            if (rand == 1 && Input.GetKeyDown(KeyCode.A))
            {
                bufer = GameObject.Find("A(Clone)");
                Destroy(bufer); count++;
            }
            if ((rand == 0 || rand == 2 || rand == 3) && Input.GetKeyDown(KeyCode.A))
            {
                gameOver();
            }
            if (rand == 2 && Input.GetKeyDown(KeyCode.S))
            {
                bufer = GameObject.Find("S(Clone)");
                Destroy(bufer); count++;
            }
            if ((rand == 1 || rand == 0 || rand == 3) && Input.GetKeyDown(KeyCode.S))
            {
                gameOver();
            }
            if (rand == 3 && Input.GetKeyDown(KeyCode.D))
            {
                bufer = GameObject.Find("D(Clone)");
                Destroy(bufer); count++;
            }
            if ((rand == 1 || rand == 2 || rand == 0) && Input.GetKeyDown(KeyCode.D))
            {
                gameOver();
            }
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Jump" || other.gameObject.name == "Crawl")
        {
            Bqte = true;
            StartCoroutine(forqte());
        }
    }
    bool Bqte =false;
    int rand;
    int count = 0;


    IEnumerator forqte()//1.5 * 4 секнд даётся на выполнение qte иначе поражение
    {
        anim.SetFloat("work", 1);
        qte(); yield return new WaitForSeconds(1.5f);
        qte(); yield return new WaitForSeconds(1.5f);
        qte(); yield return new WaitForSeconds(1.5f);
        qte(); yield return new WaitForSeconds(1.5f);
        
        anim.SetFloat("work", 0);
    }
    public void qte()
    {
        rand = UnityEngine.Random.Range(0, 4);
        Instantiate(butqte[rand], new Vector2(UnityEngine.Random.Range(0, 4)+ _rb.position.x, UnityEngine.Random.Range(0, 4) + _rb.position.y), Quaternion.identity);
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Ground") { space = true; anim.SetFloat("work", 0); }
    }
    private void FixedUpdate()
    {   if (!Bqte)
        {
            Speed = 400;
            CatSpeed();
            Move();
        }
        else
        {
            
            Speed = 0;
        }
    }
    private void Move ()
    {
        transform.position += new Vector3(horizontal_movement, 0, 0) * Time.fixedDeltaTime * Speed; 
    }

    private void CatSpeed()
    {
        Distx = Mathf.Abs(transform.position.x - oldPosition2);  
        if (Distx > 10)
        {
            Speed += 25;
            oldPosition2 = transform.position.x;
        }
    }

    private void gameOver()
    {
        SceneManager.LoadScene("lv_phra");
    }
}