using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class jump_restriction : MonoBehaviour {
    //public pressing_tracking player;
     //public string player_name;
	// Use this for initialization
	void Start () {
		//player = GetComponent<pressing_tracking>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Есть приземление на пол");
            other.gameObject.GetComponent<pressing_tracking>().jumps = 1;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Есть приземление на пол");
            //player.jumps = 0;

        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
