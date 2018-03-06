using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropOnTable : MonoBehaviour {
    public playerStatus playerStatus_1, playerStatus_2;
    public Transform tablePosition;
    public bool objecOnTable, enterFor;
    public GameObject objectOn, hand_1, hand_2, voidPrefab;
    public float timer = 0;
    public GameObject buttonA_1, buttonA_2;


    // Use this for initialization
    void Start()
    {
        objecOnTable = false;
        enterFor = true;
        buttonA_1.SetActive(false);
        buttonA_2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!enterFor)
        {
            timer += Time.deltaTime; 
            if(timer>0.3)
            {
                timer = 0;
                enterFor = true;
            }
        }

    }

    void OnTriggerStay(Collider col)
    {
        if (enterFor)
        {
            if (col.tag == "Player_1" && Input.GetKeyUp(KeyCode.Joystick1Button0) && playerStatus_1.itemInHand.tag != "Void" && objectOn.tag == "Void")
            {
                Debug.Log("1 Intenta Dejar en MESA" + Time.timeSinceLevelLoad);
                playerStatus_1.itemInHand.transform.position = new Vector3(tablePosition.position.x, tablePosition.position.y, tablePosition.position.z);
                playerStatus_1.itemInHand.transform.parent = null;
                objectOn = playerStatus_1.itemInHand.gameObject;
                playerStatus_1.itemInHand = voidPrefab;
                objecOnTable = true;
                enterFor = false;
            }
            else if (col.tag == "Player_2" && Input.GetKeyUp(KeyCode.Joystick2Button0) && playerStatus_2.itemInHand.tag != "Void" && objectOn.tag == "Void")
            {
                Debug.Log("2 Intenta Dejar en MESA" + Time.timeSinceLevelLoad);
                playerStatus_2.itemInHand.transform.position = new Vector3(tablePosition.position.x, tablePosition.position.y, tablePosition.position.z);
                playerStatus_2.itemInHand.transform.parent = null;
                objectOn = playerStatus_2.itemInHand.gameObject;
                playerStatus_2.itemInHand = voidPrefab;
                objecOnTable = true;
                enterFor = false;

            }
            else if (col.tag == "Player_1" && Input.GetKeyUp(KeyCode.Joystick1Button0) && playerStatus_1.itemInHand.tag == "Void" && objectOn.tag != "Void")
            {
                Debug.Log("1 Intento Agarrar de MESA" + objectOn + " y deja un void... ");
                objectOn.transform.position = hand_1.transform.position;
                objectOn.transform.parent = hand_1.transform;
                playerStatus_1.itemInHand = objectOn;
                objectOn = voidPrefab;
                objecOnTable = false;
                enterFor = false;

            }
            else if (col.tag == "Player_2" && Input.GetKeyUp(KeyCode.Joystick2Button0) && playerStatus_2.itemInHand.tag == "Void" && objectOn.tag != "Void")
            {
                Debug.Log("2 Intento Agarrar de MESA " + objectOn + " y deja un void... ");
                objectOn.transform.position = hand_2.transform.position;
                objectOn.transform.parent = hand_2.transform;
                playerStatus_2.itemInHand = objectOn;
                objectOn = voidPrefab;
                objecOnTable = false;
                enterFor = false;
            }
            else
            {
                Debug.Log("No deja hacer un co!!!!");
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player_1")
        {
            buttonA_1.SetActive(true);
        }
        else if(col.tag == "Player_2")
        {
            buttonA_2.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player_1")
        {
            buttonA_1.SetActive(false);
        }
        else if (col.tag == "Player_2")
        {
            buttonA_2.SetActive(false);
        }
    }
}
