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
    public metalStats metalSt;
    public scoreUI score;

    // Use this for initialization
    void Start () {
        sharpMeter = 0;
        sharpBar.fillAmount = sharpMeter / goodSharp;
        fill.SetActive(false);
        fillBG.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
        if (grindSpin.isSpinning && Input.GetKeyDown(KeyCode.Joystick1Button2) && (metalSt.mold_1 || metalSt.mold_2) && !metalSt.sharp )
        {
            sharpMeter += sharpForce;
            sharpBar.fillAmount = sharpMeter / goodSharp;

        }
        if (sharpMeter > goodSharp)
        {
            isSharp();
            score.AddGold();

        }

    }
     public void isSharp()
    {
        sharpMeter = 0;
        sharpBar.fillAmount = sharpMeter / goodSharp;
        metalSt.sharp = true;
        metalSt.updateGraphics();

        //Spawn o Cambio de Arma
    }

    void OnTriggerEnter(Collider col)
    {
        metalSt = col.gameObject.transform.GetChild(2).GetComponent<playerStatus>().metalSt;
        fill.SetActive(true);
        fillBG.SetActive(true);
    }


    void OnTriggerExit(Collider col)
    {
        fill.SetActive(false);
        fillBG.SetActive(false);
    }
}
