using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metalPicker : MonoBehaviour {
    public GameObject buttonA, buttonB, buttonX;
    public GameObject player1, metalPicked;
    public playerStatus p1Status;
    public GameObject prefabMedium, prefabSmall, prefabBig, voidPrefab;
    public bool enterFor;
    public float timer = 0;

    // Use this for initialization
    void Start() {
        buttonA.SetActive(false);
        buttonB.SetActive(false);
        buttonX.SetActive(false);
        enterFor = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (!enterFor)
        {
            timer += Time.deltaTime;
            if (timer > 0.7)
            {
                timer = 0;
                enterFor = true;
            }
        }

    }

    void OnTriggerEnter(Collider col)
    {
        buttonA.SetActive(true);
        buttonB.SetActive(true);
        buttonX.SetActive(true);

    }

    void OnTriggerExit(Collider col)
    {
        buttonA.SetActive(false);
        buttonB.SetActive(false);
        buttonX.SetActive(false);

    }

    void OnTriggerStay(Collider col)
    {
        if (enterFor)
        {
            enterFor = false;
            #region A
            if (col.tag == "Player_1" && Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                p1Status.destroyMyChilds();
                //p1Status.handBusy = true;
                metalPicked = (GameObject)Instantiate(prefabMedium, p1Status.hand.transform.position, p1Status.hand.transform.rotation);
                metalPicked.transform.parent = p1Status.hand.transform;
                p1Status.itemInHand = metalPicked;
                p1Status.setMetalState();
                //Debug.Log("GrabMedPiece");
            }

            #endregion

            #region B
            if (col.tag == "Player_1" && Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                p1Status.destroyMyChilds();
                //p1Status.handBusy = true;

                metalPicked = (GameObject)Instantiate(prefabBig, p1Status.hand.transform.position, p1Status.hand.transform.rotation);
                metalPicked.transform.parent = p1Status.hand.transform;
                p1Status.itemInHand = metalPicked;
                p1Status.setMetalState();
                //Debug.Log("GrabBigPiece");
            }

            #endregion

            #region X
            //Debug.Log(this.name+" "+col.tag);
            if (col.tag == "Player_1" && Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                p1Status.destroyMyChilds();
                //p1Status.handBusy = true;
                metalPicked = (GameObject)Instantiate(prefabSmall, p1Status.hand.transform.position, p1Status.hand.transform.rotation);
                metalPicked.transform.parent = p1Status.hand.transform;
                p1Status.itemInHand = metalPicked;
                p1Status.setMetalState();
                //Debug.Log("GrabSmallPiece");
            }
            #endregion
        }
    }

}
