using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ovenHeater : MonoBehaviour {
    public snapOnSite thisSnap;
    public float heat, heatForce, maxHeat;
    public Image heatBar;

    // Use this for initialization
    void Start () {
        heat = 0;
        heatBar.fillAmount = heat / maxHeat;

    }
	
	// Update is called once per frame
	void Update () {
              

        if (thisSnap.isSnaped && Input.GetKeyDown(KeyCode.Joystick2Button0) && heat < maxHeat )
        {
            heat += heatForce;
            if(heat > maxHeat)
            {
                heat = maxHeat;
            }
        }

        if (heat > 0)
        {
            heat -= Time.deltaTime;
            heatBar.fillAmount = heat / maxHeat;
        }
        if (heat < 0)
        {
            heat = 0;
        }
        //Debug.Log("Heat is " + heat);

    }
}
