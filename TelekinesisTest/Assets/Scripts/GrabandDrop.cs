using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GrabandDrop : MonoBehaviour {

	// Use this for initialization

	GameObject grabbedObject; 
	public GameObject teleStop; 
	float grabbedObjectSize; //grabbedobjectSize
	float grabbedObjectHeight;
	float pushChargeTime = 0; 

	public float grabRange; 
	public float normalePushForce; 
	public float pushForce; 
	public float pushForceMax; 
	public float throwPower; 

	public static bool grabbedEnemy = false; 

	public Text chargeTimer; 

	Vector3 previousGrabPos;

	bool pushCharging = false; 



	// Checks what we are trying to grab with a raycast and makes sure it only grabs grabable items
	GameObject GetMouseHooverObject()
	{
		Vector3 position = gameObject.transform.position; 
		RaycastHit raycastHit; 
		Vector3 target = position + Camera.main.transform.forward * grabRange; 

		if(Physics.Linecast(position, target,out raycastHit) && (raycastHit.transform.CompareTag("teleObject"))){
			return raycastHit.collider.gameObject;	
		}
		else{
			return null; 
		}
	}

	//Checks wheter or not we've grabbed a object
	void TryGrabbedObject(GameObject grabObject){
		if (grabObject == null){
			return; 
		}
	
		grabbedObject = grabObject; 
		grabbedObjectSize = grabObject.GetComponent<Collider>().bounds.size.magnitude;
		grabbedObjectHeight = grabObject.GetComponent<Collider>().bounds.size.y;
		grabbedObject.GetComponent<Rigidbody>().useGravity = false; // turn object gravity off when picked up 
		
	}

	void DropObject(){
		if (grabbedObject== null){
			return; 
		}

		Rigidbody rb = grabbedObject.GetComponent<Rigidbody>(); 
		if (rb!=null)
		{
			Vector3 throwVector = grabbedObject.transform.position - previousGrabPos;
			//float throwPower = throwVector.magnitude / Time.deltaTime;  
			Vector3 throwVelocity = throwPower*throwVector.normalized;

			pushForce = normalePushForce; 
			throwVelocity += Camera.main.transform.forward*pushForce; 

			rb.velocity = throwVelocity; 
			rb.useGravity = true; // turn object gravity back on when pushed	
			Debug.Log("forcepushed");
		}

		grabbedObject = null; 
	}
	

	void Update () {
		
		Debug.Log(pushForce); 
		if (Input.GetMouseButtonDown(0))
		{	
			if (grabbedObject == null){
				TryGrabbedObject(GetMouseHooverObject()); 
				grabbedEnemy = true; 
				Debug.Log("grabbed"); 
			}
			else {
				DropObject(); 
				grabbedEnemy = false; 
			}
		}

		if (Input.GetMouseButton(1) && pushForce <=pushForceMax)
		{ 
			pushForce += 4.0f/90.0f; 
		}
		if (Input.GetMouseButtonUp(1))
		{
			DropObject(); 
			//pushForce = normalePushForce; 
		}

		//Moves the obejct to our camera positition if we've grabbed something 
		if (grabbedObject != null)
		{
		//Debug.Log(GetMouseHooverObject()); 
		previousGrabPos = grabbedObject.transform.position; //saves the last pos of the object 
		Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * 2 - Vector3.up*grabbedObjectHeight/2; 
		grabbedObject.transform.position = newPosition; 
		}
	}
}


/* notes: 

- Make it so when a object is grabbed it always faces towards you. So people with rigidbodys want get confused. 

 */

