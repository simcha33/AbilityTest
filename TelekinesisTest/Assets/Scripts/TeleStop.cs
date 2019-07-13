using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleStop : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "teleObject")
		{
			//GetComponent<Rigidbody>().
			Player.teleStatus = "Ready"; 
		}
	}
}
