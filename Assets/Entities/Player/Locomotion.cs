using UnityEngine;
using System.Collections;

namespace Player {
	public class Locomotion : MonoBehaviour {

		public Transform unrotated;
		public float Force = 4;
		public float Acceleration = 4;

		public bool player2;

		// Update is called once per frame
		void Update () {
			var playerText = "Player 1";
			if (player2)
				playerText = "Player 2";

			if (Input.GetAxis (playerText + " Horizontal")>0.1 || Input.GetAxis (playerText + " Horizontal")< -0.1 ) {
				rigidbody.AddForce(Time.deltaTime * unrotated.right * Input.GetAxis (playerText + " Horizontal") * Force,ForceMode.VelocityChange);
			}
			if (Input.GetAxis (playerText + " Vertical")>0.1 || Input.GetAxis (playerText + " Vertical")< -0.1 ) {
				rigidbody.AddForce(Time.deltaTime * unrotated.forward * Input.GetAxis (playerText + " Vertical") * Acceleration,ForceMode.VelocityChange);
			}
		}
	}
}