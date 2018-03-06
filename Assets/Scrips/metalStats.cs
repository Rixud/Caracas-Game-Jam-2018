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
    public GameObject ingotGraphic, ingotWarm, rawWeapon1, rawWeapon2, sharpWeapon1, sharpWeapon2;

    // Use this for initialization
    void Start() {
        warm = false;
        mold_1 = false;
        mold_2 = false;
        sharp = false;
        coldFactor = 1.0f;
        maxTemp = 100000;
        bar = this.gameObject.transform.GetChild(0).gameObject;
        tempBar = bar.transform.GetChild(1).GetComponent<Image>();
        cameraI = bar.GetComponent<faceCameraUpdate>();
        cameraI.m_Camera = Camera.main;


    }

    // Update is called once per frame
    void Update() {
        if (temperature > 0)
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
            updateGraphics();
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

    public void updateGraphics()
    {
        if (!warm && !mold_1 && !mold_2 && !sharp)
        {
            ingotGraphic.SetActive(true);
            ingotWarm.SetActive(false);
        }
        else if (warm && !mold_1 && !mold_2 && !sharp)
        {
            ingotGraphic.SetActive(false);
            ingotWarm.SetActive(true);
        } else if (mold_1 && !sharp)
        {
            ingotWarm.SetActive(false);
            rawWeapon1.SetActive(true);
        } else if (mold_2 && !sharp)
        {
            ingotWarm.SetActive(false);
            rawWeapon2.SetActive(true);
        } else if (mold_1 && sharp)
        {
            rawWeapon1.SetActive(false);
            sharpWeapon1.SetActive(true);
        } else if (mold_2 && sharp)
        {
            rawWeapon2.SetActive(false);
            sharpWeapon2.SetActive(true);
        }
        else
        {
            Debug.Log("Graphic not updated " + warm + mold_1 + mold_2 + sharp);
        }
        if(sharp)
        {
            this.transform.parent.GetComponent<playerStatus>().instaChild();
            Destroy(this.gameObject, 1);
        }
    }
}
