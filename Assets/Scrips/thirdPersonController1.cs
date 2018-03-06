using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonController1 : MonoBehaviour {

    private CharacterController charController;

    public float speedMovement;
    public Vector3 speed;
    public Animator anim;

    private int controllerNumber;

    // Use this for initialization
    void Start () {
        charController = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {
        speed = new Vector3(Input.GetAxis("Horizontal_2") * speedMovement, 0, Input.GetAxis("Vertical_2") * speedMovement);
        //Debug.Log(Input.GetAxis("Horizontal_2") + " " + Input.GetAxis("Vertical_2"));
        if (speed != Vector3.zero)
        {
            Quaternion quat = Quaternion.LookRotation(speed);
            transform.rotation = quat;
        }
        charController.Move(speed * Time.deltaTime);
        /*if (Input.GetAxis("Horizontal_2")!=0 )
        {
            this.transform.Translate(new Vector3(Input.GetAxis("Horizontal_2")*speedMovement*Time.deltaTime, 0, Input.GetAxis("Vertical_2") * speedMovement * Time.deltaTime));
        }*/
       
      


        
        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
            //Debug.Log("apretas A en J2");
            
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button2))
        {
            //Debug.Log("apretas X en J2");
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
           // Debug.Log("apretas B en J2");
        }

        if (speed.magnitude != 0)
        {
            anim.SetBool("move", true);
        }
        else anim.SetBool("move", false);

    }
}
