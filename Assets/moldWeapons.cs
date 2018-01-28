using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moldWeapons : MonoBehaviour {

    public GameObject buttonB, buttonX, weaponBButton0, weaponXButton0, weaponBButton1, weaponXButton1, weaponBButton2, weaponXButton2, voidPrefab;
    //private playerStatus dummy;

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
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player_1" || col.gameObject.tag == "Player_2")
        {
            col.gameObject.transform.GetChild(2).GetComponent<playerStatus>().setMetalState();
        }
        //Debug.Log(col.gameObject);
        buttonB.SetActive(true);
        buttonX.SetActive(true);
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





    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.transform.GetChild(2).GetComponent<playerStatus>().metalSt.warm)
        {

        }
    }
}
