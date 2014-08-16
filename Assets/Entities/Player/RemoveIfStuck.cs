using UnityEngine;
using System.Collections;
using System;

public class RemoveIfStuck : MonoBehaviour {

	public float velocityTreshHold = 0.1f;
	public float TimeLimit = 1.5f;


	public float currentVelocity;
	public bool currentlystopped;
	private float stoppedAt;

	// Use this for initialization
	void Start () {
		currentlystopped = false;
	}
	
	// Update is called once per frame
	void Update () {
		currentVelocity = rigidbody.velocity.magnitude;
		if (!currentlystopped) {
			if (currentVelocity < velocityTreshHold) {
				stoppedAt = Time.realtimeSinceStartup;
				currentlystopped = true;
			}
		} else if (Time.realtimeSinceStartup - stoppedAt > TimeLimit) {
				RemoveAndReset ();
		} else if (currentVelocity > velocityTreshHold) {
			currentlystopped = false;
		}
	}

	void RemoveAndReset() {
		var keepElements = Camera.main.gameObject.GetComponent<MainCamera.KeepElementsVisible> ();
	//	Debug.Log(keepElements);
		GameObject[] dest = new GameObject[keepElements.elements.Length -1];
	//	Debug.Log(dest);
		var index = Array.IndexOf (keepElements.elements, gameObject);
		
	//	Debug.Log(index);
		if (index > 0)
			Array.Copy (keepElements.elements,0,dest,0,index);
		if (index > 0 && index < keepElements.elements.Length - 1)
			Array.Copy (keepElements.elements,index +1, dest, index, keepElements.elements.Length - index - 1);
		keepElements.elements = dest;
	//	Debug.Log("Reinitialize");
		keepElements.Reinitialize ();
//		Debug.Log("Destroy");
		Destroy (gameObject);
	}
}
