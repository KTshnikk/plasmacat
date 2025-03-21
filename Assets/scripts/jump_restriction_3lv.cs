using UnityEngine;

public class jump_restriction_3lv : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private  void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<lv_3_Player>().is_jumping = false;
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
