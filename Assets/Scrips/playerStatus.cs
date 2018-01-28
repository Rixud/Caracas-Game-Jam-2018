using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour {
    //public bool handBusy;
    public GameObject hand, itemInHand;
    public metalStats metalSt;



    // Use this for initialization
    void Start () {
        //handBusy = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void destroyMyChilds()
    {
        Debug.Log("Estamos destruyendo");

        foreach (Transform child in transform)
        {
            Debug.Log("Destruyendo " + child);
            GameObject.Destroy(child.gameObject);
        }
        //handBusy = false;
    }

    public void setMetalState()
    {
        if(itemInHand.tag=="Metal")
        {
            metalSt = itemInHand.GetComponent<metalStats>();
        }
       
    }
}
