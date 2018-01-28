using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapOnSite : MonoBehaviour {
    public GameObject snapPoint, buttonA, buttonB, buttonX;
    public bool isSnaped, pressA, pressB, pressX;
    private Collider collider;
    public int buttonSelected;

    // Use this for initialization
    void Start() {

        isSnaped = false;
        buttonA.SetActive(false);
        buttonB.SetActive(false);
        buttonX.SetActive(false);
        collider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update() {
        if (isSnaped && (Input.GetAxis("Horizontal_2") != 0 || Input.GetAxis("Vertical_2") != 0))
        {
            isSnaped = false;
            //collider.enabled = true;
        }

        if (isSnaped && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            isSnaped = false;
            //collider.enabled = true;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        #region A
        if (buttonSelected == 0)
        {
            buttonA.SetActive(true);
            pressA = true;
            buttonB.SetActive(false);
            pressB = false;
            buttonX.SetActive(false);
            pressX = false;

        }
        #endregion
        #region B
        if (buttonSelected == 1)
        {
            buttonA.SetActive(false);
            pressA = false;
            buttonB.SetActive(true);
            pressB = true;
            buttonX.SetActive(false);
            pressX = false;

        }
        #endregion
        #region X
        if (buttonSelected == 2)
        {
            buttonA.SetActive(false);
            pressA = false;
            buttonB.SetActive(false);
            pressB = false;
            buttonX.SetActive(true);
            pressX = true;

        }
        #endregion
    }

    void OnTriggerExit(Collider col)
    {
        buttonA.SetActive(false);
        buttonB.SetActive(false);
        buttonX.SetActive(false);

    }

    void OnTriggerStay(Collider col)
    {
        #region A
        if (buttonSelected == 0)
        {
            //Debug.Log(this.name+" "+col.tag);
            if (col.tag == "Player_2" && Input.GetKeyDown(KeyCode.Joystick2Button0) && !isSnaped)
            {
                isSnaped = true;
                col.gameObject.transform.position = new Vector3(snapPoint.transform.position.x, col.transform.position.y, snapPoint.transform.position.z);
                col.gameObject.transform.rotation = snapPoint.transform.rotation;
                //collider.enabled = false;

            }

            if (col.tag == "Player_1" && Input.GetKeyDown(KeyCode.Joystick1Button0) && !isSnaped)
            {
                isSnaped = true;
                col.gameObject.transform.position = new Vector3(snapPoint.transform.position.x, col.transform.position.y, snapPoint.transform.position.z);
                col.gameObject.transform.rotation = snapPoint.transform.rotation;
                // collider.enabled = false;

            }
        }
        #endregion

        #region B
        if (buttonSelected == 1)
        {
            //Debug.Log(this.name+" "+col.tag);
            if (col.tag == "Player_2" && Input.GetKeyDown(KeyCode.Joystick2Button1) && !isSnaped)
            {
                isSnaped = true;
                col.gameObject.transform.position = new Vector3(snapPoint.transform.position.x, col.transform.position.y, snapPoint.transform.position.z);
                col.gameObject.transform.rotation = snapPoint.transform.rotation;
                //collider.enabled = false;

            }

            if (col.tag == "Player_1" && Input.GetKeyDown(KeyCode.Joystick1Button1) && !isSnaped)
            {
                isSnaped = true;
                col.gameObject.transform.position = new Vector3(snapPoint.transform.position.x, col.transform.position.y, snapPoint.transform.position.z);
                col.gameObject.transform.rotation = snapPoint.transform.rotation;
                // collider.enabled = false;

            }
        }
        #endregion

        #region X
        if (buttonSelected == 2)
        {
            //Debug.Log(this.name+" "+col.tag);
            if (col.tag == "Player_2" && Input.GetKeyDown(KeyCode.Joystick2Button2) && !isSnaped)
            {
                isSnaped = true;
                col.gameObject.transform.position = new Vector3(snapPoint.transform.position.x, col.transform.position.y, snapPoint.transform.position.z);
                col.gameObject.transform.rotation = snapPoint.transform.rotation;
                //collider.enabled = false;

            }

            if (col.tag == "Player_1" && Input.GetKeyDown(KeyCode.Joystick1Button2) && !isSnaped)
            {
                isSnaped = true;
                col.gameObject.transform.position = new Vector3(snapPoint.transform.position.x, col.transform.position.y, snapPoint.transform.position.z);
                col.gameObject.transform.rotation = snapPoint.transform.rotation;
                // collider.enabled = false;

            }
        }
        #endregion


    }

    public void changeButton(int to)
    {
        buttonSelected = to;
        #region Images
        if (buttonSelected == 0)
        {
            buttonA.SetActive(true);
            pressA = true;
            buttonB.SetActive(false);
            pressB = false;
            buttonX.SetActive(false);
            pressX = false;

        }
        if (buttonSelected == 1)
        {
            buttonA.SetActive(false);
            pressA = false;
            buttonB.SetActive(true);
            pressB = true;
            buttonX.SetActive(false);
            pressX = false;

        }
        if (buttonSelected == 2)
        {
            buttonA.SetActive(false);
            pressA = false;
            buttonB.SetActive(false);
            pressB = false;
            buttonX.SetActive(true);
            pressX = true;

        }
        #endregion
    }



}
