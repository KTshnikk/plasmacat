using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggers : MonoBehaviour {
    public MeshRenderer BEEEP;
    public pressing_tracking player;
    public string player_name;
	// Use this for initialization
	void Start () {
		
	}
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Physics_test")
    //    {
    //        Debug.Log("Есть столкновение");
    //        BEEEP.material.color = Color.red;

    //    }
    //}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == player_name)
        {
            Debug.Log("Игрок в ловушке");
           //BEEEP.material.color = Color.red;
            if (player.hp > 0)
            {
                BEEEP.material.color = Color.red;
                player.hp = player.hp - 100;
            }
            

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Physics_test")
        {
            Debug.Log("Есть столкновение");
            BEEEP.material.color = Color.white;

        }

    }
	void Update () {
		
	}
}
