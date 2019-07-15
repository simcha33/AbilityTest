using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript2 : MonoBehaviour {

	public float checkRange; 
	public Camera playerCamera; 

	public GameObject stopPos; 

	private Rigidbody rb; 


	void Update () {
		if(Input.GetButtonDown ("Fire1")){
			
			Telecheck(); //check for teleobject pick up 
		}

	}

	public void Telecheck(){
		RaycastHit hit; 
		if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, checkRange))
		{
			Debug.Log(hit.transform.name); 
			
			rb = hit.transform.GetComponent<Rigidbody>(); 
		} 
	}
		
	
}


 /*step 1: Check if there is something grabable when clicking
   step 2: if there is make the object move towards the players position
   step 3: if the player presses the launch button make the grabbed object fly backwards
   */