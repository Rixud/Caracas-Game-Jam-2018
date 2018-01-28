using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropOnOven : MonoBehaviour {

    public metalPicker metalPick;
    public Transform ovenPosition;
    public bool metalInOven, metalHot;
    public float warmTime, maxTime, hotForce;
    public GameObject metalOnOven, hand, voidPrefab;
    public ovenHeater o_Heater;
    public playerStatus player1;
    public metalStats metalSt;

    // Use this for initialization
    void Start () {
        metalInOven = false;
        warmTime = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(metalInOven)
        {
            if(warmTime<maxTime)
            {
                warmTime += Time.deltaTime*hotForce* (o_Heater.heat / o_Heater.maxHeat) ;
            }
            else
            {
                metalHot = true;
                metalSt.getWarm();

            }
            
        }

    }

    void OnTriggerStay(Collider col)
    {
        if(metalPick.metalPicked.tag == "Metal" && !metalInOven)
        {
            #region A
            if (col.tag == "Player_1" && Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                Debug.Log("Intento Dejar en el Horno");
                metalPick.metalPicked.transform.position = new Vector3(ovenPosition.position.x, ovenPosition.position.y, ovenPosition.position.z);
                metalPick.metalPicked.transform.parent = null;
                metalOnOven = metalPick.metalPicked.gameObject;
                metalSt = metalOnOven.GetComponent<metalStats>();
                
                player1.itemInHand = voidPrefab;
                metalInOven = true;
            }

            #endregion
        }

        if (metalInOven && metalHot)
        {
            #region A
            if (col.tag == "Player_1" && Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                Debug.Log("Intento Agarra del Horno");
                player1.itemInHand = metalOnOven;
                metalOnOven.transform.position = hand.transform.position;
                metalOnOven.transform.parent = hand.transform;

                metalOnOven = voidPrefab;
                warmTime = 0;
                metalInOven = false;
            }

            #endregion
        }

    }


}
