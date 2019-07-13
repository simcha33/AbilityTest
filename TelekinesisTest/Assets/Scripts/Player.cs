using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public Transform telestop;

	public GameObject teleStop; 
	public static string teleStatus = "no"; 

	public float Speed;

	public GameObject currentObject; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;

		if(Input.GetMouseButton(0) && teleStatus == "no"){		
			if(Physics.Raycast(transform.position, transform.forward, out hit) && teleStatus == "no"){
				if(hit.transform.CompareTag("teleObject")){
					currentObject = hit.transform.gameObject;
					teleStatus = "pulling";
				}
			}
		}

		if(Input.GetMouseButton(0) && teleStatus == "ready")
		{
			
		}

		if(currentObject != null){
			currentObject.transform.Translate((telestop.position - currentObject.transform.position).normalized * Speed ,Space.World);	
	}

	
	
	}
}
