using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveControl : MonoBehaviour {

	public Transform target; 

	Rigidbody rb; 
	public float moveSpeed = 2.0f; 

	void Start () 
	{
		//GetComponent<Rigidbody>().velocity = new Vector3(0,0,-5); //movement
		//GetComponent<Rigidbody>().angularVelocity = new Vector3(4,0,0); // rotation 
		rb = GetComponent<Rigidbody>(); 
	}
	
	void Update()
	{
		if (TeleShotControler.telekStatus == "shoot" && Input.GetKeyDown("e")){
			GetComponent<Rigidbody>().velocity = new Vector3(0,0,10);
			TeleShotControler.telekStatus = "no"; 
		}
	}	

	void OnTriggerEnter(Collider other) {

		//Checks if the teleshot hit a object and then pulls this object in
		if (other.name == "TeleShot")
		{
		TeleShotControler.telekStatus = "wait"; 
		transform.eulerAngles = new Vector3(0,CameraControler.camRotate, 0); 
		GetComponent<Rigidbody>().AddRelativeForce(0,0,-600); //movement
		TowardsPlayer(); 
		//GetComponent<Rigidbody>().transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		GetComponent<Rigidbody>().angularVelocity = new Vector3(4,0,0); // rotation 
		transform.LookAt(target);
		}

		if (other.name == ("TeleStop") && TeleShotControler.telekStatus == "wait")
		{
			GetComponent<Rigidbody>().velocity = new Vector3(0,0,0); //stop movement 
			TeleShotControler.telekStatus = "yes"; 
		}

		
	}

	void TowardsPlayer(){
		Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime + 2);
	}
}
