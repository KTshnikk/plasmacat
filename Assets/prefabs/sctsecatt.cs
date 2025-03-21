using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.Search;
using System.Xml.Serialization;
using Unity.VisualScripting;
public class sctsecatt : MonoBehaviour
{
    GameObject player;
    public GameObject[] baseattack = new GameObject[2];
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
        yield return new WaitForSeconds(1);
        Destroy(baseattack[0]);
        player = GameObject.Find("attackline(Clone)");
        Destroy(player);
    }
}
