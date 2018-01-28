using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class metalStats : MonoBehaviour {
    public float temperature, maxTemp, coldFactor;
    public bool warm, mold_1, mold_2, sharp;
    public Image tempBar;
    public GameObject bar;
    public faceCameraUpdate cameraI;
    public int metalSize;

    // Use this for initialization
    void Start () {
        warm = false;
        mold_1 = false;
        mold_2 = false;
        sharp = false;
        coldFactor = 5.0f;
        maxTemp = 100;
        bar = this.gameObject.transform.GetChild(0).gameObject;
        tempBar = bar.transform.GetChild(1).GetComponent<Image>();
        cameraI = bar.GetComponent<faceCameraUpdate>();
        cameraI.m_Camera = Camera.main;

        
    }

    // Update is called once per frame
    void Update() {
        if(temperature > 0)
        {
            bar.SetActive(true);
            warm = true;
            temperature -= coldFactor * Time.deltaTime;
            tempBar.fillAmount = temperature / maxTemp;
        }
        else
        {
            warm = false;
            bar.SetActive(false);
        }
		
	}

    public void getMold()
    {
        mold_1 = true;
        mold_2 = true;
    }

    public void getSharp()
    {
        sharp = true;
    }

    public void getWarm()
    {
        temperature = maxTemp;
    }
}
