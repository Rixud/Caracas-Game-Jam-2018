using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreUI : MonoBehaviour {
    public Text scoreText;
    public float score;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "$$ Gold $$: " + ((int)score).ToString();
    }

    public void AddGold()
    {
        score += Random.Range(120, 175);
    }
}
