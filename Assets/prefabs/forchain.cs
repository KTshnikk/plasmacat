using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.Search;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using System.Security.Cryptography.X509Certificates;
public class forchain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform chain;
    Transform player;
    float speed = 8f;
    float x;
    float y;
    void Start()
    {
        
        player =GameObject.Find("player-idle-1").transform;
        Vector3 direction = player.position - chain.position;
        // Вычисл. угол поворота
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        chain.rotation = Quaternion.Euler(0, 0, angle);
        x = player.transform.position.x; 
        y = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        chain.position= Vector2.MoveTowards(chain.position, new Vector2(x,y), speed* Time.deltaTime);

    }

}
