using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {


    public GameObject destroyer;
    
	// Use this for initialization
	void Start () {



        if (destroyer.GetComponent<Collider>() != GetComponent<Collider>())
        {
            Physics.IgnoreCollision(destroyer.GetComponent<Collider>(), GetComponent<Collider>());
        }
	}
	
	
}
