using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.Search;
using System.Xml.Serialization;
using Unity.VisualScripting;

public class baseattacks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject start;
    public GameObject baseattack;
    public GameObject attack2;
    void Start()
    {
        
    }
    int numatt;
    void Update()
    {
        if (time1 && startor)//молоток бить
        {
            time1 = false;
                x = Random.Range(0, 4);
                if (x == 0) { y = 6.4013f; }
                if (x == 1) { y = 9.68f; }
                if (x == 2) { y = 12.89f; }
                if (x == 3) { y = 16.08f; }
                Instantiate(attack2, new Vector2(0, y), Quaternion.identity);
            StartCoroutine(fortime());
        } 
        if (time2 && startor)//полоска бить
        {
            time2 = false;
                x = Random.Range(-9.621277f, 15.69057f);
                y = Random.Range(5.46099f, 17.05123f);
                Instantiate(baseattack, new Vector2(x, y), Quaternion.identity);
            StartCoroutine(fortime1());
        }
        
    }
    bool time1=true, time2=true; 
    bool startor=false;
    IEnumerator fortime()//время для полоски
    {
        yield return new WaitForSeconds(2.2f);
        time1 = true;
    }
    IEnumerator fortime1()//время для молотка
    {
        yield return new WaitForSeconds(0.4f);
        time2 = true;
    }
    float y, x;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player-idle-1")
        {
            start.transform.position = new Vector2(-10.12f, 0);
            startor=true;
        }
    }
}
