using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_transition : MonoBehaviour {
    public string level;
    public string player_name;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}


    public void Game_begining()
    {
        SceneManager.LoadScene(level);
    }

    public void Game_ending()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
