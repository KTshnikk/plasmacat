using UnityEngine;
using UnityEngine.InputSystem;

public class brainfart_1 : MonoBehaviour
{
    public bool is_fixing_it;

    public string Key; // what key is needed to be pressed
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        is_fixing_it = false;
        Key = "";
    }
    

    public void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player" && is_fixing_it) {

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(Key) && !is_fixing_it){
            is_fixing_it = true;
        }
        if(Input.GetKeyDown(Key) && is_fixing_it){
            is_fixing_it = false;
        }
        
    }
}
