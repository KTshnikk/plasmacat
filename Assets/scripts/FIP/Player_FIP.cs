using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.Search;
using System.Xml.Serialization;
using Unity.VisualScripting;

public class player_FIP : MonoBehaviour
{
    public Animator anim;
    public GameObject wrong;
    public GameObject[] door = new GameObject[4];//����� � �������
    public GameObject[] health = new GameObject[3];//��������
    public GameObject[] bosshealth = new GameObject[3];//��������
    public GameObject[] answer = new GameObject[4];//������ � ������ ��� 4� �������
    public TextMeshProUGUI[] answerT=new TextMeshProUGUI[3];
    public SpriteRenderer sr;
    int speed = 8;
    public Rigidbody2D Player_rb;
    public Vector2 moveVector;
    bool jump = false;
    public float pushForce;
    public Camera cam;
    public Transform target;
    int HP;
    public GameObject baseatt;
    public GameObject Gchain;
    void Start()
    {
        bosshp = 3;
        questactive = false;
        turn = 1; HP = 3;
        Player_rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        door[0].SetActive(false); door[1].SetActive(false); door[2].SetActive(false);
        answer[0].SetActive(false); answer[1].SetActive(false); answer[2].SetActive(false); answer[3].SetActive(false);
    }
    float time;
    float x, y;
    void createchain()
    {
            x = Random.Range(0, 4);
            if (x == 0) { y = 6.4013f; }
            if (x == 1) { y = 9.68f; }
            if (x == 2) { y = 12.89f; }
            if (x == 3) { y = 16.08f; }
            if (x % 2 == 0)
            {
                Instantiate(Gchain, new Vector2(-23.66f, y), Quaternion.identity);
            }
            else
            {
                Instantiate(Gchain, new Vector2(29.72f, y), Quaternion.identity);
            }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (jump) && (Player_rb.linearVelocityY < 1 && (Player_rb.linearVelocityY > -1)))
        {
            jump = false;
            Player_rb.AddForce(Vector2.up * pushForce);
            anim.SetFloat("jumpanim", 1);
        }
        if (Input.GetKeyDown(KeyCode.S))//for fall
        {
            Physics2D.IgnoreLayerCollision(7, 6, true);
            Invoke("IgnoreLay", 0.3f);
        }
        if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha1)) && (questactive))// ������ ������(���� ������� ���� �� 1 ������)
        {
            questactive = false;
            if (turn == 2)
            {
                bossgetdamage();
                turn = 3; wrong.transform.position = new Vector2(3222.38f, 15.92f);
            }
            else {
                wrong.transform.position = new Vector2(-3.09f, 12.38f); tuda = Player_rb.position; createchain(); StartCoroutine(forchaindes());
            }
            StartCoroutine(cdquest());
            answer[0].SetActive(false); answer[1].SetActive(false); answer[2].SetActive(false); answer[3].SetActive(false);
        }

        if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha2)) && (questactive))//������ ������(���� ������� ���� �� 2 ������)
        {
            questactive = false;
            if (turn == 1) { bossgetdamage(); turn = 2; wrong.transform.position = new Vector2(3222.38f, 15.92f); }
            else { wrong.transform.position = new Vector2(3.38f, 15.92f); tuda =  Player_rb.position; createchain(); StartCoroutine(forchaindes()); }
            answer[0].SetActive(false); answer[1].SetActive(false); answer[2].SetActive(false); answer[3].SetActive(false);
            StartCoroutine(cdquest());
        }

        if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha3)) && (questactive))// ������� ������(���� ������� ���� �� 3 ������)
        {
            questactive = false;
            if (turn == 3) { bossgetdamage(); }
            else { wrong.transform.position = new Vector2(8.58f, 12.46f); tuda =  Player_rb.position; createchain(); StartCoroutine(forchaindes()); }
            answer[0].SetActive(false); answer[1].SetActive(false); answer[2].SetActive(false); answer[3].SetActive(false);
            StartCoroutine(cdquest());

        }

    }
    
    IEnumerator fortime()//������������
    {
        anim.SetFloat("hit", 1);
        yield return new WaitForSeconds(2);
        anim.SetFloat("hit", 0);
        time = 0;
    }
    int turn;
    bool questactive;
    IEnumerator cdquest()//перезарядка ответов
    {
        if (turn == 1)
        {
            yield return new WaitForSeconds(3);
            answer[0].SetActive(true); answer[1].SetActive(true); answer[2].SetActive(true); answer[3].SetActive(true);
            answerT[0].text = "Суд";//Ответ 1.1
            answerT[1].text = "Право";//Ответ 1.2(Правильный)
            answerT[2].text = "Нормы";//Ответ 1.3
            answerT[3].text = "Что регулирует отношения в государстве и является стезей юриста??";//Вопрос 1 \r\n
            questactive =true;
            
        }
        if (turn == 2) {
            yield return new WaitForSeconds(5);
            answer[0].SetActive(true); answer[1].SetActive(true); answer[2].SetActive(true); answer[3].SetActive(true);
            answerT[0].text = "Адвокат";//Ответ 2.1(Привильный)
            answerT[1].text = "Показания";//Ответ 2.2
            answerT[2].text = "Догадки";//Ответ 2.3
            answerT[3].text = "Кто в суде защищает права и интересы подсудимого?";//Вопрос 2
            questactive = true;
        }
        if (turn == 3)
        {
            yield return new WaitForSeconds(5);
            answer[0].SetActive(true); answer[1].SetActive(true); answer[2].SetActive(true); answer[3].SetActive(true);
            answerT[0].text = "Адвокат";//Ответ 3.1
            answerT[1].text = "Прокурор";//Ответ 3.2
            answerT[2].text = "Судья";//Ответ 3.3(Правильный)
            answerT[3].text = "Кто является лицом, выносящим приговор в суде?";//Вопрос 3
            questactive = true;
        }
    }
    void IgnoreLay()
    {
        Physics2D.IgnoreLayerCollision(7, 6, false);
    }
    public LayerMask ground;
    bool forcam = false;
    bool stopchain = false;
    public void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.name == "Start")//��� �� ������ ������������� �� �����
        {
            forcam = true;
            door[0].SetActive(true); door[1].SetActive(true); door[2].SetActive(true);
            cam.orthographicSize = 7.4f;
            StartCoroutine(cdquest());
        }

        if (other.gameObject.name == "chain(Clone)")//��� �� ������ ������������� �� �����
        {
            Instantiate(baseatt, Player_rb.position, Quaternion.identity);
            stopchain = true;
            StartCoroutine (forchain());
        }
        if ((other.gameObject.name == "attack(Clone)"|| other.gameObject.name == "attackline(Clone)" || other.gameObject.name == "boss" || other.gameObject.name == "wrong") &&time==0)//����� � �������� �� ������������
        {
            getdamage();
            time = 1;
            StartCoroutine(fortime());
        }
    }
    GameObject chaindestr;
    IEnumerator forchaindes()
    {
        yield return new WaitForSeconds(3);
        chaindestr = GameObject.Find("chain(Clone)");
        Destroy(chaindestr);
        /*GameObject chaincl = GameObject.Find("chain(Clone)").transform;
        Destroy(chaincl);*/
    }
    IEnumerator forchain()
    {
        anim.SetFloat("stan", 1);
        yield return new WaitForSeconds(2);
        stopchain = false; anim.SetFloat("stan", 0);
        chaindestr = GameObject.Find("chain(Clone)");
        Destroy(chaindestr);
        /*GameObject chaincl = GameObject.Find("chain(Clone)").transform;
        Destroy(chaincl);*/
    }
    public void getdamage()
    {
        HP--;
        health[HP].SetActive(false);
        if (HP == 0) { SceneManager.LoadScene("FIP"); }//������
    }
    int bosshp;
    public void bossgetdamage()
    {
        bosshp--;
        bosshealth[bosshp].SetActive(false);
        if (bosshp == 0) { SceneManager.LoadScene("Main_menu"); }//������
    }
    void FixedUpdate()
    {   if (!stopchain)
        {move();
            flip();
        }
    else { Player_rb.linearVelocity = new Vector2(0, 0); }
        if (forcam)// ��� �������.������
        {
             {
                cam.transform.position = Vector3.Lerp(cam.transform.position, target.position, 3/*��������*/ * Time.deltaTime);

            }
        }
        wrong.transform.position = Vector3.Lerp(wrong.transform.position, Player_rb.position, 0.2f/*��������*/ * Time.deltaTime);

    }

    Vector2 tuda;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "floor") { jump = true; anim.SetFloat("jumpanim", 0); }
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
