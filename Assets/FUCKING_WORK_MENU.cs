using UnityEngine;
using  UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class FUCKING_WORK_MENU : MonoBehaviour
{
    bool FUCKING_DIE_DEVELOPER = false;
   public int level;
public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("adadadadadadadadad");
       if(other.gameObject.tag == "Player" && FUCKING_DIE_DEVELOPER)
        {
         Debug.Log("KILLYOURSELF");
         FUCKING_DIE_DEVELOPER = true;
         SceneManager.LoadScene(level);
        }
        
    }
private void FixedUpdate() {

    if(Input.GetKeyDown(KeyCode.E))
        {
         Debug.Log("KILLYOURSELF");
         FUCKING_DIE_DEVELOPER = true;
        }
    
}
   
}
