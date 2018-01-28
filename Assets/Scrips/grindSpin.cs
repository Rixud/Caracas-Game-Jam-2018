using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grindSpin : MonoBehaviour {
    public snapOnSite thisSnap;
    public float spinSpeed, spinForce, minSpeed, maxSpeed, counter, maxCounter;
    public bool isSpinning;
    public Image spinBar;
    public GameObject fill, fillBG;

    // Use this for initialization
    void Start () {
        fill.SetActive(false);
        fillBG.SetActive(false);
        isSpinning = false;
        spinBar.fillAmount = spinSpeed / maxSpeed;
        counter = 0;
        maxCounter = Random.Range(5f, 20f);

    }
	
	// Update is called once per frame
	void Update () {
        if (spinSpeed > minSpeed)
        {
            isSpinning = true;
            spinBar.color = Color.blue;
        }
        else
        {
            isSpinning = false;
            spinBar.color = Color.yellow;
        }
        #region B
        if(thisSnap.buttonSelected == 1)
        {
            if (thisSnap.isSnaped && Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                spinSpeed += spinForce;
                counter += 1;
                if (spinSpeed > 3)
                {
                    spinSpeed = 3f;
                }
                if(counter>maxCounter)
                {
                    counter = 0;
                    thisSnap.changeButton(2);
                    maxCounter = Random.Range(5f, 20f);
                }

            }
        }
        #endregion

        #region X
        if (thisSnap.buttonSelected == 2)
        {
            if (thisSnap.isSnaped && Input.GetKeyDown(KeyCode.Joystick2Button2))
            {
                spinSpeed += spinForce;
                counter += 1;
                if (spinSpeed > 3)
                {
                    spinSpeed = 3f;
                }
                if (counter > maxCounter)
                {
                    counter = 0;
                    thisSnap.changeButton(1);
                    maxCounter = Random.Range(5f, 20f);
                }


            }
        }
        #endregion
        spinSpeed -= Time.deltaTime*3;
        spinBar.fillAmount = spinSpeed / maxSpeed;

        if (spinSpeed<0)
        {
            spinSpeed = 0;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        fill.SetActive(true);
        fillBG.SetActive(true);
    }


    void OnTriggerExit(Collider col)
    {
        fill.SetActive(false);
        fillBG.SetActive(false);
    }


}
