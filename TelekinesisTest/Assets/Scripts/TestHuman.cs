using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHuman : MonoBehaviour {

	public GrabandDrop grabAndDrop; //testhuman script
	private Animator anim;

	public Collider Maincollider;
	public Collider[] AllColiders; 

	public bool enemyGrabbed; 
	bool grabbed = false; 

	public Transform target; 


	void Awake () {
		Maincollider = GetComponent<Collider>(); 
		AllColiders = GetComponentsInChildren<Collider>(true); 
		anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {

		//Play animtation when picked up and start ragdoll when thrown
		if (Input.GetMouseButtonDown(0) && GrabandDrop.grabbedEnemy == true) {
			//Debug.Log("grab_anim"); 
			anim.SetBool("Grabbed", true);  		
		} 
		else if (Input.GetKeyDown(KeyCode.E) && GrabandDrop.grabbedEnemy == false) { 
			anim.SetBool("Grabbed", false); 
			DoRagdoll(true); 
		}	

		//remove after test 
		//if (Input.GetKeyDown(KeyCode.E)){
		//	DoRagdoll(true); 
		//}
		if (Input.GetKeyDown(KeyCode.F)){
			DoRagdoll(false); 
		}
	}

		public void DoRagdoll(bool isRagdoll){ //enables the ragdoll coliders when in ragdoll mode 

		foreach (var col in AllColiders){ 
		col.enabled = isRagdoll; 
		}
		Maincollider.enabled = !isRagdoll;
		//GetComponent<Rigidbody>().useGravity  = !isRagdoll; 
		GetComponent<Animator>().enabled = !isRagdoll; 
		}	

		void TowardsPlayer(){
		Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime + 2);
	}
}


