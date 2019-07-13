using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

	public static float camRotate; 

	void Update () {
		camRotate = transform.eulerAngles.y; 
	}
}
