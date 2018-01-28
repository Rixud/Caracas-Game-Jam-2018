using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sharpWeapon : MonoBehaviour {
    public grindSpin grindSpin;
    public snapOnSite thisSnap;
    public float sharpForce, sharpMeter, goodSharp;
    public Image sharpBar;
    public GameObject fill, fillBG;
    

    // Use this for initialization
    void Start () {
        sharpMeter = 0;
        sharpBar.fillAmount = sharpMeter / goodSharp;
        fill.SetActive(false);
        fillBG.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
        if (grindSpin.isSpinning && Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            sharpMeter += sharpForce;
            sharpBar.fillAmount = sharpMeter / goodSharp;

        }
        if (sharpMeter > goodSharp)
        {
            isSharp();

        }

    }
     void isSharp()
    {
        sharpMeter = 0;
        sharpBar.fillAmount = sharpMeter / goodSharp;

        //Spawn o Cambio de Arma
    }

    void OnTriggerEnter(Collider col)
    {
        fill.SetActive(true);
        fillBG.SetActive(true);
    }


    void OnTriggerExit(Collider col)
    {
        fill.SetActive(false);
        fillBG.SetActive(false);
    }
}
