using UnityEngine;
using System.Collections;

public class Locomotion : MonoBehaviour {

	public Transform unrotated;
	public float Force = 4;
	public float Acceleration = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal")>0.1 || Input.GetAxis ("Horizontal")< -0.1 ) {
			rigidbody.AddForce(Time.deltaTime * unrotated.right * Input.GetAxis ("Horizontal") * Force,ForceMode.VelocityChange);
		}
		if (Input.GetAxis ("Vertical")>0.1 || Input.GetAxis ("Vertical")< -0.1 ) {
			rigidbody.AddForce(Time.deltaTime * unrotated.forward * Input.GetAxis ("Vertical") * Acceleration,ForceMode.VelocityChange);
		}
	}
}
