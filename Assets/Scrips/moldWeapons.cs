using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moldWeapons : MonoBehaviour {

    public GameObject buttonB, buttonX, weaponBButton0, weaponXButton0, weaponBButton1, weaponXButton1, weaponBButton2, weaponXButton2, voidPrefab;
    //private playerStatus dummy;
    public bool stillWarm;
    public Image moldBar;
    public GameObject fill, fillBG;
    public float moldForce, maxMold, mold;
    public int hittingXB = 0;
    public metalStats metalSt;

    // Use this for initialization
    void Start ()
    {
        buttonB.SetActive(false);
        buttonX.SetActive(false);
        weaponBButton0.SetActive(false);
        weaponXButton0.SetActive(false);
        weaponBButton1.SetActive(false);
        weaponXButton1.SetActive(false);
        weaponBButton2.SetActive(false);
        weaponXButton2.SetActive(false);
        fill.SetActive(false);
        fillBG.SetActive(false);
        stillWarm = false;
        mold = 0;
        moldBar.fillAmount = mold / maxMold;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            if (hittingXB == 0)
            {
                hittingXB = 1;
                moldBar.color = Color.red;
            }
            else if (hittingXB == 2)
            {
                hittingXB = 1;
                moldBar.color = Color.red;
                mold = 0;
            }
            else Debug.Log("aqui la tas cagando");
        } else if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            if (hittingXB == 0)
            {
                hittingXB = 2;
                moldBar.color = Color.blue;

            }
            else if (hittingXB == 1)
            {
                hittingXB = 2;
                moldBar.color = Color.blue;
                mold = 0;
            }
        }
        else //Debug.Log("no agarra imputs para el reinicio de barra");

        
		if (stillWarm && (hittingXB == 1||hittingXB == 2) && (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2)) && !metalSt.mold_1 && !metalSt.mold_2)
            {
                mold += moldForce;
                moldBar.fillAmount = mold / maxMold;
            }
       
                
            if (mold > maxMold)
            {
                isMold();
            }     
        }
	

    void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.tag == "Player_2")
        {
            col.gameObject.transform.GetChild(2).GetComponent<playerStatus>().setMetalState();
            metalSt = col.gameObject.transform.GetChild(2).GetComponent<playerStatus>().metalSt;
            Debug.Log("Choca "+ col.gameObject);
        }
        //Debug.Log(col.gameObject);
        buttonB.SetActive(true);
        buttonX.SetActive(true);
        fill.SetActive(true);
        fillBG.SetActive(true);
        if (col.gameObject.transform.GetChild(2).GetComponent<playerStatus>().itemInHand.tag == "Metal")
        {
            if (col.gameObject.transform.GetChild(2).GetComponent<playerStatus>().metalSt.metalSize == 0)
            {
                weaponBButton0.SetActive(true);
                weaponXButton0.SetActive(true);
            }
            else if (col.gameObject.transform.GetChild(2).GetComponent<playerStatus>().metalSt.metalSize == 1)
            {
                weaponBButton1.SetActive(true);
                weaponXButton1.SetActive(true);
            }
            else if (col.gameObject.transform.GetChild(2).GetComponent<playerStatus>().metalSt.metalSize == 2)
            {
                weaponBButton2.SetActive(true);
                weaponXButton2.SetActive(true);
            }
            else Debug.Log("no metal State "+ col.gameObject.transform.GetChild(2).GetComponent<playerStatus>().metalSt.metalSize);
        }
       // else Debug.Log("Void Hand");


    }

    void OnTriggerExit(Collider col)
    {
        
        buttonB.SetActive(false);
        buttonX.SetActive(false);
        weaponBButton0.SetActive(false);
        weaponXButton0.SetActive(false);
        weaponBButton1.SetActive(false);
        weaponXButton1.SetActive(false);
        weaponBButton2.SetActive(false);
        weaponXButton2.SetActive(false);
        fill.SetActive(false);
        fillBG.SetActive(false);
        mold = 0;
        moldBar.fillAmount = mold / maxMold;






    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log(metalSt);
        if (metalSt.warm && (!metalSt.mold_1 || !metalSt.mold_2))
        {
            stillWarm = true;
        }
        else
        {
            stillWarm = false;
        }
    }

    public void isMold()
    {
        mold = 0;
        if (hittingXB == 1)
        {
            metalSt.mold_1 = true;
            metalSt.updateGraphics();
        }
        else if (hittingXB == 2)
        {
            metalSt.mold_2 = true;
            metalSt.updateGraphics();
        }
        // Mandar update al Metal
        moldBar.fillAmount = mold / maxMold;
    }

}
