using UnityEngine;
using System.Collections;

namespace Player {
	public class Locomotion : MonoBehaviour {

		private Transform unrotated;
		public float Force = 4;
		public float Acceleration = 4;

		private string playerText;

		void Start(){
			unrotated = transform.parent.Find("PlayerPosition");
			playerText = transform.name;
		}

		// Update is called once per frame
		void Update () {
			if (Input.GetAxis (playerText + " Horizontal")>0.1 || Input.GetAxis (playerText + " Horizontal")< -0.1 ) {
				rigidbody.AddForce(Time.deltaTime * unrotated.right * Input.GetAxis (playerText + " Horizontal") * Force,ForceMode.VelocityChange);
			}
			if (Input.GetAxis (playerText + " Vertical")>0.1 || Input.GetAxis (playerText + " Vertical")< -0.1 ) {
				rigidbody.AddForce(Time.deltaTime * unrotated.forward * Input.GetAxis (playerText + " Vertical") * Acceleration,ForceMode.VelocityChange);
			}
		}
	}
}