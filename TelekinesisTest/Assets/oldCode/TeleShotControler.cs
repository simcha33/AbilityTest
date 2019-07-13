using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleShotControler : MonoBehaviour {

	public Transform teleShotObj; 
	public static string telekStatus = "no"; 

	public static bool shot = false; 
	void Start () {
		
	}
	
	void Update () {
		//Shoot out orb to detect collision with object 
		if (Input.GetKeyDown("e") && telekStatus == "no"){
			Instantiate(teleShotObj, transform.position, transform.rotation); 
			//telekStatus = "wait"; 
		}

		
		//Check if you're holding a object to shoot
		if (Input.GetKeyDown("e") && telekStatus == "yes"){
			telekStatus = "shoot"; 
			Debug.Log("gets to shoot check"); 
		}

		Debug.Log(telekStatus); 
		
	}
}
