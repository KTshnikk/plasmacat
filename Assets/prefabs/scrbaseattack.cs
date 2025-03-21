using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.Search;
using System.Xml.Serialization;
using Unity.VisualScripting;

public class scrbaseattack : MonoBehaviour
{
    GameObject player;
    public GameObject[] baseattack = new GameObject[3];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CallFunctionTwice());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CallFunctionTwice()
    {
        yield return new WaitForSeconds(1);
        Instantiate(baseattack[1], new Vector2(baseattack[0].transform.position.x, baseattack[0].transform.position.y), Quaternion.identity);
        Instantiate(baseattack[2], new Vector2(baseattack[0].transform.position.x, baseattack[0].transform.position.y+0.7f), Quaternion.identity);
        baseattack[0].transform.position = new Vector2(300, 0);
        yield return new WaitForSeconds(0.5f);
        
        player = GameObject.Find("attack(Clone)");
        Destroy(player);
        player = GameObject.Find("hammer(Clone)");
        Destroy(player);
        Destroy(baseattack[0]);
    }
}
