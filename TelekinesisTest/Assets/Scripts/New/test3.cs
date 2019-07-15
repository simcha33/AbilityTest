using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test3 : MonoBehaviour {

	public Transform playerPos; 

	public float pullSpeed = 5f; 

	private Rigidbody rb; 
	void Start () {

		rb = GetComponent<Rigidbody>(); 
		
	}
	
	void FixedUpdate () {

		Vector3 direction = playerPos.position - rb.position; 

		direction.Normalize(); 

		Vector3.Cross(direction,transform.forward); 

		rb.velocity = transform.forward * pullSpeed; 
	}
}
