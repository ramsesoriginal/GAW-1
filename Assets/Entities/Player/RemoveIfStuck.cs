using UnityEngine;
using System.Collections;
using System;

namespace Player {
	public class RemoveIfStuck : MonoBehaviour {

		public float velocityTreshHold = 0.1f;
		public float TimeLimit = 1.5f;


		private float currentVelocity;
		private bool currentlystopped;
		private float stoppedAt;
		private Remover remover;

		// Use this for initialization
		void Start () {
			currentlystopped = false;
			remover = GetComponent<Remover> ();
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
				remover.RemoveAndReset ();
			} else if (currentVelocity > velocityTreshHold) {
				currentlystopped = false;
			}
		}
	}
}