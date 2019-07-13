using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleControler : MonoBehaviour {

	public int teleShotSpd = 10; 
	void Start () {

		gameObject.name = "TeleShot"; 
		//GetComponent<Rigidbody>().velocity = new Vector3 (0,0,10); 
		GetComponent<Rigidbody>().AddRelativeForce(0,0,20000); 
		
	}
	
}
