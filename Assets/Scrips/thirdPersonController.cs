using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonController : MonoBehaviour {

    private CharacterController charController;

    public float speedMovement;
    public Vector3 speed;

    //private int controllerNumber;

    // Use this for initialization
    void Start () {
        charController = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {
        speed = new Vector3(Input.GetAxis("Horizontal") * speedMovement, 0, Input.GetAxis("Vertical") * speedMovement);
        charController.Move(speed * Time.deltaTime);
        if (speed != Vector3.zero)
        {
            Quaternion quat = Quaternion.LookRotation(speed);
            transform.rotation = quat;
        }
            
       /* string foo= "";
        string[] vaina = Input.GetJoystickNames();
        int i = 0;
        foreach (var item in vaina)
        {
            
            foo += i + " "+item + "\n";
            ++i;
        }
         print(foo + "\nNum: " + vaina.Length);
        //print(Input.anyKeyDown);*/


        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.K))
            {
            //Debug.Log("apretas A en J1");
            
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) )
        {
            //Debug.Log("apretas X en J1");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) )
        {
            //Debug.Log("apretas B en J1");
        }

 
    }
}
