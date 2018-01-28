using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSnap : MonoBehaviour
{
    public GameObject snapPoint;
    public bool isSnaped, pressA, pressB, pressX;
    //private Collider collider;
    public int buttonSelected;

    // Use this for initialization
    void Start()
    {

        isSnaped = false;
        //collider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
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




    void OnTriggerStay(Collider col)
    {

        //Debug.Log(this.name+" "+col.tag);
        if (col.tag == "Player_2" && !isSnaped && (Input.GetKeyDown(KeyCode.Joystick2Button2)|| Input.GetKeyDown(KeyCode.Joystick2Button1)))
        {
            isSnaped = true;
            col.gameObject.transform.position = new Vector3(snapPoint.transform.position.x, col.transform.position.y, snapPoint.transform.position.z);
            col.gameObject.transform.rotation = snapPoint.transform.rotation;
            //collider.enabled = false;

        }

    } 
}

  