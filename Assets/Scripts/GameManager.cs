using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("f1")) {
            StartBattle();
        }
	}

    void StartBattle()
    {
        SceneManager.LoadScene("Battle");
    }
}
