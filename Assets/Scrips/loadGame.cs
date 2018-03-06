using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadGame : MonoBehaviour {
    public float timer;
    public Scene scene;
    

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 3)
        {
            SceneManager.LoadScene("test1");
        }
        else timer += Time.deltaTime; 
		
	}
}
